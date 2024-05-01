using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthDice : Dice
{
    [SerializeField] DiceSpawner spawner;
    protected float DPS = 2f;
    private float Remaining = 5f;

    private void Awake()
    {
        spawner = FindAnyObjectByType<DiceSpawner>();
    }

    protected override void Start()
    {
        for (int i = 0; i < eyes; ++i)                                                                // �ֻ��� ���ݸ�ŭ �ݺ���
        {
            GameObject bulletGO = Instantiate(bullet, transform);                // �ֻ����� �Ѿ��� ���� = bulletGO
            bulletGO.GetComponent<Renderer>().material.color = new Color(48 / 255f, 22 / 255f, 85 / 255f);          // �Ѿ� ������ ���� ���� ����
            bulletGO.SetActive(false);                                                              // �߻���-> �Ѿ� ��Ȱ��ȭ
            Bullet bulletItem = bulletGO.GetComponent<Bullet>();              // bulletGO�� �޸� �Ѿ� ��ũ��Ʈ �ҷ����� = bulletItem
            bulletGO.transform.localPosition = Vector3.zero;                         // �Ѿ��� �ֻ����� �ڽ� -> ��ġ�� 000���� �ϸ鼭 �ֻ��� ����� ��ġ��

            bullets.Add(bulletItem);                                                                 // ������ �Ѿ��� bullets����Ʈ�� ��´�
        }

        category = Dice_category.Growth;

    }

    protected override void Update()
    {
        DPS -= Time.deltaTime;
        Remaining -= Time.deltaTime;
        // DPS 1�� �����صּ� 1�ʸ��� �߻�
        if (DPS <= 0)
        {
            if (SpawnManager.instance.currentTarget != null)          // SpawnManager���� ������ ���� ���� ������
            {
                StopAllCoroutines();                                                    // ��� �ڷ�ƾ ���߰�
                StartCoroutine(Shot());                                                // ���� Ÿ�� ���� ���� �߻� �ڷ�ƾ

                DPS = 2f;                                                                   // rateTime�� 0�� �Ǿ����Ƿ� 1�� �ٽ� �ʱ�ȭ
            }
        }

        // 15�� �ڿ� ���� �������� ������ ���̽��� ����
        if (Remaining <= 0)
        {
            GrowthUp();
        }
    }

    private void GrowthUp()
    {
        int change = this.eyes;
        change++;
        GameObject temp = spawner.dice[Random.Range(0, spawner.dice.Length)];
        GameObject diceGO = Instantiate(temp, gameObject.transform.parent);
        var Redice = diceGO.GetComponent<Dice>();
        Redice.eyes = change;
        Redice.SetDiceEye();
        Destroy(gameObject);
        Remaining = 5f;
    }
}
