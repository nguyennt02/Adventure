using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDialogue : NewMonoBehaviour
{
    bool _isActive = false;
    bool _isEnableDialogue = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(TagConst.PLAYER_TAG) || other.isTrigger || _isActive) return;
        _isActive = true;
        UIDialogueOsv.Enable += EnableDialogue;
        UIDialogueOsv.Disable += DisableDialogue;
        UIManager.instance.ActiveUIDialogue();
        UIDialogue.instance.ShowDialogue();
    }

    private void EnableDialogue()
    {
        UIDialogue.instance.SetDialogue(Dialogue.lstDialogue8);
    }

    private void DisableDialogue()
    {
        _isEnableDialogue = true;
        UIDialogueOsv.Enable -= EnableDialogue;
        UIDialogueOsv.Disable -= DisableDialogue;
    }
    protected virtual void Update()
    {
        if (!_isActive || _isEnableDialogue || !InputWindows.instance.KeyE()) return;
        UIDialogue.instance.ShowDialogue();
    }
}
