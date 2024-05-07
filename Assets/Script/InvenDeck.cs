using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InvenDeck : MonoBehaviour
{
    [SerializeField] private Image diceimg;         // 다이스 이미지
    [SerializeField] TMP_Text Need_upgrade;     // 업그레이드시 필요한 sp수치
    [SerializeField] TMP_Text LV;                         // 강화단계 레벨
    [SerializeField] GameObject PowerUp;         // 파워업 표시 프리팹

    public DiceData data = null;

    //선택을 할수있는 상태인지 체크하는 변수
    [HideInInspector] public bool isSelect = false;

    private void Awake()
    {
        data = new DiceData();
    }

    public void Update()
    {
        
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

    // OnClick 강화패널에서 강화하고 싶은 다이스 클릭시 강화
    public void OnButtonClick_Enforce()
    {
        if (data.category != Dice_category.None)
        {
            if (data.enforce < 7)
            {
                Inventory.Instance.Enforce(data.category);
                data.enforce++;                                  // 버그 발생

                LV.text = "LV." + data.enforce.ToString();

                PowerUp.SetActive(true);
                Invoke("ActiveOff", 1.5f);

                var need = data.enforce * 100;
                Need_upgrade.text = need.ToString();

                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
            }
         
        }
    }

    public void ActiveOff()
    {
        PowerUp.SetActive(false);
    }
}
