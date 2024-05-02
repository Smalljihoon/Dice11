using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenDeck : MonoBehaviour
{
    [SerializeField] private Image diceimg;

    public DiceData data = null;

    //선택을 할수있는 상태인지 체크하는 변수
    [HideInInspector] public bool isSelect = false;

    private void Awake()
    {
        data = new DiceData();
    }
    //덱초기화 하는 함수 
    public void SetDeck(Dice_category category, Sprite diceimg, GameObject go)
    {
        data.category = category;
        data.diceimg = diceimg;
        this.diceimg.sprite = diceimg;
        data.prefab = go;
    }

    public void OnButtonClick_Select()
    {
        //버튼 클릭시 선택할수있는 상태인지 체크 
        if (isSelect)
        {
            // 다른 슬롯에 이미 존재하는 다이스인지 중복체크
            var deck = StartSceneManager.Instance.explanationPanel.GetEqulsDeck(StartSceneManager.Instance.typePanel.category);
            //존재할시 체크 
            if (deck != null)
            {
                // None으로 변경
                StartSceneManager.Instance.explanationPanel.SetInvenDeckNone(deck);
            }

            //다이스 
            SetDeck(StartSceneManager.Instance.typePanel.category, StartSceneManager.Instance.typePanel.diceImage.sprite, StartSceneManager.Instance.typePanel.go);
            //다른 덱들 선택할수없는 상태로 변경 
            StartSceneManager.Instance.explanationPanel.SetDeckSelectState(false);
        }
    }

    public void OnButtonClick_Enforce()
    {
        if (data.category != Dice_category.None)
        {
            Inventory.Instance.Enforce(data.category);
        }
    }
}
