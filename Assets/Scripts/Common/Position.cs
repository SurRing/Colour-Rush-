using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
[System.Serializable]
public class Position{

    public int x;
    public int y;
    public Position(int valuex,int valuey)
    {
        x = valuex;
        y = valuey;
    }

    public override string ToString()
    {
        return string.Format("({0},{1})", x, y);
    }

    public override bool Equals(object obj)
    {
        //Debug.Log(this.ToString()+obj.ToString()+(this == obj));
        return this.ToString() == obj.ToString();
    }

    public bool Equals (Position p2)
    {
        return x == p2.x && y == p2.y;
    }

    public override int GetHashCode()
    {
        return x ^ y;
    }

}
