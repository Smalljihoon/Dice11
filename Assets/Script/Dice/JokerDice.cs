using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokerDice : Dice
{
    protected override void Start()
    {
        // 조커 다이스의 능력은 같은 눈금이라면 조합을 통해 피격 다이스와 동일하게 바뀌는 능력이므로 FusionManager에서 처리함
        // 총알은 오브젝트 풀링
        category = Dice_category.Joker;

        for (int i = 0; i < eyes; ++i)                                                                // 주사위 눈금만큼 반복문
        {
            GameObject bulletGO = Instantiate(bullet, transform);                                     // 주사위에 총알을 생성 = bulletGO

            var bulletColor = bulletGO.GetComponent<Renderer>().material.color;
            bulletColor = new Color(Random.value, Random.value, Random.value);                        // 총알 색상을 눈금 색과 맞춤
            
            bulletGO.SetActive(false);                                                                // 발사전 -> 총알 비활성화
            Bullet bulletItem = bulletGO.GetComponent<Bullet>();                                      // bulletGO에 달린 총알 스크립트 불러오기 = bulletItem
            bulletGO.transform.localPosition = Vector3.zero;                                          // 총알 위치 정렬화 => 다이스 중앙

            bullets.Add(bulletItem);                                                                 // 생성된 총알을 bullets리스트에 담는다
        }
    }
    
    // 이 외는 Dice와 동일
}
