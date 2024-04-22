using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthDice : Dice
{
    protected override void Start()
    {
        base.Start();

        category = Dice_category.Growth;
    }

}
