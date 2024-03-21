using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public Boolean Crash;
    public static int ScoreNumber;
    public TextMeshProUGUI ScoreText;
    void Start()
    {
        ScoreNumber = 0;
    }
    void Update()
    {
        ScoreText.text = ScoreNumber.ToString();
    }
}
