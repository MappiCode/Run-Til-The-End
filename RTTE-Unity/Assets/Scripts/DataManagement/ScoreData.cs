using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScoreData
{
    public float score;
    public DateTime dateTime;

    public ScoreData(float _score)
    {
        score = _score;
        dateTime = DateTime.Now;
    }
}
