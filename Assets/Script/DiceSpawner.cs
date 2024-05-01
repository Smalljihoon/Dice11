using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DiceSpawner : MonoBehaviour
{
    [SerializeField] Button bt;
    [SerializeField] public GameObject[] dice;

    [SerializeField] Transform[] slots = null;

    public int usePlus = 10;    // ��ȯ�� �ʿ� sp ����ġ
    //List<Dice> dices = new List<Dice>();
    //���� ������Ʈ�� ����ϱ� �ڵ� :
    //GameObject obj = Instantiate(Resources.Load("/���/�������̸�")) as GameObject;

    private void Start()
    {
        bt.onClick.AddListener(DiceSummon);
    }

    public void DiceSummon()
    {
        if (GameManager.instance.reamain >= GameManager.instance.need)
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
                GameManager.instance.MinusRemain(GameManager.instance.need);
                GameManager.instance.PlusNeedSP(usePlus);
            }
            else
            {
                Debug.Log("����");
            }
        }
        else
        {
            Debug.Log("�ֻ����� ��ȯ��Ű�⿡ sp�� �����մϴ�.");
            return;
        }
    }
    public void RandomPick(int n)
    {
        if (slots[n].childCount == 0)                                                   // slot�� null�̸� ��ȯ
        {
            var temp = dice[Random.Range(0, dice.Length)];
            var diceGO = Instantiate(temp, slots[n]);
        }
        else                                                                                        // slot�� null�� �ƴϸ� ���ȣ��
        {
            int a = Random.Range(0, slots.Length);
            RandomPick(a);
        }
    }

}