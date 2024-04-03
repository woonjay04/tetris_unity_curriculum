using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnClickButton()
    {
        ScoreScript.SaveData();
    }
}
