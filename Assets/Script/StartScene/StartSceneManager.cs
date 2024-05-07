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

    private void Update()
    {
        bool interactable = true;

        for (int i = 0; i < explanationPanel.decks.Length; ++i)
        {
            var data = explanationPanel.decks[i];

            if (data.data == null || data.data.category == Dice_category.None)
            {
                interactable = false;
                break;
            }
        }
        battlebutton.GetComponent<Button>().interactable = interactable;
    }

    public void OnButtonClick_StartBattleScene()
    {
        explanationPanel.SetInventory();
        SceneManager.LoadScene("Battle");
    }
}
