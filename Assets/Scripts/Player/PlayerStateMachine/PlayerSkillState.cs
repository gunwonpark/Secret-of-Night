using UnityEngine;

public class PlayerSkill1State : PlayerBaseState
{
    public PlayerSkill1State(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.Player.MovementSpeedModifier = 0f;
        stateMachine.Player.IsAttacking = true;
        int SkillID = GameManager.Instance.dataManager.playerStatDataBase.GetData(stateMachine.Player.PlayerData.CharacterID).Skills[1];
        string path = GameManager.Instance.dataManager.playerSkillDataBase.GetData(SkillID).PrefabPath;

        GameObject go = Resources.Load<GameObject>($"Prefabs/Skills/{path}");
        Object.Instantiate(go, stateMachine.Player.transform.position + Vector3.up, stateMachine.Player.transform.rotation);

        StartAnimation(stateMachine.Player.AnimationData.Skill1);
    }
    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.Skill1);
    }
    public override void Update()
    {
        base.Update();
        float normalizedTime = GetNormalizedTime(stateMachine.Player.Animator, "Skill");

        if (normalizedTime > 1f)
        {
            stateMachine.Player.IsAttacking = false;
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
}
