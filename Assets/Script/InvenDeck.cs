using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvenDeck : MonoBehaviour
{
    public Dice_category category;
   [SerializeField] private Image diceimg;
    
    //선택을 할수있는 상태인지 체크하는 변수
    [HideInInspector]public bool isSelect = false;

    //덱초기화 하는 함수 
    public void SetDeck(Dice_category category, Sprite diceimg)
    {
        this.category = category;
        this.diceimg.sprite = diceimg;
    }

    public void OnButtonClick_Select()
    {
        //버튼 클릭시 선택할수있는 상태인지 체크 
        if (isSelect)
        {
            // 다른 슬롯에 이미 존재하는 다이스인지 중복체크
            var deck = Inventory.Instance.GetEqulsDeck(Inventory.Instance.typePanel.category);
            //존재할시 체크 
            if (deck != null)
            {
                // None으로 변경
                Inventory.Instance.SetInvenDeckNone(deck);
            }

            //다이스 
            SetDeck(Inventory.Instance.typePanel.category, Inventory.Instance.typePanel.diceImage.sprite);
            //다른 덱들 선택할수없는 상태로 변경 
            Inventory.Instance.SetDeckSelectState(false);
        }
    }
}
