using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowDice : Dice
{
    float DPS = 0.6f;
    float typhoonCount = 5f;
    float typhoonfirst = 4f;
    float typhoonsceond = 1f;

    protected override void Start()
    {
        for (int i = 0; i < eyes; ++i)                                                                  // 주사위 눈금만큼 반복문
        {
            GameObject bulletGO = Instantiate(bullet, transform);                                       // 주사위에 총알을 생성 = bulletGO
            var bulletColor = bulletGO.GetComponent<Renderer>().material.color;
            bulletColor = new Color(0, 56 / 255f, 77 / 255f);                                           // 총알 색상을 눈금 색과 맞춤
            bulletGO.SetActive(false);                                                                  // 발사전-> 총알 비활성화
            Bullet bulletItem = bulletGO.GetComponent<Bullet>();                                        // bulletGO에 달린 총알 스크립트 불러오기 = bulletItem
            bulletGO.transform.localPosition = Vector3.zero;                                            // 총알 위치 정렬화 => 다이스 중앙

            bullets.Add(bulletItem);                                                                    // 생성된 총알을 bullets리스트에 담는다
        }

        category = Dice_category.Snow;
    }
    // 기본 상태에서 5초가 지나면 강풍 1단계 공격속도 1.5배, 지속시간 4초,
    // 1단계에서 5초가 더 지나면 강풍 2단계 공격속도 2배, 지속시간 1초  -기본 공격력 20  -1 파워업 당 +30

    protected override void Update()
    {
        DPS -= Time.deltaTime; 
        typhoonCount -= Time.deltaTime;
        if (DPS <= 0)
        {
            if (SpawnManager.instance.currentTarget != null)                            // SpawnManager에서 생성한 적이 현재 있으면
            {
                StopAllCoroutines();                                                    // 모든 코루틴 멈추고
                StartCoroutine(Shot());                                                 // 현재 타겟 적을 향해 발사 코루틴
                DPS = 0.6f;                                                             
                Debug.Log("일반 공격");
            }
        }

        if (typhoonCount <= 0) // 1단계 태풍
        {
            StopAllCoroutines();
            DPS = 0.3f;
            typhoonfirst -= Time.deltaTime;
            if (DPS <= 0)
            {
                if (SpawnManager.instance.currentTarget != null)          // SpawnManager에서 생성한 적이 현재 있으면
                {
                    StopAllCoroutines();                                                    // 모든 코루틴 멈추고
                    StartCoroutine(Shot());                                                // 현재 타겟 적을 향해 발사 코루틴
                    DPS = 0.3f;                                                                   // rateTime이 0이 되었으므로 1로 다시 초기화
                    Debug.Log("1단계 태풍");
                }
            }

            if (typhoonfirst <= 0) // 2단계 태풍
            {
                StopAllCoroutines();
                DPS = 0.1f;
                typhoonsceond -= Time.deltaTime;
                if (DPS <= 0)
                {
                    if (SpawnManager.instance.currentTarget != null)          // SpawnManager에서 생성한 적이 현재 있으면
                    {
                        StopAllCoroutines();                                                    // 모든 코루틴 멈추고
                        StartCoroutine(Shot());                                                // 현재 타겟 적을 향해 발사 코루틴
                        DPS = 0.1f;                                                                   // rateTime이 0이 되었으므로 1로 다시 초기화
                        Debug.Log("2단계 태풍");
                    }
                }

                if (typhoonsceond <= 0)
                {
                    StopAllCoroutines();
                    DPS = 0.6f;
                    return;
                }
            }
        }
    }
    // 이 외는 Dice와 동일
}
