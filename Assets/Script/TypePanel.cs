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
    //현재 선택된 다이스의 카테고리
    public Dice_category category;

    //판넬 표시시 초기화
    public void SetPanel(Sprite sprite, string text, Dice_category category, GameObject prefab)
    {
        diceImage.GetComponent<Image>().sprite = sprite;
        var str = text.Replace('-', '\n');
        this.category = category;
        this.text.text = str;
        go = prefab;
    }

    //다이스 선택 버튼 클릭
    public void OnButtonClick_Select()
    {
        // 다이스 선택시 인벤토리에 세팅 
        explanationPanel.SetDice(category, diceImage.sprite, go);
    }
}












