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
#if UNITY_EDITOR
    //아직 어디서 할지 모르겠지만 Debuging용입니다
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleInput();
        }
    }

    public void ToggleInput()
    {
        if (PlayerActions.enabled)
        {
            Cursor.lockState = CursorLockMode.None;
            PlayerActions.Disable();
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            PlayerActions.Enable();
        }
    }

#endif
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        InputActions.Enable();
    }
    private void OnDisable()
    {
        InputActions.Disable();
    }
}
