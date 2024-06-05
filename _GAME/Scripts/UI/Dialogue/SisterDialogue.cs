public class SisterDialogue : FriendDialogue
{
    protected override void DialogueController()
    {
        UIDialogue.instance.SetDialogue(Dialogue.lstDialogue9);
    }
    protected override void ShowUIMission() 
    {
        GameManager.instance.GameComplete();
    }
}
