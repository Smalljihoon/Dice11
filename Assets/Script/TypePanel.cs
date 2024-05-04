using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TypePanel : MonoBehaviour
{
    [SerializeField] private ExplanationPanel explanationPanel = null;
    [SerializeField] TMP_Text text = null;

    public Image diceImage = null;
    public GameObject go;
    //���� ���õ� ���̽��� ī�װ�
    public Dice_category category;

    //�ǳ� ǥ�ý� �ʱ�ȭ
    public void SetPanel(Sprite sprite, string text, Dice_category category, GameObject prefab)
    {
        diceImage.GetComponent<Image>().sprite = sprite;
        var str = text.Replace('-', '\n');
        this.category = category;
        this.text.text = str;
        go = prefab;
    }

    //���̽� ���� ��ư Ŭ��
    public void OnButtonClick_Select()
    {
        // ���̽� ���ý� �κ��丮�� ���� 
        explanationPanel.SetDice(category, diceImage.sprite, go);
    }
}












