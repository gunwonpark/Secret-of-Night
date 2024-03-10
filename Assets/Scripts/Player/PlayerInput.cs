using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerControls InputActions { get; private set; }
    public PlayerControls.PlayerActions PlayerActions { get; private set; }

    private void Awake()
    {
        InputActions = new PlayerControls();
        PlayerActions = InputActions.Player;
    }

    private void OnEnable()
    {
        InputActions.Enable();
    }
    private void OnDisable()
    {
        InputActions.Disable();
    }
}
