using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypePanel : MonoBehaviour
{
   public  Image diceImage = null;
    [SerializeField] TMP_Text text = null;

    //���� ���õ� ���̽��� ī�װ�
    public Dice_category category;

    //�ǳ� ǥ�ý� �ʱ�ȭ
    public void SetPanel(Sprite sprite, string text, Dice_category category)
    {
        diceImage.GetComponent<Image>().sprite = sprite;
        var str = text.Replace('-', '\n');
        this.category = category;
        this.text.text = str;
    }

    //���̽� ���� ��ư Ŭ��
    public void OnButtonClick_Select()
    {
        // ���̽� ���ý� �κ��丮�� ���� 
        Inventory.Instance.SetDice(category, diceImage.sprite);
    }
}












