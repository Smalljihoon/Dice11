using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunDice : Dice
{
    protected override void Start()
    {
        base.Start();

        category = Dice_category.Sun;
    }
}
