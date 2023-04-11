using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Pool;
public class EnemyStateMachine : StateInterface<EnemyController>
{
    protected EnemyController m_character;
    protected Rigidbody2D m_rigidBody;
    protected Animator m_animator;
    private EnemyStateMachine m_currentState;
    private StateMachine<EnemyController> m_stateMachine;
    private EnemyState m_thisState;
    private void Start() 
    {
        m_stateMachine = new StateMachine<EnemyController>(m_character);
    }
    protected void ObjectInitialization(EnemyController _character)
    {
        m_character = _character;
        m_rigidBody = m_character.rigidBody;
    }
    public override void OnEnterState(EnemyController _character)
    {
        // Debug.Log("StateEnemy");
        ObjectInitialization(_character);
    }
    public  override void OnExitState(EnemyController _objectState)
    {
        if(m_currentState != null)
        {
            GenericPool<EnemyStateMachine>.Release(m_currentState);
        }
        
    }
    public void ChangeState(EnemyState _newState)
    {
        switch(_newState)
        {
            case EnemyState.IdleState:
                m_currentState = GenericPool<EnemyIdleState>.Get();
                break;
            case EnemyState.PatrolState:
                m_currentState = GenericPool<EnemyPatrolState>.Get();
                break;
            case EnemyState.ChaseState:
                m_currentState = GenericPool<EnemyChaseState>.Get();
                break;
            case EnemyState.AttackState:
                m_currentState = GenericPool<EnemyAttackState>.Get();
                break;
            case EnemyState.DeathState:
                m_currentState = GenericPool<EnemyDeathState>.Get();
                break;
        }
        m_character.m_stateMachine.ChangeState(m_currentState);
    }
}