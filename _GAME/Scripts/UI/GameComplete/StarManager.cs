using UnityEngine;
using UnityEngine.UI;

public class StarManager : NewMonoBehaviour
{
    [SerializeField] private Image[] _lstStar;
    [SerializeField] private Sprite _sprStar;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadLstStar();
    }

    private void LoadLstStar()
    {
        if (-_lstStar.Length > 0) return;
        LogWarning("LoadLstStar");
        _lstStar = GetComponentsInChildren<Image>();
    }
    private void Start()
    {
        UpdateStar();
        HighScore();
    }
    private void HighScore()
    {
        float elapsedTime = TimerSystem.instance.elapsedTime;
        float longest = PlayerPrefs.GetFloat(PlayerPrefsConst.BEST_TIMER_PP, 1f);
        if (elapsedTime > longest)
            PlayerPrefs.SetFloat(PlayerPrefsConst.BEST_TIMER_PP, elapsedTime);
    }
    private int NumberStars()
    {
        float elapsedTime = TimerSystem.instance.elapsedTime;
        float longest = PlayerPrefs.GetFloat(PlayerPrefsConst.BEST_TIMER_PP, 1f);
        int starNumber = Mathf.Clamp((int)(3 * (elapsedTime / longest)), 0, _lstStar.Length);
        return starNumber;
    }
    private void UpdateStar()
    {
        int starNumber = NumberStars();
        for (int i = 0; i < starNumber; i++)
        {
            _lstStar[i].sprite = _sprStar;
        }
    }
}
