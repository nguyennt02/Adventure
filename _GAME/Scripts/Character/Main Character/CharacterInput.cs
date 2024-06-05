using UnityEngine;

public static class CharacterInput
{
    public static bool isInput = true;
    public struct FrameInput
    {
        public bool JumpDown;
        public bool JumpHeld;
        public bool Dash;
        public bool Hold;
        public Vector2 Move;
    }
    public static FrameInput Input
    {
        get
        {
            if (isInput)
                return new FrameInput()
                {
                    JumpDown = InputWindows.instance.JumpDown(),
                    JumpHeld = InputWindows.instance.JumpHeld(),
                    Dash = InputWindows.instance.Dash(),
                    Hold = InputWindows.instance.Hold(),
                    Move = InputWindows.instance.Move()
                };
            else
                return new FrameInput();
        }
    }
}
