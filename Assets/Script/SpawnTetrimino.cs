using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTetrimino : MonoBehaviour
{
    public GameObject[] Tetriminoes;
    // Start is called before the first frame update
    void Start()
    {
        SpawnNewTetrimino();
    }
    public void SpawnNewTetrimino()
    {
        GameObject obj = Instantiate(Tetriminoes[Random.Range(0,Tetriminoes.Length)],transform.position, Quaternion.identity);
        obj.transform.parent = transform;
    }
    
}
