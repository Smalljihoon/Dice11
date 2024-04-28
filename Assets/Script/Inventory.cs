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

    //싱글톤 생성
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

    // 덱에 다이스 셋팅하는함수 
    public void SetDice(Dice_category category, Sprite sprite)
    {
        // 덱이 가득찼는지 체크하는 변수 
        bool isFull = true;

        //덱이 가득찼는지 체크
        foreach (var d in dice)
        {
            if (d.category == Dice_category.None)
            {
                isFull = false;
                break;
            }
        }

        // 다른 슬롯에 이미 존재하는 다이스인지 중복체크
        if (isFull)
        {
            // 가득찼을때 덱들을 클릭가능한 상태로 변경 
            SetDeckSelectState(true);
        }
        else
        {
            // 동일한 다이스가 이미 덱에 존재하는지 체크 
            var deck = GetEqulsDeck(category);

            if (deck != null)
            {
                //존재할시 아무것도 하지않고 리턴
                typePanel.gameObject.SetActive(false);
                return;
            }
            else
            {
                //존재하지 않을시 제일 처음 존재하는 빈칸에 적용 
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
        // 다이스 설명 판넬 비활성화
        typePanel.gameObject.SetActive(false);
    }

    //덱을 빈칸으로 변경 
    public void SetInvenDeckNone(InvenDeck deck)
    {
        deck.SetDeck(Dice_category.None, noneSprite);
    }

    // 동일한 속성의 다이스가 인벤토리에 존재하는지 체크하는 함수 (deck 이 null이 리턴시 존재하지않음)
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

    //덱이 클릭가능한 상태// 클릭불가능한 상태로 변경 ( 덱이 가득 찼을때 다른 다이스를 추가하려고 선택시 호출)
    public void SetDeckSelectState(bool isSelect)
    {
        foreach (var d in dice)
        {
            d.isSelect = isSelect;
        }
    }

}