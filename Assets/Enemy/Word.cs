using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word 
{
    public string word;
    private int typeIndex;

    private WordDisplay _display;

    public Word(string word, WordDisplay display)
    {
        this.word = word;
        typeIndex = 0;
        this._display = display;
        this._display.SetWord(word);
    }

    public char GetNextLetter()
    {
        return word[typeIndex];
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
        if (wordTyped)
        {
            // Remove the word from the screen
            _display.RemoveWord();
        }
        return wordTyped;
    }

}
