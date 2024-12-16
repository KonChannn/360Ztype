using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    public List<Word> words;
    private bool hasActiveWord;
    private Word activeWord;
    public WordSpawner wordSpawner;
    public Vector2 position;

    public bool HasActiveWord
    {
        get { return hasActiveWord; }
    }
    public Word ActiveWord
    {
        get { return activeWord; }
    }


    // private void Start()
    // {
    //     // words = new List<Word>();
    //     AddWord();
    //     AddWord();
    //     AddWord();
    // }

    public void AddWord()
    {
        //generate new word and also spawn it using prefabs
        Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());
        Debug.Log(word.word);

        words.Add(word);
    }

    public void TypeLetter(char letter)
    {
        if (hasActiveWord)
        {
            if (activeWord.Display != null)
            {
                if (activeWord.GetNextLetter() == letter)
                {
                    activeWord.TypeLetter();
                    position = activeWord.Display.transform.position;
                }
            }
            else
            {
                // Handle case where the WordDisplay has been destroyed
                Debug.LogWarning("WordDisplay object has been destroyed, skipping interaction.");
                hasActiveWord = false;
            }
        }
        // To Activate a word
        else
        {
            foreach (Word word in words)
            {
                if (word.GetNextLetter() == letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    position = activeWord.Display.transform.position;
                    // DebugActiveWordPosition();
                    break;
                }
            }
        }
        if (hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
        }
    }
    private void DebugActiveWordPosition()
    {
        if (activeWord != null && activeWord.Display != null)
        {
            Vector3 position = activeWord.Display.transform.position;
            Debug.Log($"Active Word Position: {position}");
        }
        else
        {
            Debug.LogWarning("No active word or active word display found.");
        }
    }

}