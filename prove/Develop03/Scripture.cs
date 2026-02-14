using System;
using System.Collections.Generic;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    
    public Scripture(string reference, string verse)
    {
        _reference = new Reference(reference);
        _words = new List<Word>();
        
        string[] WordArray = verse.Split(' ');
        foreach (string word in WordArray)
        {
            _words.Add(new Word(word));
        }
    }
    
    public void HideWords(int amount)
    {
        List<int> VisibleWords = new List<int>();
        
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                VisibleWords.Add(i);
            }
        }
        
        int ToHide = Math.Min(amount, VisibleWords.Count);
        Random Random = new Random();
        
        for (int i = 0; i < ToHide; i++)
        {
            int RandomIndex = Random.Next(0, VisibleWords.Count);
            int WordIndex = VisibleWords[RandomIndex];
            _words[WordIndex].Hide();
            VisibleWords.RemoveAt(RandomIndex);
        }
        
        DisplayVerse();
    }
    
    public void DisplayVerse()
    {
        Console.WriteLine("\n" + _reference.GetText());
        Console.WriteLine();
        
        foreach (Word word in _words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }
        
        Console.WriteLine("\n");
    }
    
    public bool AllHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}