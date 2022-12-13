using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NPC : MonoBehaviour
{
    public GameObject DialoguePanel;
    public GameObject ContButton;
    public TMP_Text Dialoguetext;
    public string[] Dialogue;
    private int Index;
    public float wordSpeed;
    public bool PlayerInRange;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&& PlayerInRange)
        {
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
            PlayerInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            Debug.Log("NPC Out of Range");
            PlayerInRange = false;
            Zerotext();
        }
    }
}
