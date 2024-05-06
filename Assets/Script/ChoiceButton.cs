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


    public void OnButtonClick_Choice(string text)               // OnClick으로 작동할 것이며 type을 골라 클릭하면 해당 다이스에 대한 설명 패널이 켜질 것
    {
        typePanel.SetPanel(img.GetComponent<Image>().sprite, text, category, prefab);   // 해당 다이스에 대한 이미지, 속성, 프리팹을 넣어준다

        typePanel.gameObject.SetActive(true);
    }
}
