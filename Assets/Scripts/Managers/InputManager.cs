using UnityEngine;

public class InputManager : MonoBehaviour
{
    public PlayerControls InputActions { get; private set; }
    public PlayerControls.PlayerActions PlayerActions { get; private set; }
    public PlayerControls.UIActions UIActions { get; private set; }

    public void Initialize()
    {
        InputActions = new PlayerControls();
        PlayerActions = InputActions.Player;
        UIActions = InputActions.UI;

        InputActions.Enable();
    }

    public void EnablePlayerAction()
    {
        PlayerActions.Enable();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void DisablePlayerAction()
    {
        PlayerActions.Disable();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void EnableUIAction()
    {
        UIActions.Enable();
    }
    public void DisableUIAction()
    {
        UIActions.Disable();
    }
}