using UnityEngine;
using System;

public class AudioManager : NewMonoBehaviour
{
    [SerializeField] protected Sound[] musicSounds, sfxSounds;
    [SerializeField] protected AudioSource musicSource, sfxSource;

    private static AudioManager _instance;
    public static AudioManager instance => _instance;
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

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadMusicSource();
        LoadSFXSource();
    }

    private void LoadSFXSource()
    {
        if (sfxSource != null) return;
        LogWarning("LoadSFXSource");
        sfxSource = transform.Find("SFX").GetComponent<AudioSource>();
    }

    private void LoadMusicSource()
    {
        if (musicSource != null) return;
        LogWarning("LoadMusicSource");
        musicSource = transform.Find("Music").GetComponent<AudioSource>();
    }

    protected virtual void Start()
    {
        MusicVolume(PlayerPrefs.GetFloat("MusicVolume", 0.5f));
        SFXVolume(PlayerPrefs.GetFloat("SFXVolume", 0.5f));
        PlayMusic("Start");
    }
    public virtual void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if (s == null) Debug.LogError("Khong ton tai sound ten " + name);
        musicSource.clip = s.clip;
        musicSource.Play();
    }
    public virtual void StopMusic()
    {
        musicSource.Stop();
    }
    public virtual void StopSFX()
    {
        sfxSource.Stop();
    }
    public virtual void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null) Debug.LogError("Khong ton tai sound ten " + name);
        sfxSource.PlayOneShot(s.clip);
    }
    public virtual void ToggleMusic(bool isOn)
    {
        if (musicSource == null) return;
        musicSource.mute = !isOn;
    }

    public virtual void ToggleSFX(bool isOn)
    {
        if (sfxSource == null) return;
        sfxSource.mute = !isOn;
    }

    public virtual void MusicVolume(float value)
    {
        if (musicSource == null) return;
        musicSource.volume = value;
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    public virtual void SFXVolume(float value)
    {
        if (sfxSource == null) return;
        sfxSource.volume = value;
        PlayerPrefs.SetFloat("SFXVolume", value);
    }
}