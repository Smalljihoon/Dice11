using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance = null;

   [SerializeField] Spawn spawn;
    private Queue<Enemy> enemys = new Queue<Enemy>();

    [SerializeField] float spawnRate;               // 스폰주기

    public Enemy currentTarget = null;
    private int enemyCount = 30;
    private int genCount = 0;
    float rateTime;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rateTime = spawnRate;
    }

    void Update()
    {
        rateTime -= Time.deltaTime;

        if (rateTime <= 0.0f && genCount < enemyCount)
        {
            enemys.Enqueue(spawn.SpawnEnemy());
            rateTime = spawnRate;
            genCount++;
        }

        if (currentTarget == null && enemys.Count > 0)
        {
            currentTarget = enemys.Dequeue();
        }
    }
}
