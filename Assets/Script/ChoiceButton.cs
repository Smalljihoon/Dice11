using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChoiceButton : MonoBehaviour
{
    [SerializeField] TypePanel typePanel;
    [SerializeField] TMP_Text Impormation;
    [SerializeField] Image img;
    [SerializeField] GameObject prefab;

    [SerializeField] Dice_category category;


    public void OnButtonClick_Choice(string text)
    {
        typePanel.SetPanel(img.GetComponent<Image>().sprite, text, category, prefab);

        typePanel.gameObject.SetActive(true);
    }
}
