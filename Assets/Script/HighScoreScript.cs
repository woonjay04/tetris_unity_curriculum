using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HighScoreScript : MonoBehaviour
{
    int score;
    public static int HighScore;
    public TextMeshProUGUI HighScoreText;

    private void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore");
        score = ScoreScript.ScoreNumber;
    }
    void Update()
    {
        HighScoreText.text = HighScore.ToString();
    }
}
