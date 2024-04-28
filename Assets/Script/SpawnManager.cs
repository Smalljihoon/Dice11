using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance = null;         // 싱글톤
    private Queue<Enemy> enemys = new Queue<Enemy>();   // 맨 앞 적을 공격해야하기에 Queue로 맨앞타겟 잡을 것

    [SerializeField] Image[] LifeImage;                 // 빨간 하트 이미지
    [SerializeField] Spawn spawn;
    [SerializeField] float spawnRate;                   // 스폰주기
    [SerializeField] TMP_Text roundtext;                // 라운드 tmp text
    [SerializeField] GameObject Alarm;                  //
    [SerializeField] Transform alarmParent;             //

    public Enemy currentTarget = null;                  // 현재 타겟 (queue의 첫번째)
    public int enemyCount = 30;                        // 라운드당 스폰 마릿수
    public int Round = 1;                               // 라운드
    public bool isDead;
    public bool isClear = false;
   
    private int life = 3;
    private int genCount = 0;
    float rateTime;                                     // 스폰주기
    float waitTime = 10;                            // 대기 시간


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rateTime = spawnRate;                           // 컴포넌트에서 입력한 spawnRate을 rateTime으로 정의 
    }

    void Update()
    {
        if (isClear && genCount == enemyCount)
        {
            Alarm.SetActive(true);
            roundtext.text = Round.ToString() + " Round";

            waitTime -= Time.deltaTime;
            // 10초 카운팅
            if (waitTime <= 0)
            {
                isClear = false;
                genCount = 0;
                Round++;
                Alarm.SetActive(false);
                //Destroy(roundtext);
                Debug.Log("라운드 : " +Round);
            }

            // 라운드 몇 띄우기
        }
        else// if(!isClear)
        {
            rateTime -= Time.deltaTime;                     // Time.deltaTime과의 연산을 통해 스폰주기 (적 간격)

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
            //게임오버 
        }
    }
}
