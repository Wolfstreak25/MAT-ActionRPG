
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class NPModel
{
    //Serializable

    //Properties
    
    //Private 
    private NPController m_controller;
    private NPCObject m_object;
    private string[] m_dialogueText;
    public NPModel(NPCObject _object)
    {
        m_object = _object;
        m_dialogueText = new string[5]
        {
            m_object.dialogueObject.greetingText,
            m_object.dialogueObject.problemQuestText,
            m_object.dialogueObject.giveQuestText,
            m_object.dialogueObject.midQuestText,
            m_object.dialogueObject.postQuestText
        };
        Debug.Log(m_dialogueText);
    }
    public void SetController(NPController _controller)
    {
        m_controller = _controller;
    }
    public string[] DialogueTexts    
    {   
        get
        {
            return m_dialogueText;
        }
        private set
        {
            DialogueCombine();
        }    
    } 
    public QuestObject QuestData    {   get{return m_object.questObject;}   }
    private void DialogueCombine()
    {
            
    }
    
}

    // private Dictionary<DialogueType,string> m_dialogues = new Dictionary<DialogueType, string>();
    // private void AttachDialogue()
    // {
    //     foreach (var _dialogue in m_dialogueText)
    //     {
    //         m_dialogues.Add(DialogueType.GreetingText, dialogueObject.dialogueText[0]);
    //     }
        
    //     string dialogue = m_dialogues[DialogueType.GreetingText];
    // }
