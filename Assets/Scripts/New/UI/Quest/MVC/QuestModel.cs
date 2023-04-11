using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestModel
{
    private QuestController m_controller;
    private QuestObject m_questObject;
    private int m_currentAmmount = 0;
    public QuestModel(QuestObject _questObject)
    {
        m_questObject = _questObject;
    }
    public void SetController(QuestController _controller)
    {
        m_controller = _controller;
    }
    public string QuestTitle    {   get{return m_questObject.questTitle;}   }
    public string QuestDescription    {   get{return m_questObject.questDescription;} }
    public int GoldReward   {   get{return m_questObject.goldReward;} }
    public int ExperienceReward   {   get{return m_questObject.experienceReward;} }
    public GoalType GoalType    { get {return m_questObject.goalType;} }
    public int RequiredAmmount  { get {return m_questObject.requiredAmmount;} }
    public int CurrentAmmount   { get {return m_currentAmmount;} set{ m_currentAmmount = value;} }
    public bool IsReached   {   get{return(m_currentAmmount >= m_questObject.requiredAmmount);} }
}
public enum GoalType
{
    KillQuest,
    Gathering
}