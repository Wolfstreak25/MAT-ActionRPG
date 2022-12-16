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
    [SerializeField] private GameObject RewardButton;
    [SerializeField] private GameObject Acceptbutton;
    [SerializeField] private GameObject QuestComplete;
    public QuestGoal goal;
    public bool complete() {
        isActive = false;
        Debug.Log(Title +" is Completed");
        Acceptbutton.SetActive(false);
        RewardButton.SetActive(true);

        return(true);
    }

}
