using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
    void Update()
    {
        if(this.gameObject.transform.childCount == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
