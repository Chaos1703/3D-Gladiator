using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public enum EnemyState { chase , attack};
public class EnemyController : MonoBehaviour
{
    private NavMeshAgent myAgent;
    private CharacterAnimations enemyAnimations;
    private Transform target;
    public float attackDistance = 1f , moveSpeed = 3.5f , chaseAfterAttackDistance = 1f;
    private float waitBeforeAttackTime = 1f , attackTimer;
    private EnemyState enemyState;
    public GameObject attackPoint;

    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
        enemyAnimations = GetComponent<CharacterAnimations>();
        target = GameObject.FindWithTag("Player").transform;
    }

    void Start()
    {
        enemyState = EnemyState.chase;
        attackTimer = waitBeforeAttackTime;
    }

    void Update()
    {
        if (enemyState == EnemyState.chase)
        {
            Chase();
        }
        if (enemyState == EnemyState.attack)
        {
            Attack();
        }
    }

    void Chase()
    {
        myAgent.SetDestination(target.position);
        myAgent.speed = moveSpeed;
        if (myAgent.velocity.sqrMagnitude == 0)
        {
            enemyAnimations.Walk(false);
        }
        else
        {
            enemyAnimations.Walk(true);
        }
        if (Vector3.Distance(transform.position , target.position) <= attackDistance)
        {
            enemyState = EnemyState.attack;
        }
    }

    void Attack()
    {
        myAgent.velocity = Vector3.zero;
        myAgent.isStopped = true;
        enemyAnimations.Walk(false);
        attackTimer += Time.deltaTime;
        if (attackTimer > waitBeforeAttackTime)
        {
            if(Random.Range(0,2) > 0)
            {
                enemyAnimations.Attack1();
            }
            else
            {
                enemyAnimations.Attack2();
            }
            attackTimer = 0f;
        }
        if (Vector3.Distance(transform.position , target.position) > attackDistance + chaseAfterAttackDistance)
        {
            myAgent.isStopped = false;
            enemyState = EnemyState.chase;
        }
    }

    void ActivateAttackPoint()
    {
        attackPoint.SetActive(true);
    }

    void DeactivateAttackPoint()
    {
        if (attackPoint.activeInHierarchy)
        {
            attackPoint.SetActive(false);
        }
    }
}
