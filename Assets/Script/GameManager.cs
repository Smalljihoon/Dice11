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
    // instance라는 변수를 static으로 선언을 하여 다른 오브젝트 안의 스크립트에서도 instance를 불러올 수 있게 합니다 
    public static GameManager instance = null;                          // 게임매니저 싱글톤
    
    public int score { get; set; }
    public int sp { get; set; }

    // 게임 내에서 sp를 2가지 표기
    // 1번 남아있는 sp (적을 죽이면 +)
    // 2번 필요 sp (소환 버튼을 누를시 필요 sp 증가)
    [SerializeField] TextMeshPro needSP;
    [SerializeField] TextMeshPro remainSP;

    private void Awake()
    {
        if (instance == null)                                           // instance가 null. 즉, 시스템상에 존재하고 있지 않을때
        {
            instance = this;                                            // 내자신을 instance로 넣어줍니다.
            DontDestroyOnLoad(gameObject);                              // OnLoad(씬이 로드 되었을때) 자신을 파괴하지 않고 유지
        }
        else                                                            // 
        {
            if (instance != this)                                       // instance가 내가 아니라면 이미 instance가 하나 존재하고 있다는 의미
                Destroy(this.gameObject);                               // 둘 이상 존재하면 안되는 객체이니 방금 AWake된 자신을 삭제
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