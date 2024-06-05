using UnityEngine;

public abstract class InputManager
{
    public abstract bool JumpDown();
    public abstract bool JumpHeld();
    public abstract bool Dash();
    public abstract bool Hold();
    public abstract Vector2 Move();
    public abstract bool KeyE();
}
