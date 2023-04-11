using System;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Quest Object", menuName = "Objects/New Quest Object")]
public class QuestObject : ScriptableObject
{
   [Header("Quest Type")]
   public QuestType questType;
   [Header("Quest Properties")]
   // public QuestView View;
   [Header("Quest Details")]
   public String questTitle;
   public String questDescription;
   public int experienceReward;
   public int goldReward;
   [Header("Quest Goal")]
   public GoalType goalType;
   public int requiredAmmount;
}


//to be implemented
//drawer functionality
// //selection an option will return desired tray
//    public QuestType questType;
//    if(QuestType = gathering)
//    {
//       //show related stuff in editor
//       //collectible type
//       //required ammount
//       //etc
//    }
//    if(QuestType = extermination)
//    {
//       //show related stuff in editor
//       //enemy type
//       //required ammount
//       //etc
//    }