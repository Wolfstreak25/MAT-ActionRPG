using UnityEngine;
using UnityEngine.UI;
public class NPController
{
    //Serializable

    //Properties
    public NPModel Model{get; private set;}
    public NPView View{get; private set;}
    public Animator NPCAnimator{get;private set;}
    //Private
    private Rigidbody2D m_rigidBody;
    private Vector3 m_movement;
    
    public NPController(NPModel _model, NPView _view)
    {
        this.Model = _model;
        View = GameObject.Instantiate<NPView>(_view);
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
