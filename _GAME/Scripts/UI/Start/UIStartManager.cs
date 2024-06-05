using System;
using UnityEngine;

public class UIStartManager : NewMonoBehaviour
{
    private static UIStartManager _instance;
    public static UIStartManager instance => _instance;

    public GameObject uiGameStart;
    public GameObject uiAchievement;
    public GameObject uiInstruct;
    public GameObject uiLoadGame;

    protected override void Awake()
    {
        base.Awake();
        LoadInstance();
    }

    private void LoadInstance()
    {
        if (_instance) LogError("UIStartManager already exist");
        _instance = this;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadGameStart();
        LoadAchievement();
        LoadInstruct();
        LoadUILoadGame();
    }

    private void LoadUILoadGame()
    {
        if (uiLoadGame) return;
        LogWarning("LoadUILoadGame");
        uiLoadGame = transform
            .Find("LoadGame")
            .gameObject;
    }

    private void LoadInstruct()
    {
        if (uiInstruct) return;
        LogWarning("LoadInstruct");
        uiInstruct = transform
            .Find("UI_Instruct")
            .gameObject;
    }

    private void LoadAchievement()
    {
        if (uiAchievement) return;
        LogWarning("LoadAchievement");
        uiAchievement = transform
            .Find("UI_Achievement")
            .gameObject;
    }

    private void LoadGameStart()
    {
        if (uiGameStart) return;
        LogWarning("LoadGameStart");
        uiGameStart = transform
            .Find("UI_Start")
            .gameObject;
    }
    public void ActiveUIGameStart()
    {
        uiGameStart.SetActive(true);
    }
    public void DesActiveUIGameStart()
    {
        uiGameStart.SetActive(false);
    }
    public void ActiveUIAchievement()
    {
        uiAchievement.SetActive(true);
    }
    public void DesActiveUIAchievement()
    {
        uiAchievement.SetActive(false);
    }
    public void ActiveUIInstruct()
    {
        uiInstruct.SetActive(true);
    }
    public void DesActiveUIInstruct()
    {
        uiInstruct.SetActive(false);
    }
    public void ActiveUILoadGame()
    {
        uiLoadGame.SetActive(true);
    }
}
