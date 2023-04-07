using UnityEngine.AI;
using UnityEngine;
public class EnemyAttackState : EnemyStateMachine
{
    public override void OnEnterState(EnemyController stateObject)
    {
        base.OnEnterState(stateObject);
    }
    
    public override void UpdateState() 
    {
    }
    void Attack(Transform target)
    {
    }
}
