using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditorInternal;

public class Spawn : MonoBehaviour
{

    [Header("Object")]
    [SerializeField] GameObject enemyPrefab;

    [Header("Transform")]
    [SerializeField] Transform StartSpawn;
    [SerializeField] Transform EndSpawn;

    [Header("Position")]
    [SerializeField] float spawnRate;               // 스폰주기
    [SerializeField] float offsetRate;              // 스폰주기 차이

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
            Transform transform = StartSpawn.transform;
            GameObject newEnemy = enemyPrefab;
            newEnemy = Instantiate(enemyPrefab);
            //Vector2 position = StartSpawn.position;
            newEnemy.transform.position = transform.position;
            //newEnemy.transform.position = position;
            rateTime = spawnRate;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Hole")
        {
            Destroy(enemyPrefab);
        }
    }

}
