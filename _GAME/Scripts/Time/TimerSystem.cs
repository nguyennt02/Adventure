using System;
using UnityEngine;

public class TimerSystem : NewMonoBehaviour
{
    private static TimerSystem _instance;
    public static TimerSystem instance => _instance;

    [NonSerialized] public string timerText;
    [NonSerialized] public float elapsedTime; // Biến lưu trữ thời gian đã trôi qua
    private bool _isRunning; // Biến để kiểm soát trạng thái của bộ đếm thời gian

    protected override void Awake()
    {
        base.Awake();
        LoadInstance();
        DontDestroyOnLoad(gameObject);
    }

    private void LoadInstance()
    {
        if (_instance) Destroy(_instance.gameObject);
        _instance = this;
    }
    void Start()
    {
        elapsedTime = 0f;
        _isRunning = true;
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (_isRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }
    // Hàm để cập nhật hiển thị thời gian trên UI
    void UpdateTimerDisplay()
    {
        int hours = Mathf.FloorToInt(elapsedTime / 3600F);
        int minutes = Mathf.FloorToInt((elapsedTime % 3600F) / 60F);
        int seconds = Mathf.FloorToInt(elapsedTime % 60F);

        if(hours == 0) timerText = $"{minutes:00}:{seconds:00}";
        else timerText = $"{hours:00}:{minutes:00}:{seconds:00}";
    }

    // Hàm để bắt đầu bộ đếm thời gian
    public void StartTimer()
    {
        _isRunning = true;
    }

    // Hàm để dừng bộ đếm thời gian
    public void StopTimer()
    {
        _isRunning = false;
    }

    // Hàm để đặt lại bộ đếm thời gian
    public void ResetTimer()
    {
        elapsedTime = 0f;
        UpdateTimerDisplay();
    }
    public void SetTimer()
    {
        elapsedTime = PlayerPrefs.GetFloat(PlayerPrefsConst.TIMER_PP, 0f);
    }
}
