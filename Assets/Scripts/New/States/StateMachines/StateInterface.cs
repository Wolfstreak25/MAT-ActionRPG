public abstract class StateInterface<T>
{
    public virtual void OnEnterState(T ObjectState)
    {}
    public virtual void UpdateState()
    {}
    public virtual void OnExitState(T ObjectState)
    {}
}