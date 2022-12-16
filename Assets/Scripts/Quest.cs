using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Quest
{
    public bool isActive;
    public string Title;
    public string Description;
    public int GoldReward;
    public int ExperienceReward;
    public GameObject QuestComplete;
    public GameObject RewardButton;
    public GameObject AcceptButton;
    public QuestGoal goal;
    public void complete() {
        SoundManager.Instance.Play(Sounds.Complete);
        isActive = false;
        Debug.Log(Title +" is Completed");
        RewardButton.SetActive(true);
        AcceptButton.SetActive(false);
    }
    public IEnumerator CompletionMessage()
    {
        Debug.Log("Coroutine called");
        QuestComplete.SetActive(true);
        yield return new WaitForSeconds(5.0f);
        QuestComplete.SetActive(false);
    }
}
   