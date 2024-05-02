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

        for (int i = 0; i < eyes; ++i)                                                                // �ֻ��� ���ݸ�ŭ �ݺ���
        {
            GameObject bulletGO = Instantiate(bullet, transform);                                     // �ֻ����� �Ѿ��� ���� = bulletGO

            var bulletColor = bulletGO.GetComponent<Renderer>().material.color;
            bulletColor = new Color(Random.value, Random.value, Random.value);                        // �Ѿ� ������ ���� ���� ����
            
            bulletGO.SetActive(false);                                                                // �߻��� -> �Ѿ� ��Ȱ��ȭ
            Bullet bulletItem = bulletGO.GetComponent<Bullet>();                                      // bulletGO�� �޸� �Ѿ� ��ũ��Ʈ �ҷ����� = bulletItem
            bulletGO.transform.localPosition = Vector3.zero;                                          // �Ѿ� ��ġ ����ȭ => ���̽� �߾�

            bullets.Add(bulletItem);                                                                 // ������ �Ѿ��� bullets����Ʈ�� ��´�
        }
    }
    
    // �� �ܴ� Dice�� ����
}
