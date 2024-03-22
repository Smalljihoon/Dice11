using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonButton : MonoBehaviour
{
    //[SerializeField] Button Summon;
    [SerializeField] GameObject enemy;
    [SerializeField] Transform start;
    
    void Start()
    {
        enemy.SetActive(false);
    }

    void Update()
    {

    }

    public void Summon()
    {
        enemy.transform.position = start.transform.position;
        
        enemy.SetActive(true);
    }
}
