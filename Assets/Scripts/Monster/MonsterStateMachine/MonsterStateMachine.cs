using UnityEngine;

public class MonsterStateMachine : StateMachine
{
    public FieldMonsters FieldMonsters { get; }
    public MonsterSpot MonsterSpot { get; }

    public Transform Target { get; private set; }
    public Vector3 MyOriginalTransform { get; private set; }


    //state
    public MonsterIdleState IdleState { get; }
    public MonsterChasingState ChasingState { get; }
    public MonsterAttackState AttackState { get; }
    public MonsterDyingState DyingState { get; }
    public MonsterPatrolState PatrolState { get; }

    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;
    public float rotationDamping { get; private set; }

    public MonsterStateMachine(FieldMonsters fieldMonster)
    {
        FieldMonsters = fieldMonster;
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        MyOriginalTransform = MonsterSpot.MyOriginalPosition;
        Debug.Log(MyOriginalTransform);

        IdleState = new MonsterIdleState(this);
        ChasingState = new MonsterChasingState(this);
        AttackState = new MonsterAttackState(this);

        MovementSpeed = FieldMonsters.myInfo.MoveSpeed;
        rotationDamping = fieldMonster.rotationDamping;
    }
}
