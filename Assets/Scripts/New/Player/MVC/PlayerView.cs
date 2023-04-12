using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class PlayerView : MonoBehaviour
{
    //Serializables
    [SerializeField] private Rigidbody2D m_rigidBody;
    public bool isQuestActive;
    [SerializeField] private ContactFilter2D m_movementFilter;
    //Properties
    public Animator PlayerAnimator{ get{    return this.gameObject.GetComponent<Animator>();    }   }
    public Rigidbody2D Rigidbody{   get{    return m_rigidBody; }    }
    //privates
    private PlayerController m_controller;
    private Vector2 m_movement;
    private float m_rotation;
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_controller.Attack();
        }
    }
    private void FixedUpdate()
    {
        float side = Input.GetAxisRaw("Horizontal");
        float forward = Input.GetAxisRaw("Vertical");
        m_controller.Move(side,forward);
    }
    public void SetController(PlayerController _controller)
    {
        m_controller = _controller;
    }
    public void DestroyObj()
    {
        Destroy(this.gameObject);
    }
}