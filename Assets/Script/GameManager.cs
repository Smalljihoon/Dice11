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

    
}
//public Vector3 MousePos
//{
//    get
//    {
//        var result = Camera.main.WorldToScreenPoint(Input.mousePosition);
//        result.z = 0;
//        return result;
//    }
//}
//public void OnMouseDown()
//{


//}

//public void OnMouseDrag()
//{
//    //Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
//    //Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);
//    //transform.position = objPos;
//    transform.position = MousePos;
//}

//public void OnMouseUp()
//{

//}