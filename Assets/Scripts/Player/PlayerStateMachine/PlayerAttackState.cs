// TODO 공격 모션 수정 요망

using UnityEngine;

public class PlayerAttackState : PlayerBaseState
{

    public PlayerAttackState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }
    public override void Enter()
    {
        base.Enter();
        stateMachine.Player.MovementSpeedModifier = 0f;
        int SkillID = GameManager.Instance.dataManager.playerStatDataBase.GetData(stateMachine.Player.PlayerData.CharacterID).Skills[0];
        string path = GameManager.Instance.dataManager.playerSkillDataBase.GetData(SkillID).PrefabPath;
        Debug.Log("Attack");
        GameObject go = Resources.Load<GameObject>($"Prefabs/Skills/{path}");
        Object.Instantiate(go, stateMachine.Player.transform.position, Quaternion.identity);
        StartAnimation(stateMachine.Player.AnimationData.AttackParameter);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.AttackParameter);
    }

    public override void Update()
    {
        base.Update();

        if (!stateMachine.Player.IsAttacking)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }
    }
}
