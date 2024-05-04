using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplanationPanel : MonoBehaviour
{
    [SerializeField] private InvenDeck[] decks = null;
    [SerializeField] Sprite noneSprite = null;

    private void Start()
    {
        for (int i = 0; i < Inventory.Instance.diceDatas.Length; ++i)
        {
            DiceData data = Inventory.Instance.diceDatas[i];

            if (data == null)
                continue;

            if (data.category != Dice_category.None)
            {
                foreach (var deck in decks)
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

    //���� Ŭ�������� ����// Ŭ���Ұ����� ���·� ���� ( ���� ���� á���� �ٸ� ���̽��� �߰��Ϸ��� ���ý� ȣ��)
    public void SetDeckSelectState(bool isSelect)
    {
        foreach (var d in decks)
        {
            d.isSelect = isSelect;
        }
    }

    //���� ��ĭ���� ���� 
    public void SetInvenDeckNone(InvenDeck deck)
    {
        deck.SetDeck(Dice_category.None, noneSprite, null);
    }

    // ���� ���̽� �����ϴ��Լ� 
    public void SetDice(Dice_category category, Sprite sprite, GameObject go)
    {
        // ���� ����á���� üũ�ϴ� ���� 
        bool isFull = true;

        //���� ����á���� üũ
        foreach (var d in decks)
        {
            if (d.data.category == Dice_category.None)
            {
                isFull = false;
                break;
            }
        }

        // �ٸ� ���Կ� �̹� �����ϴ� ���̽����� �ߺ�üũ
        if (isFull)
        {
            // ����á���� ������ Ŭ�������� ���·� ���� 
            SetDeckSelectState(true);
        }
        else
        {
            // ������ ���̽��� �̹� ���� �����ϴ��� üũ 
            var deck = GetEqulsDeck(category);

            if (deck != null)
            {
                //�����ҽ� �ƹ��͵� �����ʰ� ����
                StartSceneManager.Instance.typePanel.gameObject.SetActive(false);
                return;
            }
            else
            {
                //�������� ������ ���� ó�� �����ϴ� ��ĭ�� ���� 
                foreach (var d in decks)
                {
                    if (d.data.category == Dice_category.None)
                    {
                        d.SetDeck(category, sprite, go);
                        break;
                    }
                }
            }
        }
        // ���̽� ���� �ǳ� ��Ȱ��ȭ
        StartSceneManager.Instance.typePanel.gameObject.SetActive(false);
    }


    // ������ �Ӽ��� ���̽��� �κ��丮�� �����ϴ��� üũ�ϴ� �Լ� (deck �� null�� ���Ͻ� ������������)
    public InvenDeck GetEqulsDeck(Dice_category category)
    {
        InvenDeck data = null;
        foreach (var d in decks)
        {
            if (d.data.category == category)
            {
                data = d;
                break;
            }
        }

        return data;
    }

    public void SetInventory()
    {
        for (int i = 0; i < 5; ++i)
        {
            Inventory.Instance.diceDatas[i] = null;
        }

        for (int i = 0; i < 5; ++i)
        {
            Inventory.Instance.diceDatas[i] = new DiceData();
            DiceData invenData = Inventory.Instance.diceDatas[i];
            invenData.diceimg = decks[i].data.diceimg;
            invenData.category = decks[i].data.category;
            invenData.prefab = decks[i].data.prefab;
        }
    }
}
