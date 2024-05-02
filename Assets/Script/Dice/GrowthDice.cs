using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthDice : Dice
{
    private float Remaining = 5f;

    protected override void Start()
    {
        base.Start();
        bulletColor = new Color(48 / 255f, 22 / 255f, 85 / 255f);
        DPS = 2.0f;
        oriDPS = 2.0f;
    }

    protected override void Update()
    {
        base.Update();
        Remaining -= Time.deltaTime;
        // 15초 뒤에 다음 눈금으로 랜덤한 다이스로 성장
        if (Remaining <= 0)
        {
            GrowthUp();
        }
    }

    private void GrowthUp()
    {
        int change = this.eyes;
        change++;
        GameObject temp =GameManager.instance.spawner.diceprefabs[Random.Range(0, GameManager.instance.spawner.diceprefabs.Count)];
        GameObject diceGO = Instantiate(temp, gameObject.transform.parent);
        var Redice = diceGO.GetComponent<Dice>();
        Redice.eyes = change;
        Redice.SetDiceEye();
        Destroy(gameObject);
        Remaining = 5f;

        GameManager.instance.spawner.dices.Add(Redice);
    }
}
