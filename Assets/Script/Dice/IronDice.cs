using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronDice : Dice
{
    protected override void Start()
    {
        for (int i = 0; i < eyes; ++i)                                                                // �ֻ��� ���ݸ�ŭ �ݺ���
        {
            GameObject bulletGO = Instantiate(bullet, transform);                // �ֻ����� �Ѿ��� ���� = bulletGO
            bulletGO.GetComponent<Renderer>().material.color = new Color(71 / 255f, 71 / 255f, 71 / 255f);          // �Ѿ� ������ ���� ���� ����
            bulletGO.SetActive(false);                                                              // �߻���-> �Ѿ� ��Ȱ��ȭ
            Bullet bulletItem = bulletGO.GetComponent<Bullet>();              // bulletGO�� �޸� �Ѿ� ��ũ��Ʈ �ҷ����� = bulletItem
            bulletGO.transform.localPosition = Vector3.zero;                         // �Ѿ��� �ֻ����� �ڽ� -> ��ġ�� 000���� �ϸ鼭 �ֻ��� ����� ��ġ��

            bullets.Add(bulletItem);                                                                 // ������ �Ѿ��� bullets����Ʈ�� ��´�
        }

        category = Dice_category.Iron;

    }

    protected override void Update()
    {
        DPS -= Time.deltaTime;                                                       // DPS 1�� �����صּ� 1�ʸ��� �߻�
        if (DPS <= 0)
        {
            if (SpawnManager.instance.enemys != null)          // SpawnManager���� ������ ���� ���� ������
            {
                StopAllCoroutines();                                                    // ��� �ڷ�ƾ ���߰�
                StartCoroutine(Shot());                                                // ���� Ÿ�� ���� ���� �߻� �ڷ�ƾ

                DPS = 0.7f;                                                                   // rateTime�� 0�� �Ǿ����Ƿ� 1�� �ٽ� �ʱ�ȭ
            }
        }


    }

    protected override IEnumerator Shot()
    {
        while (true)
        {
            List<GameObject> list = new List<GameObject>();

            foreach (var bullet in bullets)
            {
                if (!bullet.gameObject.activeSelf)
                {
                    list.Add(bullet.gameObject);
                }
            }
            yield return null;

            if (list.Count == bullets.Count)
            {
                break;
            }
        }

        float delay = 0.1f;//0.8f / eyes;

        foreach (var bullet in bullets)
        {
            if (SpawnManager.instance.currentTarget == null)
                continue;

            bullet.gameObject.SetActive(true);

            bullet.transform.localPosition = Vector3.zero;

            bullet.Init(damage, SpawnManager.instance.currentTarget.transform);

            yield return new WaitForSeconds(delay);
        }
    }
}
