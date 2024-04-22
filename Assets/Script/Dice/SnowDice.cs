using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowDice : Dice
{
    protected override void Start()
    {
        category = Dice_category.Snow;
    }
}
