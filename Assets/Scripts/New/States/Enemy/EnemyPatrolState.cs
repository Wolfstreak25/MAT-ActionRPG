using UnityEngine;
using UnityEngine.AI;
public class EnemyPatrolState : EnemyStateMachine
{
    public override void OnEnterState(EnemyController stateObject)
    {
        base.OnEnterState(stateObject);
        Patrol();
    }
    public override void UpdateState() 
    {
        
    }
    void Patrol()
    {
    }
}
