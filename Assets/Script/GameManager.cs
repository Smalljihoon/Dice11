using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.TextCore.Text;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using static UnityEngine.Rendering.DebugUI;

public class GameManager : MonoBehaviour
{
    // instance��� ������ static���� ������ �Ͽ� �ٸ� ������Ʈ ���� ��ũ��Ʈ������ instance�� �ҷ��� �� �ְ� �մϴ� 
    public static GameManager instance = null;                          // ���ӸŴ��� �̱���

    public int score { get; set; }

    [SerializeField] TMP_Text needSP;           // ��ȯ�� �� �ʿ��� sp
    [SerializeField] TMP_Text remainSP;         // ���� ������ �ִ� sp

    public int reamain = 100;
    public int need = 10;

    // ���� �ִ� �ֻ������� ���´�
    // �̹����� �ش� �ֻ����� ��Ī��Ų��

    private void Awake()
    {
        if (instance == null)                                           // instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            instance = this;                                            // ���ڽ��� instance�� �־��ݴϴ�.
            DontDestroyOnLoad(gameObject);                              // OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ����
        }
        else                                                            
        {
                Destroy(this.gameObject);                               // �� �̻� �����ϸ� �ȵǴ� ��ü�̴� ��� AWake�� �ڽ��� ����
        }
    }

    public void Start()
    {
        
    }

    public void Update()
    {
        needSP.text = need.ToString();
        remainSP.text = reamain.ToString();
    }

    

    public void Upgrade()
    {
       

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

}