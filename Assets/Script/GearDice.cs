using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GearDice : Dice
{
    // Start is called before the first frame update
    void Start()
    {
        category = Dice_category.Growth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Upgrade()
    {
        if(Dice_category.Joker == category)
        {
            // 합체 로직
        }
    }
}
