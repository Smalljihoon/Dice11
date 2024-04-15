using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditorInternal;

public class Spawn : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] GameObject enemyPrefab;
    //[SerializeField] GameObject EndSpawn;

    [Header("Transform")]
    [SerializeField] Transform StartSpawn;

    //[Header("Position")]
    //[SerializeField] float offsetRate;              // 스폰주기 차이

    void Start()
    {
        StartSpawn = GetComponent<Transform>();
        //EndSpawn = GetComponent<GameObject>();
    }

    public Enemy SpawnEnemy(int enemyID)
    {
            Transform transform = StartSpawn.transform;
            GameObject newEnemy = enemyPrefab;
            newEnemy = Instantiate(enemyPrefab);
            //Vector2 position = StartSpawn.position;
            newEnemy.transform.position = transform.position;
            //newEnemy.transform.position = position;
            var enemy = newEnemy.GetComponent<Enemy>();

            // 라운드 레벨에 따라서 
            // 라운드 레벨 같은거는 게임매니저가 가지고있을 가능성이 높음 
            // 몹 체력 조절 
            enemy.Init((SpawnManager.instance.Round - 1) * 100 + 200, enemyID);             // (라운드 - 1) * 100 + 200
            return enemy;
    }
}
