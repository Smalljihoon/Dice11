using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance = null;         // �̱���
    private Queue<Enemy> enemys = new Queue<Enemy>();   // �� �� ���� �����ؾ��ϱ⿡ Queue�� �Ǿ�Ÿ�� ���� ��

    [SerializeField] Image[] LifeImage;                 // ���� ��Ʈ �̹���
    [SerializeField] Spawn spawn;                       // Spawn ��ũ��Ʈ �ν��Ͻ�
    [SerializeField] float spawnRate;                   // �����ֱ�

    [SerializeField] public TMP_Text roundtext;                // ���� tmp text
    [SerializeField] public GameObject Alarm;                  //
    [SerializeField] Transform alarmParent;             //
    [SerializeField] GameObject Lose;

    public Enemy currentTarget = null;                  // ���� Ÿ�� (queue�� ù��°)
    public int enemyCount = 30;                        // ����� ���� ������
    public int Round = 1;                               // ����
    public bool isDead;
    public bool isClear = false;

    private int life = 3;
    private int genCount = 0;
    float rateTime;                                     // �����ֱ�
    float waitTime = 10;                            // ��� �ð�
    float wait = 3f;
    float stop;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rateTime = spawnRate;                           // ������Ʈ���� �Է��� spawnRate�� rateTime���� ���� 
        stop = wait;
    }

    void Update()
    {


        if (isClear && genCount == enemyCount)
        {
            waitTime -= Time.deltaTime;
            // 10�� ī����
            if (waitTime <= 0)
            {
                waitTime = 10;
                isClear = false;
                genCount = 0;
                Alarm.SetActive(false);
                Debug.Log("���� : " + Round);
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
            Lose.SetActive(true);

            Invoke("SceneChange", 3f);
            //���ӿ��� 
        }
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("start");

    }
}
