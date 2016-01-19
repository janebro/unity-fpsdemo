using UnityEngine;
using System.Collections;

public class RandomIntBehaviour : StateMachineBehaviour {

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state. 
    //Essa função é chamada no primeiro frame do estado sendo tocado.
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks.
    //Essa função é chamada a cada chamada de Update (MonoBehaviour) do objeto em que esse animator está adicionado.
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //Essa função é chamada no último frame de uma transição para outro estado.
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //Essa função é chamada logo depois da função Animator.OnAnimationMove(). 
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //Essa função é chamada logo depois da função Animator.OnAnimationMove().
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.SetInteger("AttackRandom", Random.Range(0, 3));
        //Debug.Log(animator.)
    }

}
