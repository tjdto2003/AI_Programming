using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedOnState : StateMachineBehaviour {

    GameObject player;
    Tower tower;

    override public void OnStateEnter(Animator animator,AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindWithTag("Player");
        tower = animator.gameObject.GetComponent<Tower>();
        tower.LockedOn = true;
   }
    override public void OnStateUpdate(Animator animator,AnimatorStateInfo statInfo, int layerIndex)
    {
        animator.gameObject.transform.LookAt(player.transform);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo statInfo, int layerIndex)
    {
        animator.gameObject.transform.rotation = Quaternion.identity;
        tower.LockedOn = false;
        Destroy(animator.gameObject, 0.1f);
    }
    


        void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}
}
