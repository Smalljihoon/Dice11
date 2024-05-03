using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunDice : Dice
{
    [SerializeField] 

    protected override void Start()
    {
        // �¾���̽� 3, 5, 7, 9���� �ִٸ� Ȱ��ȭ : Ȱ��ȭ �̹��� + ���� �Ѿ� ���� 132,29,25
        // �¾���̽� 1, 2, 4, 6, 8, 10...���� �ִٸ� ��Ȱ��ȭ  : ��Ȱ��ȭ �̹��� + ���� �Ѿ� ���� 69,70,69
        // Ȱ��ȭ ���� ���� : 132,29,25
        // ��Ȱ��ȭ ���� ���� : 69,70,69
        base.Start();
        category = Dice_category.Sun;
        bulletColor = new Color(132 / 255f, 29 / 255f, 25 / 255f); 
    }
}
