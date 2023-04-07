using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : EnemyStateMachine
{
    public override void OnEnterState(EnemyController stateObject)
    {
        base.OnEnterState(stateObject);
        Chase();
    }
    public override void UpdateState() 
    { 
    }
    void Chase()
    {
    }
}