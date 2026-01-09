using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    // -- 26 items A-Z
    public List<int> lowlevelPlayed = new List<int>(); // Upper
    public List<int> medlevelPlayed = new List<int>(); // Lower
    public List<int> highlevelPlayed = new List<int>(); // Words
    public List<int> mixlevelPlayed = new List<int>(); // NEW: Mixed

    // -- 26 items
    public List<int> lowlevelMiss = new List<int>();
    public List<int> medlevelMiss = new List<int>();
    public List<int> highlevelMiss = new List<int>();
    public List<int> mixlevelMiss = new List<int>();   // NEW

    // -- 26 items
    public List<int> lowlevelTime = new List<int>();
    public List<int> medlevelTime = new List<int>();
    public List<int> highlevelTime = new List<int>();
    public List<int> mixlevelTime = new List<int>();   // NEW
}
