using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using static UnityEngine.Advertisements.Advertisement;

public class BlockScript : MonoBehaviour
{
    public Vector3 RotationPoint;
    public float previousTime;
    private float FallTime = 0.8f;

    public static int GridHeight = 20;
    public static int GridWidth = 10;
    public int ClearLine = 0;
    private static Transform[,] Grid = new Transform[GridWidth, GridHeight];

    public GameObject spawner;

    private void Start()
    {
        spawner = GameObject.Find("Spawner");
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J)) //Left move
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!VaildMove())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.L)) //Right move
        {
            transform.position += new Vector3(1, 0, 0);
            if (!VaildMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }
        else if(Input.GetKeyDown(KeyCode.I))
        {
            transform.RotateAround(transform.TransformPoint(RotationPoint), new Vector3(0, 0, 1), 90);
            if (!VaildMove())
            {
                transform.RotateAround(transform.TransformPoint(RotationPoint), new Vector3(0, 0, 1), -90);
            }
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            transform.RotateAround(transform.TransformPoint(RotationPoint), new Vector3(0, 0, 1), -90);
            if (!VaildMove())
            {
                transform.RotateAround(transform.TransformPoint(RotationPoint), new Vector3(0, 0, 1), 90);
            }
        }

        if (Time.time - previousTime > (Input.GetKey(KeyCode.S) ? FallTime / 10 : FallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!VaildMove())
            {
                Debug.Log(this.gameObject.transform.position);
                if(this.gameObject.transform.position == new Vector3(5,17,0))
                {
                    FindObjectOfType<SpawnTetrimino>().GameOver();
                }
                transform.position -= new Vector3(0, -1, 0);
                AddToGrid();
                CheckLines();
                this.enabled = false;
                FindObjectOfType<SpawnTetrimino>().SpawnNewTetrimino();
            }
            previousTime = Time.time;
        }
    }

    void AddToGrid()
    {
        foreach (Transform children in transform)
        {
            int RoundedX = Mathf.RoundToInt(children.transform.position.x);
            int RoundedY = Mathf.RoundToInt(children.transform.position.y);

            Grid[RoundedX,RoundedY] = children;
        }
    }

    void CheckLines()
    {
        for(int i = GridHeight - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
                ClearLine += 1;
            }
        }
        GameObject scoretext = GameObject.Find("ScoreText");
        ScoreScript.ScoreNumber += 1000 * ClearLine;
        if(ScoreScript.ScoreNumber >= HighScoreScript.HighScore)
        {
            HighScoreScript.HighScore = ScoreScript.ScoreNumber;
            PlayerPrefs.SetInt("HighScore",HighScoreScript.HighScore);
        }
        ClearLine = 0;
    }
    bool HasLine(int i)
    {
        for(int j = 0; j < GridWidth; j++)
        {
            if (Grid[j, i] == null)
            {
                return false;
            }
        }
        return true;
    }
    void DeleteLine(int i)
    {
        for (int j = 0; j < GridWidth; j++)
        {
            
            Destroy(Grid[j, i].gameObject);   
            Grid[j, i] = null;

            
        }
        
    }

    void RowDown(int i)
    {
        for(int y = i; y < GridHeight; y++)
        {
            for(int j = 0; j < GridWidth; j++)
            {
                if (Grid[j, y] != null)
                {
                    Grid[j, y-1] = Grid[j, y];
                    Grid[j, y] = null;
                    Grid[j, y-1].transform.position -= new Vector3(0,1,0);
                }
            }
        }
    }
    bool VaildMove()
    {
        foreach(Transform children in transform)
        {
            int RoundedX = Mathf.RoundToInt(children.transform.position.x);
            int RoundedY = Mathf.RoundToInt(children.transform.position.y);            
            if (RoundedX < 0 || RoundedX >= GridWidth || RoundedY < 0 || RoundedY >= GridHeight)
            {
                return false;
            }
            if (Grid[RoundedX, RoundedY] != null)
            {
                return false;
            }
        }
        return true;
    }
}
