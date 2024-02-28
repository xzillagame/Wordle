using UnityEngine;

public class Cell
{

    private char letter;
    public char Letter
    {
        set { letter = value; }
        get { return letter; }
    }

    private Color color;
    public Color Color
    {
        set { color = value; } 
        get { return color; }
    }

}
