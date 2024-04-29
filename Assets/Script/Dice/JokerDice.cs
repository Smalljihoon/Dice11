using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokerDice : Dice
{
    protected override void Start()
    {
        for (int i = 0; i < eyes; ++i)                                                                // 주사위 눈금만큼 반복문
        {
            GameObject bulletGO = Instantiate(bullet, transform);                // 주사위에 총알을 생성 = bulletGO
            bulletGO.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);          // 총알 색상을 눈금 색과 맞춤
            bulletGO.SetActive(false);                                                              // 발사전-> 총알 비활성화
            Bullet bulletItem = bulletGO.GetComponent<Bullet>();              // bulletGO에 달린 총알 스크립트 불러오기 = bulletItem
            bulletGO.transform.localPosition = Vector3.zero;                         // 총알은 주사위의 자식 -> 위치를 000으로 하면서 주사위 가운데에 위치함

            bullets.Add(bulletItem);                                                                 // 생성된 총알을 bullets리스트에 담는다
        }

        category = Dice_category.Joker;
    }
}
