using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public PlayerControls.PlayerActions PlayerActions => GameManager.Instance.inputManager.PlayerActions;

#if UNITY_EDITOR
    //아직 어디서 할지 모르겠지만 Debuging용입니다
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        ToggleInput();
    //    }
    //}

    //public void ToggleInput()
    //{
    //    if (PlayerActions.enabled)
    //    {
    //        Cursor.lockState = CursorLockMode.None;
    //        PlayerActions.Disable();
    //    }
    //    else
    //    {
    //        Cursor.lockState = CursorLockMode.Locked;
    //        PlayerActions.Enable();
    //    }
    //}

#endif
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        GameManager.Instance?.inputManager.EnablePlayerAction();
    }
    private void OnDisable()
    {
        GameManager.Instance.inputManager.DisablePlayerAction();
    }
}
