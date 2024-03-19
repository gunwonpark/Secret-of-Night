using UnityEngine;
using UnityEngine.UI;

public class PlayerStaminaTest : MonoBehaviour
{
    public Image sp;
    void Update()
    {
        sp.fillAmount = GameManager.Instance.playerManager.playerData.CurSP / GameManager.Instance.playerManager.playerData.MaxSP;
    }
}
