using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueView : Singleton<DialogueView>
{
    [SerializeField] private GameObject m_dialoguePanel;
    [SerializeField] private GameObject m_continueButton;
    [SerializeField] private GameObject m_questButton;
    [SerializeField] private TMP_Text m_dialogueText;
    [System.NonSerialized] public DialogueObject dialogueObject;
    [SerializeField] private float m_wordSpeed = 0.1f;
    private NPController m_npController;
    private string[] m_dialogues;
    private int m_index = 0;
    public void ShowDialogue(NPController _npController)
    {
        m_index = 0;
        m_dialoguePanel.SetActive(true);
        m_npController = _npController;
        m_dialogues = m_npController.Model.DialogueTexts;
        PrintLine();
    }
    public void Zerotext()
    {
        m_dialogueText.text="";
        m_dialoguePanel.SetActive(false);
    }
    IEnumerator Typing(string _dialogue)
    {
        foreach(char letter in _dialogue.ToCharArray())
        {
            m_dialogueText.text +=letter;
            yield return new WaitForSeconds(m_wordSpeed);
        }
        m_continueButton.SetActive(true);
    }
    public void PrintLine()
    {
        m_continueButton.SetActive(false);
        // Print first three dialogues
        if(!m_npController.IsQuestGiven && m_index < 3)
        {
            m_dialogueText.text="";
            StartCoroutine( Typing(m_dialogues[m_index])    );
            if(m_index == 2)
            {
                m_questButton.SetActive(true);
                m_continueButton.SetActive(false);
            }
            m_index++;
        }
        // Print mid Quest Dialogue
        else if(m_npController.IsQuestGiven && !m_npController.IsGoalReached)
        {
            m_dialogueText.text="";
            StartCoroutine( Typing( m_dialogues[(int)DialogueType.MidQuestText] ) );
        }
        // Print quest complete dialogue
        else if(m_npController.IsGoalReached && !m_npController.IsRewardCollected)
        {
            m_dialogueText.text="";
            StartCoroutine( Typing(  m_dialogues[(int)DialogueType.PostQuestText]   )   );
        }
        else
        {
            Zerotext();
        }
    }
    public void QuestPopUp()
    {
        m_npController.ShowQuest();
        m_dialoguePanel.SetActive(false);
    }

}

    // This Implementation is also good

    // private Dictionary<DialogueType,string> m_dialogues = new Dictionary<DialogueType, string>();
    // private void AttachDialogue()
    // {
    //     m_dialogues.Add(DialogueType.GreetingText, dialogueObject.dialogueText[0]);
    //     string dialogue = m_dialogues[DialogueType.GreetingText];
    // }