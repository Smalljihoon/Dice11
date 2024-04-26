using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] Button inventorybt;
    [SerializeField] Button invenExitbt;

    [SerializeField] Button[] choicebt;

    [SerializeField] GameObject invenpanel;
    
    // 주사위 선택 버튼을 누르면 해당 버튼의 주사위 이미지, 설명 등이 나온다
    // 선택, 나가기 버튼이 있는데 선택을 누르면 나의 덱에 추가를 한다

    private void Start()
    {
        inventorybt.onClick.AddListener(Inven);
    }

    public void Update()
    {

    }

    public void Inven()
    {
        invenpanel.SetActive(true);

    }


}
