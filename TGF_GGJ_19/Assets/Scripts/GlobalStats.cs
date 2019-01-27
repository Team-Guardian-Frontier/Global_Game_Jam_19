using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalStats 
{
    public static int Kills
    {
        get
        {
            return Kills;
        }
        set
        {
            Kills = value;
        }
    }

    public static int Deaths
    {
        get
        {
            return Deaths;
        }
        set
        {
            Deaths = value;
        }
    }
}
