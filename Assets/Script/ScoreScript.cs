using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;

public class ScoreScript : MonoBehaviour
{
    public Boolean Crash;
    public static int ScoreNumber;
    private int LastScore;
    public TextMeshProUGUI ScoreText;
    private string path;
    void Start()
    {
        path = Path.Combine(Application.dataPath, "Data.json");
        ScoreNumber = 0;
        LastScore = 0;
    }
    void Update()
    {
        if(LastScore != ScoreNumber)
        {
            LastScore = ScoreNumber;
            ScoreText.text = ScoreNumber.ToString();
        }
    }
    public void GetBlockDataList()
    {
        //BlockDataList = new List<BlockData>();

    }
}

[System.Serializable]
public class Data
{
    public int Score;//현재점수
    public Transform[,] GridTrans;//그리드
    public List<BlockData> BlockDataList;
    public Data(int score, Transform[,] gridTrans, List<BlockData> blockDataList)
    {
        this.Score = score;
        this.GridTrans = gridTrans;
        this.BlockDataList = new List<BlockData>(BlockDataList);
    }
}

[System.Serializable]
public class BlockData
{
    public Vector3 position;
    public Quaternion rotation;
    public string name;
    public BlockData(Vector3 position, Quaternion rotation, string name)
    {
        this.position = position;
        this.rotation = rotation;
        this.name = name;
    }
}