using UnityEngine.AI;
using UnityEngine;
public class EnemyIdleState : EnemyStateMachine
{
    private float m_timeElapsed;
    private float m_idleTime = 1;
    public override void OnEnterState(EnemyController _stateObject)
    {
        // Debug.Log("idle");
        base.OnEnterState(_stateObject);
    }
    public override void UpdateState()
    {
        m_timeElapsed += Time.deltaTime;
        if( m_timeElapsed >= m_idleTime )
        {
            base.ChangeState(EnemyState.PatrolState);
        }
    }
}
