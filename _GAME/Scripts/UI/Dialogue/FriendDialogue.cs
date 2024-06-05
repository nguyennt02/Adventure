using UnityEngine;

public class FriendDialogue : NewMonoBehaviour
{
    [SerializeField] protected GameObject _keyE;
    protected bool _isPlayer = false;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadKeyE();
    }

    protected virtual void LoadKeyE()
    {
        if (_keyE) return;
        LogWarning("LoadKeyE");
        _keyE = transform.Find("KeyE").gameObject;
    }
    protected virtual void Update()
    {
        if (!_isPlayer || !InputWindows.instance.KeyE()) return;
        UIManager.instance.ActiveUIDialogue();
        UIDialogue.instance.ShowDialogue();
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.CompareTag(TagConst.PLAYER_TAG) || other.isTrigger) return;
        _keyE.SetActive(true);
        _isPlayer = true;
        UIDialogueOsv.Enable += DialogueController;
        UIDialogueOsv.Disable += ShowUIMission;
    }
    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag(TagConst.PLAYER_TAG) || other.isTrigger) return;
        _keyE.SetActive(false);
        _isPlayer = false;
        UIDialogueOsv.Enable -= DialogueController;
        UIDialogueOsv.Disable -= ShowUIMission;
    }

    protected virtual void DialogueController()
    {
        if (!MissionsFruitsManager.instance.isComplete)
            FirstDialogue();
        else
            SecondDialogue();
    }
    protected virtual void FirstDialogue()
    {
        UIDialogue.instance.SetDialogue(Dialogue.lstDialogue1);
        MissionsFruitsManager.instance.StartMission();
    }
    protected virtual void SecondDialogue()
    {
        UIDialogue.instance.SetDialogue(Dialogue.lstDialogue2);
    }
    protected virtual void ShowUIMission()
    {
        if(!MissionsFruitsManager.instance.isComplete)
            UIManager.instance.ActiveUIMission();
        else
        {
            UIManager.instance.DesActiveUIMission();
            CheckPonitManager.instance.ChangePoint(new Vector2(-12, 3));
            GameManager.instance.LoadSceneGame(2);
        }
    }
    protected virtual void OnDestroy()
    {
        if (!_isPlayer) return;
        UIDialogueOsv.Enable -= DialogueController;
        UIDialogueOsv.Disable -= ShowUIMission;
    }
}
