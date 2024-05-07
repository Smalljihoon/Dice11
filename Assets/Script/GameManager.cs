using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // instance라는 변수를 static으로 선언을 하여 다른 오브젝트 안의 스크립트에서도 instance를 불러올 수 있게 합니다 
    public static GameManager instance = null;                          // 게임매니저 싱글톤

    public int score { get; set; }

    [SerializeField] TMP_Text needSP;           // 소환할 때 필요한 sp
    [SerializeField] TMP_Text remainSP;         // 내가 가지고 있는 sp
    public DiceSpawner spawner;
    public FusionManager fusionManager;

    public int reamain = 100;
    public int need = 10;

    // 덱에 있는 주사위들을 들고온다
    // 이미지랑 해당 주사위를 매칭시킨다

    private void Awake()
    {
        instance = this;                                            // 내자신을 instance로 넣어줍니다.
    }

    public void Update()
    {
        needSP.text = need.ToString();
        remainSP.text = reamain.ToString();
    }

    public void Init(int Plus, int Minus)
    {
        reamain = Plus;
        need = Minus;
    }

    public void MinusRemain(int value)
    {
        reamain -= value;
    }

    public void PlusRemain(int value)
    {
        reamain += value;
    }

    public void PlusNeedSP(int value)
    {
        need += value;
    }

    public void MinusNeedSP(int value)
    {
        need -= value;
    }
    // 몬스터를 죽이면 + 10 SP  -- 라운드 올라갈때마다 얻는 sp+10
    // 주사위를 소환할 때마다 필요수치가 10씩 늘어남

    private void OnDestroy()
    {
        foreach (var dice in Inventory.Instance.diceDatas)
        {
            dice.enforce = 1;
        }
    }
}