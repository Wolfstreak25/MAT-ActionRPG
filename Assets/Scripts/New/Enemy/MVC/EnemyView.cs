using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyView : MonoBehaviour
{
    public Transform Target;
    public ContactFilter2D detectionFilter;
    private EnemyController m_controller;
    private Vector3 m_movement;
    private float m_rotation;
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_controller.Fire();
        }
        m_controller.m_stateMachine.Update();
    }
    private void FixedUpdate()
    {
        float side = Input.GetAxisRaw("Horizontal");
        float forward = Input.GetAxisRaw("Vertical");
        m_controller.Move(side,forward);
        m_controller.Turn();
    }
    public void SetController(EnemyController _controller)
    {
        m_controller = _controller;
    }
    private void OnDrawGizmosSelected() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 5f);
    }
    public void DestroyObj()
    {
        Destroy(this.gameObject);
    }
    public bool isDead()
    {
        return m_controller.IsKilled;
    }
}