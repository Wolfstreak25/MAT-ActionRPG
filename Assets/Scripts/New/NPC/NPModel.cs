
using UnityEngine;

public class NPModel
{
    //Serializable

    //Properties
    
    //Private 
    private NPController m_controller;
    private NPCObject m_object;
    public NPModel(NPCObject _object)
    {
        m_object = _object;
    }
    public void SetController(NPController _controller)
    {
        m_controller = _controller;
    }
}
