using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditorInternal;

public class Spawn : MonoBehaviour
{

    [Header("Object")]
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject EndSpawn;

    [Header("Transform")]
    [SerializeField] Transform StartSpawn;

    [Header("Position")]
    [SerializeField] float spawnRate;               // �����ֱ�
    [SerializeField] float offsetRate;              // �����ֱ� ����

    bool isSpawn;
    float rateTime;

    void Start()
    {
        rateTime = spawnRate;
        StartSpawn = GetComponent<Transform>();
        EndSpawn = GetComponent<GameObject>();
    }

    void Update()
    {
        //if (!isSpawn)
        //return;

        rateTime -= Time.deltaTime;
        if (rateTime <= 0.0f)
        {
            Transform transform = StartSpawn.transform;
            GameObject newEnemy = enemyPrefab;
            newEnemy = Instantiate(enemyPrefab);
            //Vector2 position = StartSpawn.position;
            newEnemy.transform.position = transform.position;
            //newEnemy.transform.position = position;
            rateTime = spawnRate;
            
        }
    }
}
