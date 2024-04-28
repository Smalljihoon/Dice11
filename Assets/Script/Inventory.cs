using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance = null;

    public InvenDeck[] dice = new InvenDeck[5];

    public TypePanel typePanel;
    [SerializeField] Sprite noneSprite = null;

    //�̱��� ����
    private void Awake()
    {
        typePanel = FindFirstObjectByType<TypePanel>();
        typePanel.gameObject.SetActive(false);
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // ���� ���̽� �����ϴ��Լ� 
    public void SetDice(Dice_category category, Sprite sprite)
    {
        // ���� ����á���� üũ�ϴ� ���� 
        bool isFull = true;

        //���� ����á���� üũ
        foreach (var d in dice)
        {
            if (d.category == Dice_category.None)
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
                typePanel.gameObject.SetActive(false);
                return;
            }
            else
            {
                //�������� ������ ���� ó�� �����ϴ� ��ĭ�� ���� 
                foreach (var d in dice)
                {
                    if (d.category == Dice_category.None)
                    {
                        d.SetDeck(category, sprite);
                        break;
                    }
                }
            }
        }
        // ���̽� ���� �ǳ� ��Ȱ��ȭ
        typePanel.gameObject.SetActive(false);
    }

    //���� ��ĭ���� ���� 
    public void SetInvenDeckNone(InvenDeck deck)
    {
        deck.SetDeck(Dice_category.None, noneSprite);
    }

    // ������ �Ӽ��� ���̽��� �κ��丮�� �����ϴ��� üũ�ϴ� �Լ� (deck �� null�� ���Ͻ� ������������)
    public InvenDeck GetEqulsDeck(Dice_category category)
    {
        InvenDeck deck = null;
        foreach (var d in dice)
        {
            if (d.category == category)
            {
                deck = d;
                break;
            }
        }

        return deck;
    }

    //���� Ŭ�������� ����// Ŭ���Ұ����� ���·� ���� ( ���� ���� á���� �ٸ� ���̽��� �߰��Ϸ��� ���ý� ȣ��)
    public void SetDeckSelectState(bool isSelect)
    {
        foreach (var d in dice)
        {
            d.isSelect = isSelect;
        }
    }

}