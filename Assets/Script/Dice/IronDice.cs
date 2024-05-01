using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronDice : Dice
{
    protected override void Start()
    {
        for (int i = 0; i < eyes; ++i)                                                                // 주사위 눈금만큼 반복문
        {
            GameObject bulletGO = Instantiate(bullet, transform);                // 주사위에 총알을 생성 = bulletGO
            bulletGO.GetComponent<Renderer>().material.color = new Color(71 / 255f, 71 / 255f, 71 / 255f);          // 총알 색상을 눈금 색과 맞춤
            bulletGO.SetActive(false);                                                              // 발사전-> 총알 비활성화
            Bullet bulletItem = bulletGO.GetComponent<Bullet>();              // bulletGO에 달린 총알 스크립트 불러오기 = bulletItem
            bulletGO.transform.localPosition = Vector3.zero;                         // 총알은 주사위의 자식 -> 위치를 000으로 하면서 주사위 가운데에 위치함

            bullets.Add(bulletItem);                                                                 // 생성된 총알을 bullets리스트에 담는다
        }

        category = Dice_category.Iron;

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
