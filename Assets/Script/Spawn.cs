using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Spawn : MonoBehaviour
{

    [Header("Object")]
    [SerializeField] GameObject enemyPrefab;

    [Header("Transform")]
    [SerializeField] Transform StartSpawn;
    [SerializeField] Transform EndSpawn;

    [Header("Position")]
    [SerializeField] float spawnRate;               // �����ֱ�
    [SerializeField] float offsetRate;              // �����ֱ� ����

    bool isSpawn;
    float rateTime;

    void Start()
    {
        rateTime = spawnRate;
        StartSpawn = GetComponent<Transform>();
        EndSpawn = GetComponent<Transform>();

    }

    void Update()
    {
        //if (!isSpawn)
            //return;
        
        rateTime -= Time.deltaTime;
        if (rateTime <= 0.0f)
        {
            //Vector2 position = StartSpawn.position;
            Transform transform = StartSpawn.transform;
            GameObject newEnemy = enemyPrefab;
            newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.position = transform.position;
            //newEnemy.transform.position = position;
            rateTime = spawnRate;
        }
    }
}
