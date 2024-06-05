using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDialogue : NewMonoBehaviour
{
    private static UIDialogue _instance;
    public static UIDialogue instance => _instance;

    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private bool _showTextCoroutine;
    [SerializeField] private float _delayTime;
    private List<BlogText> _lstDialogue;
    private int _index = 0;
    private bool _finished = true;

    protected virtual void OnEnable()
    {
        CharacterInput.isInput = false;
        UIManager.instance.DesActiveUIGamePLay();
        UIDialogueOsv.Enable?.Invoke();
    }

    protected virtual void OnDisable()
    {
        CharacterInput.isInput = true;
        UIManager.instance.ActiveUIGamePlay();
        UIDialogueOsv.Disable?.Invoke();
    }

    protected override void Awake()
    {
        base.Awake();
        LoadInstance();
    }

    private void LoadInstance()
    {
        if (_instance) LogError("UIDialogue already exist");
        _instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadText();
    }

    private void LoadText()
    {
        if (_text) return;
        LogWarning("LoadText");
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void ShowDialogue()
    {
        if (!_finished) return;
        if (_index == _lstDialogue.Count)
        {
            UIManager.instance.DesActiveUIDialogue();
            _index--;
            return;
        }
        _finished = false;
        if (_showTextCoroutine)
            StartCoroutine(ShowTextCoroutine());
        else
            ShowText();
    }
    public void SetDialogue(List<BlogText> lstDialogue)
    {
        if (lstDialogue == _lstDialogue) return;
        _lstDialogue = lstDialogue;
        _index = 0;
    }
    private void ShowText()
    {
        _text.text = $"{_lstDialogue[_index].speaker}: {_lstDialogue[_index].text}";
        EndShowText();
    }
    private IEnumerator ShowTextCoroutine()
    {
        _text.text = $"{_lstDialogue[_index].speaker}: ";
        for (int i = 0; i < _lstDialogue[_index].text.Length; i++)
        {
            yield return new WaitForSeconds(_delayTime);
            _text.text += _lstDialogue[_index].text[i];
        }
        EndShowText();
    }
    private void EndShowText()
    {
        _index++;
        _finished = true;
    }
    public void ResetDialogue()
    {
        _index = 0;
    }
}
public static class UIDialogueOsv
{
    public static Action Enable;
    public static Action Disable;
}
