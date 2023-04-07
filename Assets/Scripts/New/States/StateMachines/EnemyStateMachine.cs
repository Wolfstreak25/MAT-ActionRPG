using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;
public class EnemyStateMachine : StateInterface<EnemyController>
{
    protected float timeElapsed = 0f;
    protected EnemyController enemy;
    protected NavMeshAgent agent;
    protected Animator Anim;
    private EnemyStateMachine currentState;
    private StateMachine<EnemyController> stateMachine;
    private EnemyState currState;
    private void Start() 
    {
        stateMachine = new StateMachine<EnemyController>(enemy);
    }
    protected void ObjectInitialization(EnemyController stateObject)
    {
    }
    public override void OnEnterState(EnemyController ObjectState)
    {
        ObjectInitialization(ObjectState);
    }
    public  override void OnExitState(EnemyController ObjectState)
    {
        if(currentState != null)
        {
            GenericPool<EnemyStateMachine>.Release(currentState);
        }
        
    }
    public void ChangeState(EnemyState newState)
    {
        switch(newState)
        {
            case EnemyState.IdleState:
                currentState = GenericPool<EnemyIdleState>.Get();
                break;
            case EnemyState.PatrolState:
                currentState = GenericPool<EnemyPatrolState>.Get();
                break;
            case EnemyState.ChaseState:
                currentState = GenericPool<EnemyChaseState>.Get();
                break;
            case EnemyState.AttackState:
                currentState = GenericPool<EnemyAttackState>.Get();
                break;
            case EnemyState.DeathState:
                currentState = GenericPool<EnemyDeathState>.Get();
                break;
        }
        stateMachine.ChangeState(currentState);
    }
}