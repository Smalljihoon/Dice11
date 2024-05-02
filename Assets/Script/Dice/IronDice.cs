using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronDice : Dice
{
    protected override void Start()
    {
        base.Start();
        bulletColor = new Color(71 / 255f, 71 / 255f, 71 / 255f);          // 총알 색상을 눈금 색과 맞춤
    }

    protected override void Update()
    {
        DPS -= Time.deltaTime;                                                       // DPS 1로 설정해둬서 1초마다 발사
        if (DPS <= 0)
        {
            if (SpawnManager.instance.enemys != null)          // SpawnManager에서 생성한 적이 현재 있으면
            {
                StopAllCoroutines();                                                    // 모든 코루틴 멈추고
                StartCoroutine(Shot());                                                // 현재 타겟 적을 향해 발사 코루틴

                DPS = 0.7f;                                                                   // rateTime이 0이 되었으므로 1로 다시 초기화
            }
        }


    }

    protected override IEnumerator Shot()
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
