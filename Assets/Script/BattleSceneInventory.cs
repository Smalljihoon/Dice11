using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneInventory : MonoBehaviour
{
    [SerializeField] InvenDeck[] decks = null;                          // 전투씬 인벤토리에 넣어줄 변수

    private void Start()
    {
        for (int i = 0; i < Inventory.Instance.diceDatas.Length; ++i)
        {
            DiceData data = Inventory.Instance.diceDatas[i];

            if (data == null)
                continue;

            if (data.category != Dice_category.None)
            {
                // 전투씬에 있는 under_panel에 있는 강화패널에 인벤토리에서 가져온 다이스의 데이터를 넣어준다
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
