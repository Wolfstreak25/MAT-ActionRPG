using System;
public class EventManagement : Singleton<EventManagement>
{
    public event Action OnEnemyDeath;
    public event Action OnPlayerDeath;
    public event Action<int> OnWaveComplete;
    public void PlayerDeath()
    {
        OnPlayerDeath?.Invoke();
    }
    public void EnemyDeath()
    {
        OnEnemyDeath?.Invoke();
    }
    public void WaveComplete(int wave)
    {
        OnWaveComplete?.Invoke(wave);
    }
}
