using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SaveDataObject : MonoBehaviour
{
    public int[] lowlevelPlayed;
    public int[] medlevelPlayed;
    public int[] highlevelPlayed;

    // NEW: Mixed (upper + lower) mode
    public int[] mixlevelPlayed;

    public int[] lowlevelMiss;
    public int[] medlevelMiss;
    public int[] highlevelMiss;

    // NEW: Mixed
    public int[] mixlevelMiss;

    public int[] lowlevelTime;
    public int[] medlevelTime;
    public int[] highlevelTime;

    // NEW: Mixed
    public int[] mixlevelTime;

    public int levelSum;
    public int missSum;
    public int timeSum;

    public int lowlevelSum;
    public int medlevelSum;
    public int highlevelSum;

    // NEW: Mixed
    public int mixlevelSum;

    public int lowmissSum;
    public int medmissSum;
    public int highmissSum;

    // NEW: Mixed
    public int mixmissSum;

    public int lowtimeSum;
    public int medtimeSum;
    public int hightimeSum;

    // NEW: Mixed
    public int mixtimeSum;

    public void Init()
    {
        // 26 letters A–Z
        lowlevelPlayed = new int[26];
        medlevelPlayed = new int[26];
        highlevelPlayed = new int[26];
        mixlevelPlayed = new int[26];   // NEW

        lowlevelMiss = new int[26];
        medlevelMiss = new int[26];
        highlevelMiss = new int[26];
        mixlevelMiss = new int[26];     // NEW

        lowlevelTime = new int[26];
        medlevelTime = new int[26];
        highlevelTime = new int[26];
        mixlevelTime = new int[26];     // NEW
    }

    public void InitSum()
    {
        lowlevelSum = 0;
        medlevelSum = 0;
        highlevelSum = 0;
        mixlevelSum = 0;   // NEW

        lowmissSum = 0;
        medmissSum = 0;
        highmissSum = 0;
        mixmissSum = 0;   // NEW

        lowtimeSum = 0;
        medtimeSum = 0;
        hightimeSum = 0;
        mixtimeSum = 0;   // NEW

        levelSum = 0;
        missSum = 0;
        timeSum = 0;
    }

    public void TotalSum()
    {
        for (int i = 0; i < lowlevelPlayed.Length; i++)
        {
            // PLAYED
            lowlevelSum += lowlevelPlayed[i];
            levelSum += lowlevelPlayed[i];

            medlevelSum += medlevelPlayed[i];
            levelSum += medlevelPlayed[i];

            highlevelSum += highlevelPlayed[i];
            levelSum += highlevelPlayed[i];

            mixlevelSum += mixlevelPlayed[i];   // NEW
            levelSum += mixlevelPlayed[i];   // NEW

            // MISSES
            lowmissSum += lowlevelMiss[i];
            missSum += lowlevelMiss[i];

            medmissSum += medlevelMiss[i];
            missSum += medlevelMiss[i];

            highmissSum += highlevelMiss[i];
            missSum += highlevelMiss[i];

            mixmissSum += mixlevelMiss[i];     // NEW
            missSum += mixlevelMiss[i];     // NEW

            // TIME
            lowtimeSum += lowlevelTime[i];
            timeSum += lowlevelTime[i];

            medtimeSum += medlevelTime[i];
            timeSum += medlevelTime[i];

            hightimeSum += highlevelTime[i];
            timeSum += highlevelTime[i];

            mixtimeSum += mixlevelTime[i];     // NEW
            timeSum += mixlevelTime[i];     // NEW
        }
    }

    public void LevelSum(int _letterNum)
    {
        levelSum = 0;
        missSum = 0;
        timeSum = 0;

        // (Debug logging left as-is)
        for (int i = 0; i < 26; i++)
        {
            UnityEngine.Debug.Log("MP" + medlevelPlayed[i]);
        }

        // PLAYED
        levelSum += lowlevelPlayed[_letterNum];
        levelSum += medlevelPlayed[_letterNum];
        levelSum += mixlevelPlayed[_letterNum];   // NEW
        levelSum += highlevelPlayed[_letterNum];

        // MISSES
        missSum += lowlevelMiss[_letterNum];
        missSum += medlevelMiss[_letterNum];
        missSum += mixlevelMiss[_letterNum];     // NEW
        missSum += highlevelMiss[_letterNum];

        // TIME
        timeSum += lowlevelTime[_letterNum];
        timeSum += medlevelTime[_letterNum];
        timeSum += mixlevelTime[_letterNum];     // NEW
        timeSum += highlevelTime[_letterNum];
    }
}
