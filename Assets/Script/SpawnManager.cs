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
    public Queue<Enemy> enemys = new Queue<Enemy>();   // �� �� ���� �����ؾ��ϱ⿡ Queue�� �Ǿ�Ÿ�� ���� ��

    [SerializeField] Image[] LifeImage;                 // ���� ��Ʈ �̹���
    [SerializeField] Spawn spawn;                       // Spawn ��ũ��Ʈ �ν��Ͻ�
    [SerializeField] float spawnRate;                   // �����ֱ�

    [SerializeField] public TMP_Text roundtext;                // ���� tmp text
    [SerializeField] public GameObject Alarm;                  // ���� �˶�
    [SerializeField] Transform alarmParent;             //
    [SerializeField] GameObject Lose;
    [SerializeField] GameObject Warn;

    public Enemy currentTarget = null;                  // ���� Ÿ�� (queue�� ù��°)
    public int enemyCount = 30;                        // ����� ���� ������
    public int Round = 1;                               // ����
    public bool isDead;
    public bool isClear = false;

    private int life = 3;
    private int genCount = 0;
    float rateTime;                                     // �����ֱ�
    float waitTime = 10;                            // ��� �ð�

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
                waitTime = 10;
                isClear = false;
                genCount = 0;
                Alarm.SetActive(false);
                Debug.Log("���� : " + Round);
            }
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
        // ü���� 0���� ũ�� ü�� -1
        if (life > 0)
        {
            LifeImage[life - 1].enabled = false;
            life--;
            SoundManager.instance.HpDown();
            if (life == 1)
            {
                SoundManager.instance.Warning();
                Warn.SetActive(true);
                Invoke("SetWarn", 3f);
            }
        }
        // ü���� 0�̸� 3�ʵ� �κ�ȭ�� = ���ӿ���
        if (life == 0)
        {
            Lose.SetActive(true);

            Invoke("SceneChange", 3f);
        }
    }

    public void SetWarn()
    {
        Warn.SetActive(false);
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("start");
    }
}
