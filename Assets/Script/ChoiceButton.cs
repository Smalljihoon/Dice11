using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoiceButton : MonoBehaviour
{
    [SerializeField] TypePanel typePanel;
    [SerializeField] Image img;
    [SerializeField] GameObject prefab;

    [SerializeField] Dice_category category;


    public void OnButtonClick_Choice(string text)               // OnClick���� �۵��� ���̸� type�� ��� Ŭ���ϸ� �ش� ���̽��� ���� ���� �г��� ���� ��
    {
        typePanel.SetPanel(img.GetComponent<Image>().sprite, text, category, prefab);   // �ش� ���̽��� ���� �̹���, �Ӽ�, �������� �־��ش�

        typePanel.gameObject.SetActive(true);
    }
}
