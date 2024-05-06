using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InvenDeck : MonoBehaviour
{
    [SerializeField] private Image diceimg;         // ���̽� �̹���
    [SerializeField] TMP_Text Need_upgrade;     // ���׷��̵�� �ʿ��� sp��ġ
    [SerializeField] TMP_Text LV;                         // ��ȭ�ܰ� ����
    [SerializeField] GameObject PowerUp;         // �Ŀ��� ǥ��? ������

    public DiceData data = null;

    //������ �Ҽ��ִ� �������� üũ�ϴ� ����
    [HideInInspector] public bool isSelect = false;

    private void Awake()
    {
        data = new DiceData();
    }
    //���ʱ�ȭ �ϴ� �Լ� 
    public void SetDeck(Dice_category category, Sprite diceimg, GameObject go)
    {
        data.category = category;
        data.diceimg = diceimg;
        this.diceimg.sprite = diceimg;
        data.prefab = go;
    }

    public void OnButtonClick_Select()
    {
        //��ư Ŭ���� �����Ҽ��ִ� �������� üũ 
        if (isSelect)
        {
            // �ٸ� ���Կ� �̹� �����ϴ� ���̽����� �ߺ�üũ
            var deck = StartSceneManager.Instance.explanationPanel.GetEqulsDeck(StartSceneManager.Instance.typePanel.category);
            //�����ҽ� üũ 
            if (deck != null)
            {
                // None���� ����
                StartSceneManager.Instance.explanationPanel.SetInvenDeckNone(deck);
            }

            //���̽� 
            SetDeck(StartSceneManager.Instance.typePanel.category, StartSceneManager.Instance.typePanel.diceImage.sprite, StartSceneManager.Instance.typePanel.go);
            //�ٸ� ���� �����Ҽ����� ���·� ���� 
            StartSceneManager.Instance.explanationPanel.SetDeckSelectState(false);
        }
    }

    // OnClick ��ȭ�гο��� ��ȭ�ϰ� ���� ���̽� Ŭ���� ��ȭ
    public void OnButtonClick_Enforce()
    {
        if (data.category != Dice_category.None)
        {
            int SetEnforce = 1;

            Inventory.Instance.Enforce(data.category);
            SetEnforce++;
            LV.text = "LV." + SetEnforce.ToString();

            PowerUp.SetActive(true);
            Invoke("Original", 1.5f);

            var need = SetEnforce * 100;
            Need_upgrade.text = need.ToString();

            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }

    public void Original()
    {
        PowerUp.SetActive(false);
    }
}
