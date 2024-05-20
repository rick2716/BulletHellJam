using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ataque3Behaviour : StateMachineBehaviour
{
    [SerializeField] private GameObject ataquePrefab;
    [SerializeField] private Vector2 offset;
    public float spawnTimer;
    private float timer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer > spawnTimer)
        {
            Transform playerPosition = GameObject.Find("Player").GetComponent<Transform>();
            Vector2 spawn = new Vector2(playerPosition.position.x + offset.x, playerPosition.position.y + offset.y);
            Instantiate(ataquePrefab, spawn, Quaternion.identity);
            timer = 0f;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
