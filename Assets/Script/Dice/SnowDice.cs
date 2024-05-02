using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowDice : Dice
{
    float typhoonCount = 10f;
    int currentTyphoon = 0;
    float[] typhoonTimes = new float[3];

    protected override void Start()
    {
        base.Start();
        bulletColor = new Color(0, 56 / 255f, 77 / 255f);
        DPS = 0.6f;
        oriDPS = 0.6f;
        typhoonTimes[0] = 0.6f;
        typhoonTimes[1] = 0.3f;
        typhoonTimes[2] = 0.1f;

    }
    // 기본 상태에서 5초가 지나면 강풍 1단계 공격속도 1.5배, 지속시간 4초,
    // 1단계에서 5초가 더 지나면 강풍 2단계 공격속도 2배, 지속시간 1초  -기본 공격력 20  -1 파워업 당 +30


    protected override void OnDestroy()
    {
        base.OnDestroy();
        StopAllCoroutines();
    }
    protected override void Update()
    {
        DPS -= Time.deltaTime;
        typhoonCount -= Time.deltaTime;

        if (typhoonCount > 5)
        {
            currentTyphoon = 0;
            //1단계
        }
        else if (typhoonCount > 1 && typhoonCount < 5)
        {
            currentTyphoon = 1;
            //2단계
        }
        else if (typhoonCount < 1 && typhoonCount > 0)
        {
            currentTyphoon = 2;
            //3단계
        }
        else if (typhoonCount < 0)
        {
            typhoonCount = 10;
            return;
        }

        if (DPS <= 0)
        {
            if (SpawnManager.instance.currentTarget != null)                            // SpawnManager에서 생성한 적이 현재 있으면
            {
                StopAllCoroutines();
                StartCoroutine(Shot());                                                 // 현재 타겟 적을 향해 발사 코루틴
                DPS = typhoonTimes[currentTyphoon];
                Debug.Log("일반 공격");
            }
        }
    }
    // 이 외는 Dice와 동일
}
