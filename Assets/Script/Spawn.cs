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
    //[SerializeField] float offsetRate;              // �����ֱ� ����

    bool isSpawn;

    void Start()
    {
        StartSpawn = GetComponent<Transform>();
        EndSpawn = GetComponent<GameObject>();
    }

    public Enemy SpawnEnemy()
    {
        {
            Transform transform = StartSpawn.transform;
            GameObject newEnemy = enemyPrefab;
            newEnemy = Instantiate(enemyPrefab);
            //Vector2 position = StartSpawn.position;
            newEnemy.transform.position = transform.position;
            //newEnemy.transform.position = position;
            var enemy = newEnemy.GetComponent<Enemy>();

            // ���� ������ ���� 
            // ���� ���� �����Ŵ� ���ӸŴ����� ���������� ���ɼ��� ���� 
            // �� ü�� ���� 
            enemy.Init(Random.Range(100, 300));
            return enemy;
        }
    }


}
