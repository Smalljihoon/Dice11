using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public static StartSceneManager Instance = null;
    public ExplanationPanel explanationPanel = null;
    public TypePanel typePanel = null;

    private void Awake()
    {
        Instance = this;
    }

    public void OnButtonClick_StartBattleScene()
    {
        explanationPanel.SetInventory();
        SceneManager.LoadScene("Battle");
    }
}
