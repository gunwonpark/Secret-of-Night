using UnityEngine;

public class DefaultAttackEffect : StateMachineBehaviour
{
    public float triggerTimeNormalized = 0.5f;
    private bool _actionExecuted = false;

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called before OnStateUpdate is called on any state inside this state machine
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float progressTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime % 1f;
        if (progressTime < triggerTimeNormalized)
        {
            _actionExecuted = false; // Reset flag if the animation has not reached the desired point
        }

        // Check if the animation has reached the desired point and the action hasn't been executed yet
        if (!_actionExecuted && animator.transform.GetComponentInParent<PlayerController>().IsAttacking && progressTime >= triggerTimeNormalized)
        {
            // Execute your action here
            Instantiate(GameManager.Instance.skillManager.GetSkill(101), animator.transform.position, Quaternion.identity);

            RaycastHit[] hits = Physics.BoxCastAll(animator.transform.position + Vector3.up / 2, animator.transform.lossyScale, animator.transform.forward,
                Quaternion.identity, 1f, LayerMask.GetMask("Monster"));

            foreach (var hit in hits)
            {
                Debug.Log(hit.transform.name);
                hit.transform.GetComponent<IDamageable>()?.TakeDamage(GameManager.Instance.dataManager.playerSkillDataBase.GetData(101).Damage
                    + GameManager.Instance.playerManager.playerData.Damage);
            }
            _actionExecuted = true; // Set flag to prevent repeated execution
        }
    }

    // OnStateExit is called before OnStateExit is called on any state inside this state machine
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called before OnStateMove is called on any state inside this state machine
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateIK is called before OnStateIK is called on any state inside this state machine
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMachineEnter is called when entering a state machine via its Entry Node
    //override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}

    // OnStateMachineExit is called when exiting a state machine via its Exit Node
    //override public void OnStateMachineExit(Animator animator, int stateMachinePathHash)
    //{
    //    
    //}
}
