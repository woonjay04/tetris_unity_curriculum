using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ClickToLoad()
    {
        ScoreScript.LoadData();
    }
    public void ClickToSave()
    {
        ScoreScript.SaveData();
    }
    public void ClickToQuit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif  
    }
}
