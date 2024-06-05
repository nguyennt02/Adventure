public class FriendDialogue1 : FriendDialogue
{
    protected override void DialogueController()
    {
        UIDialogue.instance.SetDialogue(Dialogue.lstDialogue3);
    }
    protected override void ShowUIMission() { }
}
