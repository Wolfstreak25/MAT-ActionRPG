using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyView : MonoBehaviour
{
    private EnemyController m_controller;

    private Vector3 m_movement;
    private float m_rotation;
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_controller.Fire();
        }
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
    public void DestroyObj()
    {
        Destroy(this.gameObject);
    }
    public bool isDead()
    {
        return m_controller.IsKilled;
    }
}