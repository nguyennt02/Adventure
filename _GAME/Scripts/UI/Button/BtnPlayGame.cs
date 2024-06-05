using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnPlayGame : BaseButton
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
        PlayerPrefs.SetInt(PlayerPrefsConst.LEVEL_PP, 1);
        SceneManager.LoadScene(1);
    }
}
