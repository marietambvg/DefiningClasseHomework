using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Display
{
    private string size;
    private int numberOfColors;
    public Display()
    {
        this.size = null;
        this.numberOfColors = 0;
    }

    public Display(string size, int numberOfColors)
    {
        this.size = size;
        this.numberOfColors = numberOfColors;
    }
    public string Size
    {
        get { return this.size; }
        set { this.size = value; }

    }
    public int NumberOfColors
    {
        get { return this.numberOfColors; }
        set { this.numberOfColors = value; }

    }

}