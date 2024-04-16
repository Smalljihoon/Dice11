using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fusion : MonoBehaviour
{

    Ray2D ray;
    RaycastHit2D hit;

    public Vector3 MousePos
    {
        get
        {
            var result = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            result.z = 0;
            return result;
        }
    }

    void Update()
    {
        
    }
}
