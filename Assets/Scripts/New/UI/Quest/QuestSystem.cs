using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
// this is basically quest view
public class QuestSystem : Singleton<QuestSystem>
{
    private QuestObject m_questObject;
    private QuestController m_questController;
    [SerializeField] private GameObject m_questPanel;
    [SerializeField] private TMP_Text m_questTitle;
    [SerializeField] private TMP_Text m_questDescription;
    [SerializeField] private TMP_Text m_rewardGold;
    [SerializeField] private TMP_Text m_rewardExperience;
    [SerializeField] private GameObject m_collectReward;
    [SerializeField] private GameObject m_acceptQuest;
    
    public void ShowQuest(QuestController _questController)
    {
        m_questController = _questController;
        m_questPanel.SetActive(true);
        if(!m_questController.isAccepted)
        {
            m_acceptQuest.SetActive(true);
        }
        if(m_questController.isAccepted && m_questController.isGoalReached)
        {
            m_collectReward.SetActive(true);
        }
        m_questTitle.text = m_questController.Model.QuestTitle;
        m_questDescription.text = m_questController.Model.QuestDescription;
        m_rewardGold.text = $"{m_questController.Model.GoldReward}";
        m_rewardExperience.text = $"{m_questController.Model.ExperienceReward}";
    }
    public void AcceptQuest()
    {
        m_questController.isAccepted = true;
        EventManagement.Instance.QuestAccepted(m_questController);
        CloseWindow();
    }
    public void CollectReward()
    {
        EventManagement.Instance.RewardCollected(m_questController.Model.GoldReward, m_questController.Model.ExperienceReward);
        CloseWindow();
    }
    public void CloseWindow()
    {
        m_acceptQuest.SetActive(false);
        m_collectReward.SetActive(false);
        m_questPanel.SetActive(false);
    }
}
