using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue Object", menuName = "Objects/New Dialogue Object")]
public class DialogueObject : ScriptableObject
{
    [Header("Object Type")]
    public NPCType npcType;
    public ObjectType objectType;
    public string greetingText;
    public string problemQuestText;
    public string giveQuestText;
    public string midQuestText;
    public string postQuestText;
    
    // private string[] m_dialogueText = new string[5];
    // public string[] dialogues 
    // { 
    //     get
    //     {
    //         m_dialogueText[0] = greetingText;
    //         m_dialogueText[1] = problemQuestText;
    //         m_dialogueText[2] = giveQuestText;
    //         m_dialogueText[3] = midQuestText;
    //         m_dialogueText[4] = postQuestText;
    //         return m_dialogueText;
    //     }
    // }
}
