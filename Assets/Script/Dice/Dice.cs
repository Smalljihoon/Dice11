using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

using Unity.VisualScripting;

using UnityEngine;
using UnityEngine.EventSystems;

public enum Dice_category
{
    None = 0,
    Growth,
    Joker,
    Snow,
    Sun,
    Iron,
    Fire,
}

public class Dice : MonoBehaviour
{
    [SerializeField] GameObject bullet;                              // 총알

    protected List<Bullet> bullets = new List<Bullet>();             // 총알 리스트를 bullets에 담는다 

    [SerializeField]
    protected int damage;                                         // 공격력
    public int level = 0;                                         // 파워
    public int eyes = 1;                                          // 주사위 레벨(눈금)
    //public int cureye;
    //���ݼӵ�
    protected float DPS = 0.7f;                                  // 총알 속도
    public Dice_category category;

    private void Awake()
    {
        var fusion = GetComponent<FusionManager>();
    }

    protected virtual void Start()                                               // 총알 = 오브젝트 풀링
    {
        for (int i = 0; i < eyes; ++i)                                           // 주사위 눈금만큼 반복문
        {
            GameObject bulletGO = Instantiate(bullet, transform);                // 주사위에 총알을 생성 = bulletGO
            bulletGO.SetActive(false);                                           // 발사전-> 총알 비활성화
            Bullet bulletItem = bulletGO.GetComponent<Bullet>();                 // bulletGO에 달린 총알 스크립트 불러오기 = bulletItem
            bulletGO.transform.localPosition = Vector3.zero;                     // 총알은 주사위의 자식 -> 위치를 000으로 하면서 주사위 가운데에 위치함

            bullets.Add(bulletItem);                                             // 생성된 총알을 bullets리스트에 담는다
        }
    }

    public virtual void Skill()
    {

    }

    private void OnDestroy()
    {
        StopAllCoroutines();                            // 총알을 파괴하기 전 모든 코루틴 멈추기

        foreach (var bulletGO in bullets)
        {
            Destroy(bulletGO.gameObject);               // 리스트에 있는 총알 파괴
        }

        bullets.Clear();                                // List.Cleat() : Destroy만 할 경우 잔여 메모리가 남아있기 때문에 잔여 메모리 청소? 개념
    }

    protected virtual void Update()
    {
        DPS -= Time.deltaTime;                                 // DPS 1로 설정해둬서 1초마다 발사
        if (DPS <= 0)
        {
            if (SpawnManager.instance.currentTarget != null)        // SpawnManager에서 생성한 적이 현재 있으면
            {
                StopAllCoroutines();                                // 모든 코루틴 멈추고
                StartCoroutine(Shot());                             // 현재 타겟 적을 향해 발사 코루틴

                DPS = 0.7f;                                      // rateTime이 0이 되었으므로 1로 다시 초기화
            }
        }
        

        // ���ݵ����̸��� �Ѿ� ������ �Ѿ� Ÿ�� ���� 

        // ���� ������ = �ڷ�ƾ���� �ذ� (2�� 3�� ... ������ ����������...)

        // ���̽� ������ ��  �ν���Ƽ����Ʈ �ؼ� ���� ����
    }

    public void SetDiceEye()
    {
        int child_count = this.transform.childCount;
        for (int i = 0; i < child_count; ++i)
        {
            this.transform.GetChild(i).gameObject.SetActive(false);
        }

        if (this.eyes == 2)
        {
            this.transform.GetChild(1).gameObject.SetActive(true);
        }
        else if (this.eyes == 3)
        {
            this.transform.GetChild(2).gameObject.SetActive(true);
        }
        else if (this.eyes == 4)
        {
            this.transform.GetChild(3).gameObject.SetActive(true);
        }
        else if (this.eyes == 5)
        {
            this.transform.GetChild(4).gameObject.SetActive(true);
        }
        else if (this.eyes == 6)
        {
            this.transform.GetChild(5).gameObject.SetActive(true);
        }
        else if (this.eyes == 7)
        {
            this.transform.GetChild(6).gameObject.SetActive(true);
        }
    }

    protected virtual IEnumerator Shot()
    {
        while (true)
        {
            List<GameObject> list = new List<GameObject>();

            foreach (var bullet in bullets)
            {
                if (!bullet.gameObject.activeSelf)
                {
                    list.Add(bullet.gameObject);
                }
            }
            yield return null;

            if (list.Count == bullets.Count)
            {
                break;
            }
        }

        float delay = 0.1f;//0.8f / eyes;

        foreach (var bullet in bullets)
        {
            if (SpawnManager.instance.currentTarget == null)
                continue;

            bullet.gameObject.SetActive(true);

            bullet.transform.localPosition = Vector3.zero;

            bullet.Init(damage, SpawnManager.instance.currentTarget.transform);

            yield return new WaitForSeconds(delay);
        }
    }
}
