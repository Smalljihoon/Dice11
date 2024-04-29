using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenDeck : MonoBehaviour
{
    public Dice_category category;
   [SerializeField] private Image diceimg;
    
    //������ �Ҽ��ִ� �������� üũ�ϴ� ����
    [HideInInspector]public bool isSelect = false;

    //���ʱ�ȭ �ϴ� �Լ� 
    public void SetDeck(Dice_category category, Sprite diceimg)
    {
        this.category = category;
        this.diceimg.sprite = diceimg;
    }

    public void OnButtonClick_Select()
    {
        //��ư Ŭ���� �����Ҽ��ִ� �������� üũ 
        if (isSelect)
        {
            // �ٸ� ���Կ� �̹� �����ϴ� ���̽����� �ߺ�üũ
            var deck = Inventory.Instance.GetEqulsDeck(Inventory.Instance.typePanel.category);
            //�����ҽ� üũ 
            if (deck != null)
            {
                // None���� ����
                Inventory.Instance.SetInvenDeckNone(deck);
            }

            //���̽� 
            SetDeck(Inventory.Instance.typePanel.category, Inventory.Instance.typePanel.diceImage.sprite);
            //�ٸ� ���� �����Ҽ����� ���·� ���� 
            Inventory.Instance.SetDeckSelectState(false);
        }
    }
}
