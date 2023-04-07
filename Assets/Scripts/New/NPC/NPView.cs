using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPView : MonoBehaviour
{
    //Serializable

    //Properties
    
    //Private 
    private NPController m_controller;
    // private void Update() 
    // {
    // }
    // private void FixedUpdate()
    // {
    // }
    public void SetController(NPController _controller)
    {
        m_controller = _controller;
    }
    public void DestroyObj()
    {
        Destroy(this.gameObject);
    }
}