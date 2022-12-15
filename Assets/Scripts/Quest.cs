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
    public QuestGoal goal;
    public void complete() {
        isActive = false;
        Debug.Log(Title +" is Completed");

    }

}
