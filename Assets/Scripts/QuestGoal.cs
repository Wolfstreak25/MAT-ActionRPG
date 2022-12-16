using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;
    public int RequiredAmmount;
    public int CurrentAmmount;
    public bool IsReached()
    {
        return(CurrentAmmount>=RequiredAmmount);
    }
    public void EnemyKilled()
    {
        Debug.Log("QuestGoal Enemy Killed called");
        if(goalType == GoalType.KillQuest)
        {
            CurrentAmmount ++;
        }
    }
    public void ItemCollected()
    {
        Debug.Log("QuestGoal Item Collected called");
        if(goalType == GoalType.Gathering)
        {
            CurrentAmmount ++;
        }
    }
}
public enum GoalType{
    KillQuest,
    Gathering
}
