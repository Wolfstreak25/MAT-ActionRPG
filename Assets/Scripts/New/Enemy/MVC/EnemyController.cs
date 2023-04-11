using UnityEngine;
public class EnemyController
{
    //Serializable
    public StateMachine<EnemyController> m_stateMachine;
    //Methods
    public EnemyModel Model     {get; private set;}
    public EnemyView View       {get; private set;}
    public Rigidbody2D rigidBody    {get; private set;}
    public bool IsKilled        {get; private set;}
    public Animator animator    {get; private set;}
    //Private
    private Vector3 m_movement;
    private EnemyStateMachine m_currentState = new EnemyIdleState();
    public EnemyController(EnemyModel _enemyModel, EnemyView _view)
    {
        m_stateMachine = new StateMachine<EnemyController>(this);
        IsKilled = false;
        this.Model = _enemyModel;
        View = GameObject.Instantiate<EnemyView>(_view);
        this.View.SetController(this);
        this.Model.SetController(this);
        SetActive();
    }
    public void SetActive()
    {
        // Debug.Log("setActive");
        m_stateMachine.ChangeState(m_currentState);
        rigidBody = View.gameObject.GetComponent<Rigidbody2D>();
    }
    public void Fire()
    {
    }
    public void Move(float h, float v)
    {
    }
    public void Turn()
    {
    }
    public void GetDamage(float damage)
    {
    }
}