using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunDice : Dice
{
    [SerializeField] GameObject Tornadoprefab;      // 다이스 활성화 효과 프리팹
    private int ActiveDamage;                                   // 활성화 됐을 때 데미지
    private int BasicDamage;                                    // 기본 데미지 저장
    private SpriteRenderer Sunrenderer;
    private bool isActive = false;

    public Sprite SundiceOn;                    // 활성화 이미지
    public Sprite SundiceOff;                   // 비활성화 이미지
    private GameObject tornado;             // 프리팹 저장 변수

    // 태양다이스 3, 5, 7, 9,11,13,15개가 있다면 활성화 : 활성화 이미지 + 눈금 총알 색상 132,29,25
    // 태양다이스 1, 2, 4, 6, 8, 10...개가 있다면 비활성화  : 비활성화 이미지 + 눈금 총알 색상 69,70,69
    // 활성화 눈금 색상 : 132,29,25
    // 비활성화 눈금 색상 : 69,70,69
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
