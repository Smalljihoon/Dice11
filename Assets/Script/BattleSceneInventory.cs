using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneInventory : MonoBehaviour
{
    [SerializeField] private InvenDeck[] decks = null;

    private void Start()
    {
        for (int i = 0; i < Inventory.Instance.diceDatas.Length; ++i)
        {
            DiceData data = Inventory.Instance.diceDatas[i];

            if (data == null)
                continue;

            if (data.category != Dice_category.None)
            {
                foreach (InvenDeck deck in decks)
                {
                    if (deck.data.category == Dice_category.None)
                    {
                        deck.SetDeck(data.category, data.diceimg, data.prefab);
                        break;
                    }
                }
            }
        }
    }

}
