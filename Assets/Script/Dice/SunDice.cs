using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunDice : Dice
{
    [SerializeField] 

    protected override void Start()
    {
        // 태양다이스 3, 5, 7, 9개가 있다면 활성화 : 활성화 이미지 + 눈금 총알 색상 132,29,25
        // 태양다이스 1, 2, 4, 6, 8, 10...개가 있다면 비활성화  : 비활성화 이미지 + 눈금 총알 색상 69,70,69
        // 활성화 눈금 색상 : 132,29,25
        // 비활성화 눈금 색상 : 69,70,69
        base.Start();
        category = Dice_category.Sun;
        bulletColor = new Color(132 / 255f, 29 / 255f, 25 / 255f); 
    }
}
