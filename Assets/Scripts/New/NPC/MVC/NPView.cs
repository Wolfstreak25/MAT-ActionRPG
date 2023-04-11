using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NPView : MonoBehaviour
{
    //Serializable
    [SerializeField] private GameObject HoverKey;
    //Properties
    
    //Private 
    private NPController m_controller;
    private bool m_playerInRange;
//     void Update()
//     {
//         if(Input.GetKeyDown(KeyCode.E)&& PlayerInRange)
//         {
//             HoverKey.SetActive(false);
//             if(DialoguePanel.activeInHierarchy)
//             {
//                 Zerotext();
//             }else{
//                 DialoguePanel.SetActive(true);
//                 StartCoroutine(Typing());
//             }
//         }
//      }
//     private bool PlayerInRange;
    private int Index;

    private void Update() 
    {
        if(m_playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            m_controller.ShowDialogue();
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {

        if (other.gameObject.GetComponent<PlayerView>())
        {   
            HoverKey.SetActive(true);
            m_playerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.GetComponent<PlayerView>())
        {
            HoverKey.SetActive(false);
            m_playerInRange = false;
            //Zerotext();
        }
    }
    public void SetController(NPController _controller)
    {
        m_controller = _controller;
    }
    public void DestroyObj()
    {
        //Destroy(this.gameObject);
    }
}