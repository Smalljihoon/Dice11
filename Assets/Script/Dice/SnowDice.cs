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
    // �⺻ ���¿��� 5�ʰ� ������ ��ǳ 1�ܰ� ���ݼӵ� 1.5��, ���ӽð� 4��,
    // 1�ܰ迡�� 5�ʰ� �� ������ ��ǳ 2�ܰ� ���ݼӵ� 2��, ���ӽð� 1��  -�⺻ ���ݷ� 20  -1 �Ŀ��� �� +30


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
            //1�ܰ�
        }
        else if (typhoonCount > 1 && typhoonCount < 5)
        {
            currentTyphoon = 1;
            //2�ܰ�
        }
        else if (typhoonCount < 1 && typhoonCount > 0)
        {
            currentTyphoon = 2;
            //3�ܰ�
        }
        else if (typhoonCount < 0)
        {
            typhoonCount = 10;
            return;
        }

        if (DPS <= 0)
        {
            if (SpawnManager.instance.currentTarget != null)                            // SpawnManager���� ������ ���� ���� ������
            {
                StopAllCoroutines();
                StartCoroutine(Shot());                                                 // ���� Ÿ�� ���� ���� �߻� �ڷ�ƾ
                DPS = typhoonTimes[currentTyphoon];
                Debug.Log("�Ϲ� ����");
            }
        }
    }
    // �� �ܴ� Dice�� ����
}
