using UnityEngine;

public class MonsterDyingState : MonsterBaseState
{

    public MonsterDyingState(MonsterStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        stateMachine.MovementSpeedModifier = 0;
        stateMachine.FieldMonsters.monsterAnimation.StartDieAnimation();

        DeleteMonster();
    }

    public override void Exit()
    {
        base.Exit();
    }

    private void DeleteMonster()
    {
        Object.Destroy(this.stateMachine.FieldMonsters.gameObject, 2f);

        for (int i = 1; i < stateMachine.FieldMonsters.myInfo.DropItem.Length; i++)
        {
            stateMachine.FieldMonsters.dropItem(GameManager.Instance.dataManager.itemDataBase.GetData(stateMachine.FieldMonsters.myInfo.DropItem[i]));
        }

    }
}
