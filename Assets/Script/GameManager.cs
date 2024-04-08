using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.TextCore.Text;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class GameManager : MonoBehaviour
{
    // instance��� ������ static���� ������ �Ͽ� �ٸ� ������Ʈ ���� ��ũ��Ʈ������ instance�� �ҷ��� �� �ְ� �մϴ� 
    public static GameManager instance = null;                          // ���ӸŴ��� �̱���
    
    public int score { get; set; }
    public int sp { get; set; }

    // ���� ������ sp�� 2���� ǥ��
    // 1�� �����ִ� sp (���� ���̸� +)
    // 2�� �ʿ� sp (��ȯ ��ư�� ������ �ʿ� sp ����)
    [SerializeField] TextMeshPro needSP;
    [SerializeField] TextMeshPro remainSP;

    private void Awake()
    {
        if (instance == null)                                           // instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            instance = this;                                            // ���ڽ��� instance�� �־��ݴϴ�.
            DontDestroyOnLoad(gameObject);                              // OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ����
        }
        else                                                            // 
        {
            if (instance != this)                                       // instance�� ���� �ƴ϶�� �̹� instance�� �ϳ� �����ϰ� �ִٴ� �ǹ�
                Destroy(this.gameObject);                               // �� �̻� �����ϸ� �ȵǴ� ��ü�̴� ��� AWake�� �ڽ��� ����
        }
    }

    public void Start()
    {
        needSP = GetComponent<TextMeshPro>();
        remainSP = GetComponent<TextMeshPro>();
    }

    public void Init()
    {
        score = 0;
        sp = 0;
    }
    private void Update()
    {
        
    }
}
