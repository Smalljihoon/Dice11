using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    [SerializeField] float speed;
    RaycastHit ray;
    private void Start()
    {
        
    }
    void Update()
    {
        //enemy = MoveTowards()
    }

    

}
