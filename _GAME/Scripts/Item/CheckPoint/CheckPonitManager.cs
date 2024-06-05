using System;
using UnityEngine;

public class CheckPonitManager : NewMonoBehaviour
{
    private static CheckPonitManager _instance;
    public static CheckPonitManager instance => _instance;

    [SerializeField] private float _delay;
    private Vector2 _point = Vector2.zero;
    [SerializeField] private GameObject _player;

    protected override void Awake()
    {
        base.Awake();
        LoadInstance();
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPlayer();
    }

    private void LoadPlayer()
    {
        if (_player) return;
        LogWarning("LoadPlayer");
        _player = GameObject.Find("Character");
    }

    private void LoadInstance()
    {
        if (_instance) LogError("CheckPonitManager already exist");
        _instance = this;
    }

    public void ChangePoint(Vector2 point)
    {
        _point = point;
    }
    private void Appearing()
    {
        _player.transform.position = _point;

        GameObject appear = AppearPooling.instance.GetPoolingObject();
        appear.transform.position = _player.transform.position;
        appear.SetActive(true);

        AudioManager.instance.PlaySFX("Rivival");

        Invoke(nameof(Active), _delay);
    }
    private void Active()
    {
        _player.SetActive(true);
    }
    public void Revival()
    {
        Invoke(nameof(Appearing), _delay);
    }
}
