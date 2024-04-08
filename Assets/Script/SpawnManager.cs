using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance = null;         // �̱���
    private Queue<Enemy> enemys = new Queue<Enemy>();   // �� �� ���� �����ؾ��ϱ⿡ Queue�� �Ǿ�Ÿ�� ���� ��

    [SerializeField] Image[] LifeImage;                 // ���� ��Ʈ �̹���
    [SerializeField] Spawn spawn;
    [SerializeField] float spawnRate;                   // �����ֱ�


    public Enemy currentTarget = null;                  // ���� Ÿ�� (queue�� ù��°)
    public int enemyCount = 30;                        // ����� ���� ������
    public int Round = 1;                               // ����
    public bool isDead;
    public bool isClear = false;
   
    private int life = 3;
    private int genCount = 0;
    float rateTime;                                     // �����ֱ�
    float waitTime = 10;                                // ��� �ð�


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rateTime = spawnRate;                           // ������Ʈ���� �Է��� spawnRate�� rateTime���� ���� 
    }

    void Update()
    {
        if (isClear && genCount == enemyCount)
        {

            waitTime -= Time.deltaTime;
            // 10�� ī����
            if (waitTime <= 0)
            {
                isClear = false;
                genCount = 0;
                Round++;
            }
            // ���� �� ����
        }
        else// if(!isClear)
        {
            rateTime -= Time.deltaTime;                     // Time.deltaTime���� ������ ���� �����ֱ� (�� ����)

            if (rateTime <= 0.0f && genCount < enemyCount)
            {
                enemys.Enqueue(spawn.SpawnEnemy(genCount));
                rateTime = spawnRate;
                genCount++;
            }

            if (currentTarget == null && enemys.Count > 0)
            {
                currentTarget = enemys.Dequeue();
            }
        }



    }

    public void LifeDown()
    {
        if (life > 0)
        {
            LifeImage[life - 1].enabled = false;
            life--;
        }

        if (life == 0)
        {
            //���ӿ��� 
        }
    }
}
