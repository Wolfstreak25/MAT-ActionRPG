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
    [SerializeField] private GameObject HoverKey;
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private GameObject ContButton;
    [SerializeField] private GameObject RewardButton;
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
        if(quest.goal.IsReached())
        {
            Questbutton.SetActive(true);
            Index = 7;
            Typing();
        }
        else if(Dialoguetext.text == Dialogue[6])
        {
            Questbutton.SetActive(true);
        }
        else if(Dialoguetext.text == Dialogue[Index])
        {
            ContButton.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CloseQuestWindow();
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
        SoundManager.Instance.Play(Sounds.ButtonClick);
        ContButton.SetActive(false);
        if(Index < Dialogue.Length - 2)
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
            HoverKey.SetActive(true);
            PlayerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            Debug.Log("NPC Out of Range");
            HoverKey.SetActive(false);
            PlayerInRange = false;
            Zerotext();
        }
    }
    public void OpenQuestWindow()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        Debug.Log("open Quest Window Called");
        DialoguePanel.SetActive(false);
        QuestWindow.SetActive(true);
        QuestTitle.text=quest.Title;
        QuestDescription.text= quest.Description;
        RewardGold.text=quest.GoldReward.ToString();
        RewardExperience.text= quest.ExperienceReward.ToString();
        if(quest.goal.IsReached())
        {QuestDescription.text = "Thank you Adventurer for your help. please take this reward for your trouble";}
    }   
    public void AcceptQuest()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        Debug.Log("Accept Quest called");
        QuestWindow.SetActive(false);
        quest.isActive = true;
        player.quest = quest;
    }
    public void QuestReward()
    {
        SoundManager.Instance.Play(Sounds.PickObject);
        player.Gold += quest.GoldReward;
        player.Experiance += quest.ExperienceReward;
        Questbutton.SetActive(false);
        RewardButton.SetActive(false);
    }
    public void CloseQuestWindow()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        QuestWindow.SetActive(false);
    }
    public void CloseDialogueWindow()
    {
        SoundManager.Instance.Play(Sounds.ButtonClick);
        DialoguePanel.SetActive(false);
    }
}
