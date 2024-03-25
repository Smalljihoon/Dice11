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


    //���� ������Ʈ�� ����ϱ� �ڵ� :
    //GameObject obj = Instantiate(Resources.Load("/���/�������̸�")) as GameObject;

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
            Debug.Log("����");
        }
    }
    public void RandomPick(int n)
    {
        // slot�� null�̸� ��ȯ
        if (slots[n].childCount == 0)
        {
            var diceGO = Instantiate(dice, slots[n]);
        }
        // slot�� null�� �ƴϸ� ���ȣ��
        else
        {
            int a = Random.Range(0, slots.Length);
            RandomPick(a);
        }
    }

}