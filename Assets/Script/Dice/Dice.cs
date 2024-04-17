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
    Iron
}

public class Dice : MonoBehaviour
{
    [SerializeField] GameObject bullet;                              // 총알 오브젝트

   protected List<Bullet> bullets = new List<Bullet>();              // bullets 리스트

    [SerializeField]
    protected int damage;                                           // 공격력
    public float level = 1;                                         // 다이스 눈금 레벨
    //공격속도
    protected float rateTime = 1f;                                  // 발사 주기
    protected Dice_category category;
    
    private void Start()
    {
        for (int i = 0; i < level; ++i)                                  // 다이스 눈금 갯수만큼 for문 돌아감
        {
            GameObject bulletGO = Instantiate(bullet, transform);        // bullet을 dice의 위치에서 생성한 것을 bulletGameObject로 하겠다           
            bulletGO.SetActive(false);                                   // bulletGO를 보이지 않게 함 ( 발사 전이기때문 )
            Bullet bulletItem = bulletGO.GetComponent<Bullet>();         // bulletGO에 달린 Bullet 스크립트를 불러오는걸 bulletItem이라고 정의
            bulletGO.transform.localPosition = Vector3.zero;             // BulletGO의 로컬포지션을 월드포지션 (0,0,0)으로

            bullets.Add(bulletItem);                                     // 리스트 bullets에 bulletItem에 추가
        }
    }

    public virtual void Skill()
    {

    }

    private void OnDestroy()
    {
        StopAllCoroutines();                            // 모든 코루틴 중지

        foreach (var bulletGO in bullets)
        {
            Destroy(bulletGO.gameObject);               // bullets에 담긴 총알 오브젝트 Destroy
        }

        bullets.Clear();                                // bullets 청소~
    }

    protected virtual void Update()
    {
        rateTime -= Time.deltaTime;                                 // 발사 주기에 따라 주사위 발사 속도가 달라짐
        if (rateTime <= 0)
        {
            if (SpawnManager.instance.currentTarget != null)        // 현재 타겟이 있으면
            {
                StopAllCoroutines();                                // 모든 코루틴 중지
                StartCoroutine(Shot());                             // 발사 코루틴 시작

                rateTime = 1f;                                      // 현재 발사주기 1초로 해뒀기에 다시 1초로 초기화
            }
        }

        
        // 공격딜레이마다 총알 생성및 총알 타겟 지정 

        // 공격 딜레이 = 코루틴으로 해결 (2성 3성 ... 눈금이 높아질수록...)

        // 다이스 생성할 때  인스턴티에이트 해서 따로 저장

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

        float delay = 0.8f / level;

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
