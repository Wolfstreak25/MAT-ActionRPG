using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController
{
    public QuestModel Model{get; private set;}
    public Animator NPCAnimator{get;private set;}
    public bool isAccepted = false;
    public bool isGoalReached = false;
    public bool isQuestComplete = false;
    public bool isRewardCollected = false;
    //Private
    public QuestController(QuestModel _model)
    {
        this.Model = _model;
        this.Model.SetController(this);
    }  
    public void EnemyKilled()
    {
        if(Model.GoalType == GoalType.KillQuest)
        {
            Model.CurrentAmmount ++;
        }
    }
    public void ItemCollected()
    {
        if(Model.GoalType == GoalType.Gathering)
        {
            Model.CurrentAmmount ++;
        }
    }
    public void AcceptQuest()
    {
    }
    public void QuestReward()
    {
    }
    public void CloseQuestWindow()
    {
    }
}
