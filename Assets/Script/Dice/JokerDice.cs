using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokerDice : Dice
{
    protected override void Start()
    {
        // ��Ŀ ���̽��� �ɷ��� ���� �����̶�� ������ ���� �ǰ� ���̽��� �����ϰ� �ٲ�� �ɷ��̹Ƿ� FusionManager���� ó����
        // �Ѿ��� ������Ʈ Ǯ��
        category = Dice_category.Joker;
        bulletColor = new Color(Random.value, Random.value, Random.value);                        // �Ѿ� ������ ���� ���� ����
    }
    
    // �� �ܴ� Dice�� ����
}
