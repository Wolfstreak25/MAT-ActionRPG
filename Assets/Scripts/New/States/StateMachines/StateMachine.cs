using UnityEngine;
public class StateMachine<T>
{
    private T ObjectState = default;
    public StateInterface<T> CurrentState = default;
    public StateMachine(T ObjectState)
    {
        this.ObjectState = ObjectState;
    }
    public void Update() 
    {
        CurrentState?.UpdateState();
    }
    public void ChangeState(StateInterface<T> NewState)
    {
        // Debug.Log("ChangeState");
        CurrentState?.OnExitState(ObjectState);
        CurrentState = NewState;
        CurrentState?.OnEnterState(ObjectState);
    }
}
