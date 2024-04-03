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
    public static void SpawnLoadBlocks(string BlockName, int xpos, int ypos)
    {
        GameObject OneBlock = Resources.Load<GameObject>(BlockName);
        GameObject obj = Instantiate(OneBlock,new Vector3(xpos,ypos,0),Quaternion.identity);
        GameObject spawnObject = GameObject.Find("Spawner");
        obj.transform.parent = spawnObject.transform;
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
