using UnityEngine;

public class VillageChiefDialogue : FriendDialogue
{
    protected override void DialogueController()
    {
        if (!MissionEnemyManager.instance.isComplete)
            FirstDialogue();
        else
            SecondDialogue();
    }
    protected override void FirstDialogue()
    {
        UIDialogue.instance.SetDialogue(Dialogue.lstDialogue4);
        MissionEnemyManager.instance.StartMission();
    }
    protected override void SecondDialogue()
    {
        UIDialogue.instance.SetDialogue(Dialogue.lstDialogue5);
    }
    protected override void ShowUIMission()
    {
        if (!MissionEnemyManager.instance.isComplete)
            UIManager.instance.ActiveUIMission();
        else
        {
            UIManager.instance.DesActiveUIMission();
            CheckPonitManager.instance.ChangePoint(new Vector2(-13, -1));
            GameManager.instance.LoadSceneGame(3);
        }
    }
}
