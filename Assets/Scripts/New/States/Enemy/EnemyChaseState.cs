using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseState : EnemyStateMachine
{
    public override void OnEnterState(EnemyController stateObject)
    {
        // Debug.Log("Chase");
        base.OnEnterState(stateObject);
        Chase();
    }
    public override void UpdateState() 
    { 
        var colide =  Physics2D.OverlapCircle(m_rigidBody.transform.position,5f);
        if(colide != null)
        {
            if(colide.gameObject.GetComponent<PlayerView>() == null)
            {
                base.ChangeState(EnemyState.IdleState);
            }
        }
    }
    void Chase()
    {
    }
}