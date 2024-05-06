using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    public static StartSceneManager Instance = null;
    public ExplanationPanel explanationPanel = null;
    public TypePanel typePanel = null;
    public Button battlebutton;

    private void Awake()
    {
        Instance = this;
    }

    //private void Update()
    //{
    //    for (int i = 0; i < Inventory.Instance.diceDatas.Length; ++i)
    //    {
    //        DiceData data = Inventory.Instance.diceDatas[i];

    //        if (data == null)
    //            continue;

    //        if (data.category == Dice_category.None)
    //        {
    //            battlebutton.GetComponent<Button>().interactable = false;
    //        }
    //        else
    //            battlebutton.GetComponent<Button>().interactable = true;
    //    }
    //}

    public void OnButtonClick_StartBattleScene()
    {
        explanationPanel.SetInventory();
        SceneManager.LoadScene("Battle");
    }
}
