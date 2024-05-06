using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DiceData
{
    public Dice_category category = Dice_category.None;
    public Sprite diceimg;
    public int enforce = 1;
    public GameObject prefab;
}

public class Inventory : MonoBehaviour
{
    public static Inventory Instance = null;

    public DiceData[] diceDatas = new DiceData[5];

    //½Ì±ÛÅæ »ý¼º
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // °­È­
    public void Enforce(Dice_category category)
    {
        DiceData diceData = null;
        foreach (var data in diceDatas)
        {
            if (data.category == category)
            {
                diceData = data;
                break;
            }
        }

        if (diceData == null)
        {
            return;
        }

        if (diceData.enforce * 100 <= GameManager.instance.reamain)
        {
            if (diceData.enforce < 7)
            {
                GameManager.instance.reamain -= diceData.enforce * 100;
                diceData.enforce++;

                foreach (var dice in GameManager.instance.spawner.dices)
                {
                    if(dice.category == category)
                    {
                        dice.SetEnforce(diceData.enforce);
                    }
                }
            }
        }
    }

    public int GetEnforce(Dice_category category)
    {
        DiceData diceData = null;
        foreach (var d in diceDatas)
        {
            if (d.category == category)
            {
                diceData = d;
                break;
            }
        }

        if (diceData == null)
        {
            return -1;
        }
        else
        {
            return diceData.enforce;
        }
    }
}