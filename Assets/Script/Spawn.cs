using UnityEngine;

public class Spawn : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] GameObject enemyPrefab;
    //[SerializeField] GameObject EndSpawn;

    [Header("Transform")]
    [SerializeField] Transform StartSpawn;

    void Start()
    {
        StartSpawn = GetComponent<Transform>();
    }

    public Enemy SpawnEnemy(int enemyID)
    {
            Transform transform = StartSpawn.transform;
            GameObject newEnemy = enemyPrefab;
            newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.position = transform.position;
            var enemy = newEnemy.GetComponent<Enemy>();

            // ���� ������ ���� 
            // ���� ���� �����Ŵ� ���ӸŴ����� ���������� ���ɼ��� ���� 
            // �� ü�� ���� 
            enemy.Init((SpawnManager.instance.Round - 1) * 100 + 200, enemyID);             // (���� - 1) * 100 + 200
            return enemy;
    }
}
