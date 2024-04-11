using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class StaminaSystem : MonoBehaviour
{
    PlayerController player;
    public float staminaDecreaseRate = 5f;
    public float leastStaminaToRun = 5f;

    void Awake()
    {
        player = GetComponent<PlayerController>();
    }
    void Update()
    {
        //스테미나는 MaxSP전까지 계속 증가
        if (player.GetCurrentState() != typeof(PlayerRunState))
        {
            if (player.PlayerData.CurSP < player.PlayerData.MaxSP)
            {
                player.PlayerData.SPChange(Time.deltaTime);
            }
        }
        else
        {
            //달리기 상태일 경우 스테미나 감소
            player.PlayerData.SPChange(-Time.deltaTime * staminaDecreaseRate);
        }

        //스테미나가 0이하일 경우 움직이지 못하게 한다 
        if (player.PlayerData.CurSP <= 0)
        {
            player.MovementSpeedModifier = 0;
            player.IsRunning = false;
            player.IsTired = true;
        }

        if (player.IsTired && player.PlayerData.CurSP >= leastStaminaToRun)
        {
            player.IsTired = false;
        }

    }



}
