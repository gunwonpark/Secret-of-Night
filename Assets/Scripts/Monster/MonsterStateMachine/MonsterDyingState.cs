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

        GameManager.Instance.monsterManager.DestroyMonster();
        //DeleteMonster();
    }

    public override void Exit()
    {
        base.Exit();
    }

    //private void DeleteMonster()
    //{
    //    Object.Destroy(GameManager.Instance.gameObject, 1f);
    //}
}
