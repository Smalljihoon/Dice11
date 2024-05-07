using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // instance��� ������ static���� ������ �Ͽ� �ٸ� ������Ʈ ���� ��ũ��Ʈ������ instance�� �ҷ��� �� �ְ� �մϴ� 
    public static GameManager instance = null;                          // ���ӸŴ��� �̱���

    public int score { get; set; }

    [SerializeField] TMP_Text needSP;           // ��ȯ�� �� �ʿ��� sp
    [SerializeField] TMP_Text remainSP;         // ���� ������ �ִ� sp
    public DiceSpawner spawner;
    public FusionManager fusionManager;

    public int reamain = 100;
    public int need = 10;

    // ���� �ִ� �ֻ������� ���´�
    // �̹����� �ش� �ֻ����� ��Ī��Ų��

    private void Awake()
    {
        instance = this;                                            // ���ڽ��� instance�� �־��ݴϴ�.
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
    // ���͸� ���̸� + 10 SP  -- ���� �ö󰥶����� ��� sp+10
    // �ֻ����� ��ȯ�� ������ �ʿ��ġ�� 10�� �þ

    private void OnDestroy()
    {
        foreach (var dice in Inventory.Instance.diceDatas)
        {
            dice.enforce = 1;
        }
    }
}