using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowDice : Dice
{
    float DPS = 0.6f;
    float typhoonCount = 5f;
    float typhoonfirst = 4f;
    float typhoonsceond = 1f;

    protected override void Start()
    {
        for (int i = 0; i < eyes; ++i)                                                                  // �ֻ��� ���ݸ�ŭ �ݺ���
        {
            GameObject bulletGO = Instantiate(bullet, transform);                                       // �ֻ����� �Ѿ��� ���� = bulletGO
            var bulletColor = bulletGO.GetComponent<Renderer>().material.color;
            bulletColor = new Color(0, 56 / 255f, 77 / 255f);                                           // �Ѿ� ������ ���� ���� ����
            bulletGO.SetActive(false);                                                                  // �߻���-> �Ѿ� ��Ȱ��ȭ
            Bullet bulletItem = bulletGO.GetComponent<Bullet>();                                        // bulletGO�� �޸� �Ѿ� ��ũ��Ʈ �ҷ����� = bulletItem
            bulletGO.transform.localPosition = Vector3.zero;                                            // �Ѿ� ��ġ ����ȭ => ���̽� �߾�

            bullets.Add(bulletItem);                                                                    // ������ �Ѿ��� bullets����Ʈ�� ��´�
        }

        category = Dice_category.Snow;
    }
    // �⺻ ���¿��� 5�ʰ� ������ ��ǳ 1�ܰ� ���ݼӵ� 1.5��, ���ӽð� 4��,
    // 1�ܰ迡�� 5�ʰ� �� ������ ��ǳ 2�ܰ� ���ݼӵ� 2��, ���ӽð� 1��  -�⺻ ���ݷ� 20  -1 �Ŀ��� �� +30

    protected override void Update()
    {
        DPS -= Time.deltaTime; 
        typhoonCount -= Time.deltaTime;
        if (DPS <= 0)
        {
            if (SpawnManager.instance.currentTarget != null)                            // SpawnManager���� ������ ���� ���� ������
            {
                StopAllCoroutines();                                                    // ��� �ڷ�ƾ ���߰�
                StartCoroutine(Shot());                                                 // ���� Ÿ�� ���� ���� �߻� �ڷ�ƾ
                DPS = 0.6f;                                                             
                Debug.Log("�Ϲ� ����");
            }
        }

        if (typhoonCount <= 0) // 1�ܰ� ��ǳ
        {
            StopAllCoroutines();
            DPS = 0.3f;
            typhoonfirst -= Time.deltaTime;
            if (DPS <= 0)
            {
                if (SpawnManager.instance.currentTarget != null)          // SpawnManager���� ������ ���� ���� ������
                {
                    StopAllCoroutines();                                                    // ��� �ڷ�ƾ ���߰�
                    StartCoroutine(Shot());                                                // ���� Ÿ�� ���� ���� �߻� �ڷ�ƾ
                    DPS = 0.3f;                                                                   // rateTime�� 0�� �Ǿ����Ƿ� 1�� �ٽ� �ʱ�ȭ
                    Debug.Log("1�ܰ� ��ǳ");
                }
            }

            if (typhoonfirst <= 0) // 2�ܰ� ��ǳ
            {
                StopAllCoroutines();
                DPS = 0.1f;
                typhoonsceond -= Time.deltaTime;
                if (DPS <= 0)
                {
                    if (SpawnManager.instance.currentTarget != null)          // SpawnManager���� ������ ���� ���� ������
                    {
                        StopAllCoroutines();                                                    // ��� �ڷ�ƾ ���߰�
                        StartCoroutine(Shot());                                                // ���� Ÿ�� ���� ���� �߻� �ڷ�ƾ
                        DPS = 0.1f;                                                                   // rateTime�� 0�� �Ǿ����Ƿ� 1�� �ٽ� �ʱ�ȭ
                        Debug.Log("2�ܰ� ��ǳ");
                    }
                }

                if (typhoonsceond <= 0)
                {
                    StopAllCoroutines();
                    DPS = 0.6f;
                    return;
                }
            }
        }
    }
    // �� �ܴ� Dice�� ����
}
