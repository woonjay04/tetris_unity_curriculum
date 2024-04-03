using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static BlockScript;

public class LoadBlockScript : MonoBehaviour
{
    void Start()
    {
        foreach (Transform children in transform)
        {
            int RoundedX = Mathf.RoundToInt(children.transform.position.x);
            int RoundedY = Mathf.RoundToInt(children.transform.position.y);

            ScoreScript.Grid[RoundedX, RoundedY] = children;
        }
    }
}
