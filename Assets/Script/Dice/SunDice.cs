using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunDice : Dice
{
    protected override void Start()
    {
        // �¾���̽� 3, 5, 7, 9���� �ִٸ� Ȱ��ȭ : sundice_off ��Ȱ��ȭ
        // �¾���̽� 1, 2, 4, 6, 8, 10...���� �ִٸ� ��Ȱ��ȭ : sundice_off Ȱ��ȭ + on�ڽ��� ���� ��Ȱ��ȭ �ش� off ���� Ȱ��ȭ
        base.Start();
        category = Dice_category.Sun;
        bulletColor = new Color(132 / 255f, 29 / 255f, 25 / 255f); 
    }
}
