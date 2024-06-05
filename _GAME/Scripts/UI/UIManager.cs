using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : NewMonoBehaviour
{
    private static UIManager _instance;
    public static UIManager instance => _instance;

    public GameObject uiDialogue;
    public GameObject uiMission;
    public GameObject uiGamePlay;
    public GameObject uiLoadGame;
    public GameObject uiGameOver;
    public GameObject uiGameComplete;
    public GameObject uiSetting;
    protected override void Awake()
    {
        base.Awake();
        LoadInstance();
    }

    private void LoadInstance()
    {
        if (_instance) LogError("UIManager already exist");
        _instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadUIDialogue();
        LoadUiMission();
        LoadUIGamePlay();
        LoadUILoadGame();
        LoadUIGameOver();
        LoadUIGameComplete();
        LoadUISetting();
    }

    private void LoadUIGameComplete()
    {
        if (uiGameComplete) return;
        LogWarning("LoadUIGameComplete");
        uiGameComplete = transform
            .Find("UI_GameComplete")
            .gameObject;
    }

    private void LoadUISetting()
    {
        if (uiSetting) return;
        LogWarning("LoadUISetting");
        uiSetting = transform
            .Find("UI_Setting")
            .gameObject;
    }

    private void LoadUIGameOver()
    {
        if (uiGameOver) return;
        LogWarning("LoadUIGameOver");
        uiGameOver = transform
            .Find("UI_GameOver")
            .gameObject;
    }

    private void LoadUILoadGame()
    {
        if (uiLoadGame) return;
        LogWarning("LoadUILoadGame");
        uiLoadGame = transform
            .Find("LoadGame")
            .gameObject;
    }

    private void LoadUIGamePlay()
    {
        if (uiGamePlay) return;
        LogWarning("LoadUIGamePlay");
        uiGamePlay = transform
            .Find("UI_GamePlay")
            .gameObject;
    }

    private void LoadUiMission()
    {
        if (uiMission) return;
        LogWarning("LoadUiMission");
        uiMission = transform
            .Find("UI_GamePlay")
            .Find("UI_TopLeft")
            .Find("UI_Mission")
            .gameObject;
    }

    private void LoadUIDialogue()
    {
        if (uiDialogue) return;
        LogWarning("LoadUIDialogue");
        uiDialogue = transform.Find("UI_Dialogue").gameObject;
    }
    public void ActiveUIDialogue()
    {
        if (uiDialogue.activeInHierarchy) return;
        uiDialogue.SetActive(true);
    }
    public void DesActiveUIDialogue()
    {
        uiDialogue.SetActive(false);
    }
    public void ActiveUIMission()
    {
        uiMission.SetActive(true);
    }
    public void DesActiveUIMission()
    {
        uiMission.SetActive(false);
    }
    public void ActiveUIGamePlay()
    {
        uiGamePlay.SetActive(true);
    }
    public void DesActiveUIGamePLay()
    {
        uiGamePlay.SetActive(false);
    }
    public void ActiveUILoadGame()
    {
        uiLoadGame.SetActive(true);
    }
    public void ActiveUIGameOver()
    {
        uiGameOver.SetActive(true);
    }
    public void ActiveUIGameComplete()
    {
        uiGameComplete.SetActive(true);
    }
    public void ActiveUISetting()
    {
        uiSetting.SetActive(true);
    }
    public void DesActiveUISetting()
    {
        uiSetting.SetActive(false);
    }
}
