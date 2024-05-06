using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunDice : Dice
{
    [SerializeField] GameObject Tornadoprefab;      // ���̽� Ȱ��ȭ ȿ�� ������
    private int ActiveDamage;                                   // Ȱ��ȭ ���� �� ������
    private int BasicDamage;                                    // �⺻ ������ ����
    private SpriteRenderer Sunrenderer;
    private bool isActive = false;

    public Sprite SundiceOn;                    // Ȱ��ȭ �̹���
    public Sprite SundiceOff;                   // ��Ȱ��ȭ �̹���
    private GameObject tornado;             // ������ ���� ����

    // �¾���̽� 3, 5, 7, 9,11,13,15���� �ִٸ� Ȱ��ȭ : Ȱ��ȭ �̹��� + ���� �Ѿ� ���� 132,29,25
    // �¾���̽� 1, 2, 4, 6, 8, 10...���� �ִٸ� ��Ȱ��ȭ  : ��Ȱ��ȭ �̹��� + ���� �Ѿ� ���� 69,70,69
    // Ȱ��ȭ ���� ���� : 132,29,25
    // ��Ȱ��ȭ ���� ���� : 69,70,69
    protected override void Start()
    {
        BasicDamage = damage;
        bulletColor = new Color(69 / 255f, 70 / 255f, 69 / 255f);
        Sunrenderer = GetComponent<SpriteRenderer>();
        base.Start();
    }

    protected override void Update()
    {
        List<Dice> sundice = GameManager.instance.spawner.dices.FindAll(x => x.category == Dice_category.Sun);
        Debug.Log(sundice.Count);

        if (sundice.Count == 3 || sundice.Count == 5 || sundice.Count == 7 || sundice.Count == 9 || sundice.Count == 11 || sundice.Count == 13 || sundice.Count == 15)
        {
            DiceOn();
        }
        else
        {
            DiceOff();
        }

        base.Update();
    }

    private void DiceOn()
    {
        if (!isActive)
        {
            Sunrenderer.sprite = SundiceOn;
            tornado =  Instantiate(Tornadoprefab, this.transform);
            ActiveDamage = damage * 2;
            damage = ActiveDamage;
            isActive = true;
            bulletColor = new Color(132 / 255f, 29 / 255f, 25 / 255f);

        }

    }

    private void DiceOff()
    {
        if (isActive)
        {
            Destroy(tornado);
            Sunrenderer.sprite = SundiceOff;
            damage = BasicDamage;
            isActive = false;
            bulletColor = new Color(69 / 255f, 70 / 255f, 69 / 255f);

        }
    }
}
