using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JokerDice : Dice
{
    protected override void Start()
    {
        base.Start();

        category = Dice_category.Joker;
    }



}
