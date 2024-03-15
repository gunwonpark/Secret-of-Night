using UnityEngine;

public class MonsterStateMachine : StateMachine
{
    public FieldMonsters FieldMonsters { get; }

    public Transform Target { get; private set; }

    //state
    public MonsterIdleState IdleState { get; }
    public MonsterChasingState ChasingState { get; }
    public MonsterAttackState AttackState { get; }

    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;

    public MonsterStateMachine(FieldMonsters fieldMonster)
    {
        FieldMonsters = fieldMonster;
        Target = GameObject.FindGameObjectWithTag("Player").transform;

        IdleState = new MonsterIdleState(this);
        ChasingState = new MonsterChasingState(this);
        AttackState = new MonsterAttackState(this);

        MovementSpeed = FieldMonsters.myInfo.MoveSpeed;
        //RotationDamping = enemy.Data.GroundedData.BaseRotationDamping;
    }
}
