using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOne : MonoBehaviour
{
    [SerializeField] private Transform m_playerSpawn;
    [SerializeField] private Transform m_npcSpawn;
    [SerializeField] private Transform m_enemySpawn;
    void Start()
    {
        PlayerService.Instance.Spawn(m_playerSpawn);
        EnemyService.Instance.Spawn(m_enemySpawn);
        NPCService.Instance.Spawn(m_npcSpawn);
    }
    
}
