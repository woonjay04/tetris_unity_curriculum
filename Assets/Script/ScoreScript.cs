using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Specialized;

public class ScoreScript : MonoBehaviour
{
    public static Transform[,] Grid = new Transform[BlockScript.GridWidth, BlockScript.GridHeight];
    public static int[,] ColorGrid = new int[BlockScript.GridWidth, BlockScript.GridHeight];
    public Boolean Crash;
    public static int ScoreNumber;
    private int LastScore;
    public TextMeshProUGUI ScoreText;
    private static string path;
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
    public static void SaveData()
    {
        Data data = new Data(ScoreNumber,BlockScript.GridWidth, BlockScript.GridHeight, ColorGrid);
        Debug.Log(data);
        try
        {
            string json = data.ToJson();
            File.WriteAllText(path, json);
            Debug.Log("success save");
        }
        catch(Exception e)
        {
            Debug.LogError("save failed : " + e.Message);
        }
    }

    public static void LoadData()
    {
        if(File.Exists(path))
        {
            Debug.Log("Load!");
            for(int i = BlockScript.GridHeight-1; i >= 0; i--)
            {
                BlockScript.DeleteLine(i);
            }

            String json = File.ReadAllText(path);
            Data data = Data.FromJson(json);
            ScoreNumber = data.Score;
            int[,] newGrid = data.ToArray();
            for(int i = 0; i < BlockScript.GridWidth; i++)
            {
                for(int j = 0; j < BlockScript.GridHeight; j++)
                {
                    
                    ColorGrid[i,j] = newGrid[i,j];

                    switch (ColorGrid[i, j])//int값에 따라 트랜스폼에 단일 프리팹 저장하는 코드 작성
                    {
                        case 1:
                            SpawnTetrimino.SpawnLoadBlocks("Block1", i, j);
                            break;
                        case 2:
                            SpawnTetrimino.SpawnLoadBlocks("Block2", i, j);
                            break;
                        case 3:
                            SpawnTetrimino.SpawnLoadBlocks("Block3", i, j);
                            break;
                        case 4:
                            SpawnTetrimino.SpawnLoadBlocks("Block4", i, j);
                            break;
                        case 5:
                            SpawnTetrimino.SpawnLoadBlocks("Block5", i, j);
                            break;
                        case 6:
                            SpawnTetrimino.SpawnLoadBlocks("Block6", i, j);
                            break;
                        case 7:
                            SpawnTetrimino.SpawnLoadBlocks("Block7", i, j);
                            break;
                        case 0:
                            break;
                    }
                }
            }
        }
    }
}

[System.Serializable]
public class Data
{
    public int Score;//현재점수
    public int Rows;
    public int Columns;
    public int[,] ColorTrans {  get; set; }
    
    public Data(int score, int rows, int columns, int[,] colorTrans)
    {
        Score = score;
        Rows = rows;
        Columns = columns;
        ColorTrans = colorTrans;
    }
    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }

    public static Data FromJson(string json)
    {
        return JsonConvert.DeserializeObject<Data>(json);
    }
    public int[,] ToArray()
    {
        return ColorTrans;
    }
}