using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneInventory : MonoBehaviour
{
    [SerializeField] InvenDeck[] decks = null;                          // ������ �κ��丮�� �־��� ����

    private void Start()
    {
        for (int i = 0; i < Inventory.Instance.diceDatas.Length; ++i)
        {
            DiceData data = Inventory.Instance.diceDatas[i];

            if (data == null)
                continue;

            if (data.category != Dice_category.None)
            {
                // �������� �ִ� under_panel�� �ִ� ��ȭ�гο� �κ��丮���� ������ ���̽��� �����͸� �־��ش�
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
