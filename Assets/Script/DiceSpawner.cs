using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DiceSpawner : MonoBehaviour
{
    [SerializeField] Button bt;
    [SerializeField] public List<GameObject> diceprefabs =new List<GameObject>();

    [SerializeField] Transform[] slots = null;
    public List<Dice> dices = new List<Dice>();

    public int usePlus = 10;    // ��ȯ�� �ʿ� sp ����ġ
    //List<Dice> dices = new List<Dice>();
    //���� ������Ʈ�� ����ϱ� �ڵ� :
    //GameObject obj = Instantiate(Resources.Load("/���/�������̸�")) as GameObject;

    private void Start()
    {
        foreach(var dice in Inventory.Instance.diceDatas)
        {
            if(dice.category == Dice_category.None)
            {
                continue;
            }

            diceprefabs.Add(dice.prefab);
        }

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
            var temp = diceprefabs[Random.Range(0, diceprefabs.Count)];
            var diceGO = Instantiate(temp, slots[n]);
            dices.Add(diceGO.GetComponent<Dice>());
        }
        else                                                                                        // slot�� null�� �ƴϸ� ���ȣ��
        {
            int a = Random.Range(0, slots.Length);
            RandomPick(a);
        }
    }

    public void RemoveDice(Dice dice)
    {
        dices.Remove(dice);
    }
}