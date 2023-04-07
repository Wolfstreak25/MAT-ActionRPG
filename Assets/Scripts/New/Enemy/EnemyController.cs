using UnityEngine;
using UnityEngine.UI;
public class EnemyController
{
    //Serializable

    //Methods
    public EnemyModel Model{get; private set;}
    public EnemyView View{get; private set;}
    public bool IsKilled{get;private set;}
    public Animator animator{get;private set;}

    //Private
    private Vector3 m_movement; 
    
    public EnemyController(EnemyModel Enemymodel, EnemyView _view)
    {
        IsKilled = false;
        this.Model = Enemymodel;
        View = GameObject.Instantiate<EnemyView>(_view);
        this.View.SetController(this);
        this.Model.SetController(this);
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
