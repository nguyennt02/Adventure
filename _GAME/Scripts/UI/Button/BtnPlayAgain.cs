using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnPlayAgain : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        UIStartManager.instance.ActiveUILoadGame();
        StartCoroutine(LoadGame());
    }
    private IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(1f);
        TimerSystem.instance.SetTimer();
        int level = PlayerPrefs.GetInt(PlayerPrefsConst.LEVEL_PP, 1);
        SceneManager.LoadScene(level);
    }
}
