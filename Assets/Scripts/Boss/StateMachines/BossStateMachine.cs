using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateMachine : StateMachine
{
    public Boss Boss { get; }
    public Transform Target { get; private set; }

    public BossIdleState IdlingState { get; }
    public BossChasingState ChasingState { get; }
    public BossAttackState AttackState { get; }


    public Vector2 MovementInput { get; set; }
    public float MovementSpeed { get; private set; }
    public float RotationDamping { get; private set; }
    public float MovementSpeedModifier { get; set; } = 1f;

    public BossStateMachine(Boss boss)
    {
        Boss = boss;
        Target = GameObject.FindGameObjectWithTag("Player").transform;

        IdlingState = new BossIdleState(this);
        ChasingState = new BossChasingState(this);
        AttackState = new BossAttackState(this);

        MovementSpeed = 5f;
        RotationDamping = 10f;

        ChangeState(IdlingState);
    }
}
