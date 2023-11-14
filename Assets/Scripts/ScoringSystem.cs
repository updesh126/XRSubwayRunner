using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class ScoringSystem : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;
    [SerializeField]
    private TMP_Text text2Sim;

    static private int Score = 0;


    private void Update()
    {
        text.text = Score.ToString();
        text2Sim.text = Score.ToString();
    }
    public void AddScore(int score)
    {
        Score += score;
    }

    public void Reset()
    {
        Score = 0;
    }
}
