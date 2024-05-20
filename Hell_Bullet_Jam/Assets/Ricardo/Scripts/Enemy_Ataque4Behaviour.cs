using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ataque4Behaviour : StateMachineBehaviour
{
    [SerializeField] private GameObject ataquePrefabIzq;
    [SerializeField] private GameObject ataquePrefabDer;
    private GameObject prefab1;
    private GameObject prefab2;
    private Transform spawnPoint1;
    private Transform spawnPoint2;

    public float detectionRange = 5.0f;

    private bool IsEnemyNearSpawnPoint(Vector3 enemyPosition, Transform spawnPoint)
    {
        return Mathf.Abs(enemyPosition.x - spawnPoint.position.x) <= detectionRange;
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        spawnPoint1 = GameObject.Find("Spawn1").transform;
        spawnPoint2 = GameObject.Find("Spawn2").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (IsEnemyNearSpawnPoint(animator.transform.position, spawnPoint1) && prefab1 == null)
        {
            prefab1 = Instantiate(ataquePrefabIzq, spawnPoint1.position, spawnPoint1.rotation);
        }
        else
        {
            Destroy(prefab1);
        }

        if (IsEnemyNearSpawnPoint(animator.transform.position, spawnPoint2) && prefab2 == null)
        {
            prefab2 = Instantiate(ataquePrefabDer, spawnPoint2.position, spawnPoint2.rotation);
        }
        else
        {
            Destroy(prefab2);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(prefab1);
        Destroy(prefab2);
    }

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
