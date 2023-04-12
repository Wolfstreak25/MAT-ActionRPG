using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyService : Singleton<EnemyService>
{
    [SerializeField] private EnemyObject m_enemyObject;
    public void Spawn()
    {
        EnemyModel m_enemyModel = new EnemyModel(m_enemyObject);
        EnemyController m_controller = new EnemyController(m_enemyModel, m_enemyObject.View);
    }
    public void Spawn(Transform _spawn)
    {
        EnemyModel m_enemyModel = new EnemyModel(m_enemyObject);
        EnemyController m_controller = new EnemyController(m_enemyModel, m_enemyObject.View,_spawn);
    }
}
