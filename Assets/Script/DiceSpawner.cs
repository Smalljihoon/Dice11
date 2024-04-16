using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DiceSpawner : MonoBehaviour
{
    [SerializeField] Button bt;
    [SerializeField] GameObject[] dice;

    [SerializeField] Transform[] slots = null;

    List<Dice> dices = new List<Dice>();
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
        if (slots[n].childCount == 0)                                                   // slot�� null�̸� ��ȯ
        {
            var temp = dice[Random.Range(0, dice.Length)];
            var diceGO = Instantiate(temp, slots[n]);
            dices.Add(diceGO.GetComponent<Dice>());

            //dices[0].Skill();
        }
        else                                                                                        // slot�� null�� �ƴϸ� ���ȣ��
        {
            int a = Random.Range(0, slots.Length);
            RandomPick(a);
        }
    }

}