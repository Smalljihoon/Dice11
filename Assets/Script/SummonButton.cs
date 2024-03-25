using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SummonButton : MonoBehaviour
{
    [SerializeField] Button bt;
    [SerializeField] GameObject dice;

    [SerializeField] Transform[] slots = null;


    //게임 오브젝트로 사용하기 코드 :
    //GameObject obj = Instantiate(Resources.Load("/경로/프리팹이름")) as GameObject;

    private void Start()
    {
        bt.onClick.AddListener(DiceSummon);
    }

    public void DiceSummon()
    {
        bool isEmptySlot = false;
        foreach (Transform slot in slots)
        {
            if (slot.childCount == 0)
            {
                isEmptySlot = true;
                break;
            }
        }

        if (isEmptySlot)
        {
            int a = Random.Range(0, slots.Length);
            RandomPick(a);
        }
        else
        {
            Debug.Log("꽉참");
        }
    }
    public void RandomPick(int n)
    {
        // slot이 null이면 소환
        if (slots[n].childCount == 0)
        {
            var diceGO = Instantiate(dice, slots[n]);
        }
        // slot이 null이 아니면 재귀호출
        else
        {
            int a = Random.Range(0, slots.Length);
            RandomPick(a);
        }
    }

}