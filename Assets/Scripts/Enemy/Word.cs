using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word 
{
    public string word;
    private int typeIndex;
    private WordDisplay _display;
    // private int bulletHitCount = 0;   // To track how many bullets have hit the word
    // private int hitThreshold = 3;      // The number of hits required to destroy the word

    public Word(string word, WordDisplay display)
    {
        this.word = word;
        typeIndex = 0;
        this._display = display;
        this._display.SetWord(word);
    }

    // Getter for the word display
    public WordDisplay Display
    {
        get { return _display; }
    }

    public char GetNextLetter()
    {
        // Only return a letter if typeIndex is within the valid range
        if (typeIndex < word.Length)
        {
            return word[typeIndex];
        }
        return '\0';  // Return a null character or handle as needed
    }

    public void TypeLetter()
    {
        typeIndex++;
        // Remove the letter that was typed
        _display.RemoveLetter();
    }

    public bool WordTyped()
    {
        bool wordTyped = (typeIndex >= word.Length);
            
        if (wordTyped )
        {
            // Debug.Log("Word typed: " + word);
            // // Debug.Log("Bullet hit count: " + _display.BulletHitCount);
            // Debug.Log("Word length: " + _display.WordLength);
            // // Remove the word from the screen
            _display.CheckAndRemoveWord();
        }
        return wordTyped;
    }
    

}
