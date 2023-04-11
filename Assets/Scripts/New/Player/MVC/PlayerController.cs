using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
public class PlayerController
{
    //Serializables
    public PlayerModel Model{get; private set;}
    public PlayerView View{get; private set;}
    [SerializeField] private float m_collisionOffset = 0.02f;
    private ContactFilter2D m_movementFilter;
    //Properties

    //privates
    private List<RaycastHit2D> m_castCollisions = new List<RaycastHit2D>();
    private Vector2 m_movement; 
    private Vector2 m_direction;
    private Rigidbody2D m_rigidBody;
    private QuestController m_questController;
    public PlayerController(PlayerModel _playerModel, PlayerView _playerView)
    {
        EventManagement.Instance.OnQuestAccepted += QuestAccepted;
        this.Model = _playerModel;
        View = GameObject.Instantiate<PlayerView>(_playerView);
        m_rigidBody = View.GetComponent<Rigidbody2D>();
        this.View.SetController(this);
        this.Model.SetController(this);
    }
    public void Attack()
    {
    }
    public void Move(float _horizontal, float _verticle)
    {
        m_direction.x = _horizontal;
        m_direction.y = _verticle;
        View.PlayerAnimator.SetFloat(   "Horizontal",   _horizontal );
        View.PlayerAnimator.SetFloat(   "Verticle", _verticle   );
        if(m_direction != Vector2.zero)
        {
            int count = m_rigidBody.Cast(   m_direction,   m_movementFilter,   m_castCollisions,   Model.Speed* Time.fixedDeltaTime + m_collisionOffset    );
            if(count == 0)
            {
                m_rigidBody.MovePosition(   m_rigidBody.position + m_direction * Model.Speed * Time.fixedDeltaTime  );
                return;
            }
            else
            {
                return;
            }
        }
        else
        {
            return ;
        }
    }
    private void QuestAccepted(QuestController _questController)
    {
        m_questController = _questController;
    }
    private void OnItemCollected()
    {
        if(m_questController != null)
            m_questController.ItemCollected();
    }
    private void OnEnemyKilled()
    {
        if(m_questController != null)
            m_questController.EnemyKilled();
    }
    public void GetDamage(float damage)
    {
    }
    private void OnDisable() 
    {
        EventManagement.Instance.OnQuestAccepted -= QuestAccepted;
    }
}
