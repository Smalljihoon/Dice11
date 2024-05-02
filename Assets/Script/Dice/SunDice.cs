using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunDice : Dice
{
    protected override void Start()
    {
        // 태양다이스 3, 5, 7, 9개가 있다면 활성화 : sundice_off 비활성화
        // 태양다이스 1, 2, 4, 6, 8, 10...개가 있다면 비활성화 : sundice_off 활성화 + on자식의 눈금 비활성화 해당 off 눈금 활성화
        base.Start();
        category = Dice_category.Sun;
        bulletColor = new Color(132 / 255f, 29 / 255f, 25 / 255f); 
    }
}
