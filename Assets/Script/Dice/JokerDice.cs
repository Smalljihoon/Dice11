using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokerDice : Dice
{
    protected override void Start()
    {
        for (int i = 0; i < eyes; ++i)                                                                // �ֻ��� ���ݸ�ŭ �ݺ���
        {
            GameObject bulletGO = Instantiate(bullet, transform);                // �ֻ����� �Ѿ��� ���� = bulletGO
            bulletGO.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);          // �Ѿ� ������ ���� ���� ����
            bulletGO.SetActive(false);                                                              // �߻���-> �Ѿ� ��Ȱ��ȭ
            Bullet bulletItem = bulletGO.GetComponent<Bullet>();              // bulletGO�� �޸� �Ѿ� ��ũ��Ʈ �ҷ����� = bulletItem
            bulletGO.transform.localPosition = Vector3.zero;                         // �Ѿ��� �ֻ����� �ڽ� -> ��ġ�� 000���� �ϸ鼭 �ֻ��� ����� ��ġ��

            bullets.Add(bulletItem);                                                                 // ������ �Ѿ��� bullets����Ʈ�� ��´�
        }

        category = Dice_category.Joker;
    }
}
