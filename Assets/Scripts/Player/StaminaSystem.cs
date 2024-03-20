using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class StaminaSystem : MonoBehaviour
{
    PlayerController player;
    public float staminaDecreaseRate = 0.1f;
    public float leastStaminaToRun = 7f;
    void Awake()
    {
        player = GetComponent<PlayerController>();
    }
    void Update()
    {
        if (!player.IsRunning)
        {
            AddSP(ref player.PlayerData.CurSP);
        }
        else
        {
            SubSP(ref player.PlayerData.CurSP);
        }

        if (player.IsTired)
        {
            if (player.PlayerData.CurSP > leastStaminaToRun)
            {
                player.IsTired = false;
            }
        }
        else
        {
            //tired상태가 
            float tired = Mathf.InverseLerp(leastStaminaToRun, 0, player.PlayerData.CurSP);
            player.MovementSpeedModifier = player.runSpeed * 1 - tired;
            player.Animator.SetFloat(player.AnimationData.Tired, tired);
        }
    }

    public void AddSP(ref float CurSP, float amount = 3f)
    {
        if (CurSP < player.PlayerData.MaxSP)
        {
            CurSP = Mathf.Min(player.PlayerData.MaxSP, CurSP + amount * Time.deltaTime);
        }
    }
    public void SubSP(ref float CurSP, float amount = 10f)
    {
        if (CurSP > 0)
        {
            CurSP = Mathf.Max(0, CurSP - amount * Time.deltaTime);
        }
        else
        {
            player.IsTired = true;
        }
    }
    public void OnRunStart()
    {
        StartCoroutine("DoStaminaSystem");
    }
    IEnumerator DoStaminaSystem()
    {
        WaitForSeconds delayTime = new WaitForSeconds(staminaDecreaseRate);
        while (player.IsRunning && player.PlayerData.CurSP > 0)
        {
            player.PlayerData.CurSP -= 1f;
            yield return delayTime;
        }
        if (player.PlayerData.CurSP <= 0)
        {
            player.IsTired = true;
        }

    }
}
