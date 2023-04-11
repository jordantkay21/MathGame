using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoSingleton<ScoreManager>
{
    [SerializeField]
    private int _currentScore;

    public void AddToScore(int value)
    {
        _currentScore = _currentScore + value;
        DisplayManager.Instance.DisplayScore(_currentScore);
    }
}
