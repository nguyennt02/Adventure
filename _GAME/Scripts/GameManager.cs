using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : NewMonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance => _instance;
    [SerializeField] private int _maxHp;

    [SerializeField] private GameObject _player;
    [SerializeField] private CRTDamageReceiver _damageReceiver;

    protected override void Awake()
    {
        base.Awake();
        LoadInstance();
    }
    private void Start()
    {
        Scene();
        GameStart();
    }
    private void Scene()
    {
        switch(SceneManager.GetActiveScene().buildIndex) 
        {
            case 1:
                AudioManager.instance.PlayMusic("Level1");
                PlayerPrefs.SetInt(PlayerPrefsConst.MAX_HP_PP, _maxHp);
                PlayerPrefs.SetInt(PlayerPrefsConst.CURRENT_HP_PP, _maxHp);
                break;
            case 2:
                AudioManager.instance.PlayMusic("Level2");
                break;
            case 3:
                AudioManager.instance.PlayMusic("Level3");
                break;
        }
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPlayer();
        LoadDamageReceiver();
    }

    private void LoadDamageReceiver()
    {
        if (_damageReceiver) return;
        LogWarning("LoadDamageReceiver");
        _damageReceiver = _player.GetComponentInChildren<CRTDamageReceiver>();
    }

    private void LoadInstance()
    {
        if (_instance) LogError("GameManager already exist");
        _instance = this;
    }
    private void LoadPlayer()
    {
        if (_player) return;
        LogWarning("LoadPlayer");
        _player = GameObject.Find("Character");
    }
    public void GameStart()
    {
        Time.timeScale = 1;
        CheckPonitManager.instance.Revival();
    }
    public void GameOver()
    {
        Time.timeScale = 0;
        AudioManager.instance.PlaySFX("GameOver");
        AudioManager.instance.StopMusic();
        UIManager.instance.DesActiveUIGamePLay();
        UIManager.instance.ActiveUIGameOver();
    }
    public void GameComplete()
    {
        Time.timeScale = 0;
        AudioManager.instance.PlaySFX("Complete");
        AudioManager.instance.StopMusic();
        UIManager.instance.DesActiveUIGamePLay();
        UIManager.instance.ActiveUIGameComplete();
    }

    public void LoadCurrentMap()
    {
        // Tải lại cảnh hiện tại
        UIManager.instance.ActiveUILoadGame();
        TimerSystem.instance.SetTimer();
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex));
    }
    public void LoadSceneGame(int buildIndex)
    {
        UIManager.instance.ActiveUILoadGame();
        StartCoroutine(LoadScene(buildIndex));
        if(buildIndex != 0) 
            PlayerPrefs.SetInt(PlayerPrefsConst.LEVEL_PP, buildIndex);
        if (buildIndex == 1 || buildIndex == 0) return;
        PlayerPrefs.SetFloat(PlayerPrefsConst.TIMER_PP, TimerSystem.instance.elapsedTime);
        PlayerPrefs.SetInt(PlayerPrefsConst.MAX_HP_PP, _damageReceiver.maxHp);
        PlayerPrefs.SetInt(PlayerPrefsConst.CURRENT_HP_PP, _damageReceiver.currentHp);
    }
    IEnumerator LoadScene(int buildIndex)
    {
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene(buildIndex);
    }
/*    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            GameComplete();
        }
    }*/
}
