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

    public int usePlus = 10;    // 소환시 필요 sp 가중치
    //List<Dice> dices = new List<Dice>();
    //게임 오브젝트로 사용하기 코드 :
    //GameObject obj = Instantiate(Resources.Load("/경로/프리팹이름")) as GameObject;

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
                Debug.Log("꽉참");
            }
        }
        else
        {
            Debug.Log("주사위를 소환시키기에 sp가 부족합니다.");
            return;
        }
    }
    public void RandomPick(int n)
    {
        if (slots[n].childCount == 0)                                                   // slot이 null이면 소환
        {
            var temp = diceprefabs[Random.Range(0, diceprefabs.Count)];
            var diceGO = Instantiate(temp, slots[n]);
            dices.Add(diceGO.GetComponent<Dice>());
        }
        else                                                                                        // slot이 null이 아니면 재귀호출
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