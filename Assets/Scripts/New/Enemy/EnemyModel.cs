
using UnityEngine;

public class EnemyModel
{
    public float TurnSpeed;
    private float m_health;
    private EnemyObject m_enemyObject;
    private EnemyController EnemyController;
    
    public EnemyModel(EnemyObject _enemyObject)
    {
        m_enemyObject = _enemyObject;
    }
    public void SetController(EnemyController Enemycontroller)
    {
        EnemyController = Enemycontroller;
    }
    public float Health {get{return m_health;}set{m_health =  (int)value;}}
    public EnemyType Type   {get{return m_enemyObject.EnemyType;}}
}
