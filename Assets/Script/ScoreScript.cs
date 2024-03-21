using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public Boolean Crash;
    public int ScoreNumber;
    public TextMeshProUGUI ScoreText;
    void Start()
    {
        ScoreNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = ScoreNumber.ToString();
    }
}
