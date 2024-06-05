public class FriendDialogue2 : FriendDialogue
{
    protected override void DialogueController()
    {
        UIDialogue.instance.SetDialogue(Dialogue.lstDialogue6);
    }
    protected override void ShowUIMission() { }
}
