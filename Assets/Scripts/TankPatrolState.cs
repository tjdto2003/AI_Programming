using System.Collections;

using UnityEngine;

public class TankPatrolState : StateMachineBehaviour{
    
    override public void OnStateEnter(Animator animator,AnimatorStateInfo stateInfo,int layerIndex)
    {
        TankAi tankAi = animator.gameObject.GetComponent<TankAi>();
        tankAi.SetNextPoint();
    }
    override public void OnStateUpdate(Animator animator,AnimatorStateInfo stateInfo, int layerIndex)
    {
        //base.OnStateUpdate(animator, stateinfo, layerIndex);
    }
    override public void OnStateExit(Animator animator,AnimatorStateInfo stateInfo, int layerIndex)
    {
        //base.OnStateExit(animator, stateinfo, layerIndex);
    }
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //base.OnStateMove(animator, stateinfo, layerIndex);
    }
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //base.OnStateIK((animator, stateinfo, layerIndex);
    }



}
