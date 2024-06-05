using UnityEngine;

public class InputWindows : InputManager
{
    private static InputWindows _instance;
    public static InputWindows instance => _instance ?? (_instance = new InputWindows());
    public override bool Dash() => Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.K);

    public override bool Hold() => Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.L);

    public override bool JumpDown() => Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.J);

    public override bool JumpHeld() => Input.GetButton("Jump") || Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.J);

    public override bool KeyE() => Input.GetKeyDown(KeyCode.E);

    public override Vector2 Move() => new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
}
