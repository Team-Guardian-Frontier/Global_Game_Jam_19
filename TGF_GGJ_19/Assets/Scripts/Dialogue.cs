using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Dillon Z - TGF
//Object holds Dialogue to play

[System.Serializable]
public class Dialogue
{

    public string name;

    [TextArea(3, 10)]
    public string[] sentences;

}
