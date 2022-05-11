using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Die : IDie
{
    public int[] Numbers = { 1, 2, 3, 4, 5, 6 };

    private int ValueOnTop { get; set; }

    public void SetValueOnTop (int value)
    {
        ValueOnTop = value;
    }
    public int GetValueOnTop()
    {
        return ValueOnTop;
    }
}

