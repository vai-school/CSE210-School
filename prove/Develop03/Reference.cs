using System;
using System.Collections.Generic;

class Reference
{
    private string _text;
    
    public Reference(string text)
    {
        _text = text;
    }
    
    public string GetText()
    {
        return _text;
    }
}