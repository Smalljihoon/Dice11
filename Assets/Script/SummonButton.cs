using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonButton : MonoBehaviour
{
    [SerializeField] Button bt;
    [SerializeField] GameObject dice;

    //���� ������Ʈ�� ����ϱ� �ڵ� :
    //GameObject obj = Instantiate(Resources.Load("/���/�������̸�")) as GameObject;

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


    //public Image targetImage; // ���� �̹���
    //public Sprite newImage;   // �ٲ� �̹���
    //private Sprite originalImage; // ���� �̹��� ����

    //private void Start()
    //{
    //    // ������ �� ���� �̹����� �����ϴ� �ڵ�
    //    originalImage = targetImage.sprite;
    //}

    //public void ChangeImage()
    //{
    //    // ��ư�� ���� �� �̹����� �ٲ�� 3�� �ڿ� ���� �̹����� ���ƿ��� �ڵ�
    //    targetImage.sprite = newImage;
    //    Invoke("RestoreOriginalImage", 3f);
    //}

    //private void RestoreOriginalImage()
    //{
    //    // 3�� �Ŀ� ���� �̹����� �����ϴ� �ڵ�
    //    targetImage.sprite = originalImage;
    //}
}
