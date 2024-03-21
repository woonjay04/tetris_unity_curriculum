using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTetrimino : MonoBehaviour
{
    public GameObject[] Tetriminoes;
    public GameObject ScoreObject;
    // Start is called before the first frame update
    void Start()
    {
        SpawnNewTetrimino();
        ScoreObject = GameObject.Find("ScoreText");

    }
    public void SpawnNewTetrimino()
    {
        GameObject obj = Instantiate(Tetriminoes[Random.Range(0,Tetriminoes.Length)],transform.position, Quaternion.identity);
        obj.transform.parent = transform;
    }
    public void GameOver()
    {
        foreach(Transform children in transform)
        {
            Destroy(children.gameObject);
        }
        ScoreScript.ScoreNumber = 0;
    }
}
