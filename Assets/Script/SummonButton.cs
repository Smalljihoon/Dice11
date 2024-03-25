using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonButton : MonoBehaviour
{
    [SerializeField] Button bt;
    [SerializeField] GameObject dice;

    //게임 오브젝트로 사용하기 코드 :
    //GameObject obj = Instantiate(Resources.Load("/경로/프리팹이름")) as GameObject;

    private void Start()
    {
        bt = GetComponent<Button>();
    }

    void diceSummon()
    {
        Slot slot = GetComponent<Slot>();
        dice = new GameObject();

        
        if(bt == Input.GetMouseButton(0)) 
        {
            
            dice.SetActive(true);
        }
    }


    //public Image targetImage; // 기존 이미지
    //public Sprite newImage;   // 바뀔 이미지
    //private Sprite originalImage; // 원래 이미지 저장

    //private void Start()
    //{
    //    // 시작할 때 원래 이미지를 저장하는 코드
    //    originalImage = targetImage.sprite;
    //}

    //public void ChangeImage()
    //{
    //    // 버튼을 누를 때 이미지가 바뀌고 3초 뒤에 원래 이미지로 돌아오는 코드
    //    targetImage.sprite = newImage;
    //    Invoke("RestoreOriginalImage", 3f);
    //}

    //private void RestoreOriginalImage()
    //{
    //    // 3초 후에 원래 이미지로 복원하는 코드
    //    targetImage.sprite = originalImage;
    //}
}
