using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NPC : MonoBehaviour
{
    private bool PlayerInRange;
    private int Index;
    //Dialogue Pannel
    [SerializeField] private GameObject UICamera;
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject HoverKey;
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private GameObject ContButton;
    [SerializeField] private GameObject Questbutton;
    [SerializeField] private TMP_Text Dialoguetext;
    [SerializeField] private string[] Dialogue;
    [SerializeField] private float wordSpeed;

    //Quest Pannel
    public Quest quest;
    public PlayerController player;
    [SerializeField] private GameObject QuestWindow;
    [SerializeField] private TMP_Text QuestTitle;
    [SerializeField] private TMP_Text QuestDescription;
    [SerializeField] private TMP_Text RewardGold;
    [SerializeField] private TMP_Text RewardExperience;
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&& PlayerInRange)
        {
            HoverKey.SetActive(false);
            if(DialoguePanel.activeInHierarchy)
            {
                Zerotext();
            }else{
                DialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
        if(Dialoguetext.text == Dialogue[Index])
        {
            ContButton.SetActive(true);
        }
    }
    public void Zerotext()
    {
        Dialoguetext.text="";
        Index = 0;
        DialoguePanel.SetActive(false);
    }
    IEnumerator Typing()
    {
        foreach(char letter in Dialogue[Index].ToCharArray())
        {
            Dialoguetext.text +=letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    public void NextLine()
    {
        ContButton.SetActive(false);
        if(Index < Dialogue.Length - 1)
        {
            Index++;
            Dialoguetext.text="";
            StartCoroutine(Typing());
        }
        else{
            Zerotext();
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("NPC Detected");
        if (other.CompareTag("Player"))
        {   
            MainCamera.SetActive(false);
            UICamera.SetActive(true);
            HoverKey.SetActive(true);
            PlayerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            Debug.Log("NPC Out of Range");
            UICamera.SetActive(false);
            MainCamera.SetActive(true);
            HoverKey.SetActive(false);
            PlayerInRange = false;
            Zerotext();
        }
    }
    public void OpenQuestWindow(){
        DialoguePanel.SetActive(false);
        QuestWindow.SetActive(true);
        QuestTitle.text=quest.Title;
        QuestDescription.text= quest.Description;
        RewardGold.text=quest.GoldReward.ToString();
        RewardExperience.text= quest.ExperienceReward.ToString();

    }
    public void AcceptQuest()
    {
        QuestWindow.SetActive(false);
        quest.isActive = true;
        player.quest = quest;
    }
}
