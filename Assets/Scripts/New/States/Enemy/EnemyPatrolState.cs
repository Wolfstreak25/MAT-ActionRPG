using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyPatrolState : EnemyStateMachine
{
    private float m_timeElapsed;
    public override void OnEnterState(EnemyController stateObject)
    {
        // Debug.Log("Patrol");
        base.OnEnterState(stateObject);
        Patrol();
    }
    public override void UpdateState() 
    {
        m_timeElapsed += Time.deltaTime;
        if(m_timeElapsed >= 1)
        {
            Patrol();
        }
        var colide =  Physics2D.OverlapCircle(m_rigidBody.transform.position,1f);
        if(colide != null)
        {
            if(colide.gameObject.GetComponent<PlayerView>() != null)
            {
                // Debug.Log("over");
                Vector2 Target = colide.gameObject.GetComponent<Transform>().position;
                base.ChangeState(EnemyState.ChaseState);
                m_rigidBody.transform.position = Vector2.MoveTowards(m_rigidBody.transform.position, Target, 1f );
            }
        }
    }
    void Patrol()
    {
        int randomMovement = Random.Range(0,4);
        
        switch(randomMovement)
        {
            case 0 :
                m_rigidBody.transform.position = new Vector2 (m_rigidBody.transform.position.x + 1 ,m_rigidBody.transform.position.y);
                break;
            case 1 :
                m_rigidBody.transform.position = new Vector2 (m_rigidBody.transform.position.x - 1 ,m_rigidBody.transform.position.y);
                break;
            case 2 :
                m_rigidBody.transform.position = new Vector2 (m_rigidBody.transform.position.x ,m_rigidBody.transform.position.y + 1);
                break;
            case 3 :
                m_rigidBody.transform.position = new Vector2 (m_rigidBody.transform.position.x ,m_rigidBody.transform.position.y - 1);
                break;
            default :
                base.ChangeState(EnemyState.IdleState);
                break;
        }
        m_timeElapsed = 0;
    }
}
