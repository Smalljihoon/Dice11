using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronDice : Dice
{
    protected override void Start()
    {
        base.Start();

        category = Dice_category.Iron;

    }
    protected override void Update()
    {
        base.Update();


    }
}
