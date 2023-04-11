using System;
public class EventManagement : Singleton<EventManagement>
{
    public event Action<EnemyType> OnEnemyDeath;
    public event Action OnPlayerDeath;
    public event Action<QuestController> OnQuestAccepted;
    public event Action<QuestController> OnQuestCompleted;
    public event Action<int,int> OnRewardCollected; 
    public void PlayerDeath()
    {
        OnPlayerDeath?.Invoke();
    }
    public void EnemyDeath(EnemyType _type)
    {
        OnEnemyDeath?.Invoke(_type);
    }
    public void QuestCompleted(QuestController _questController)
    {
        OnQuestCompleted?.Invoke(_questController);
    }
    public void QuestAccepted(QuestController _questController)
    {
        OnQuestAccepted?.Invoke(_questController);
    }
    public void RewardCollected(int _gold, int _experience)
    {
        OnRewardCollected?.Invoke(_gold, _experience);
    }
}
