
using UnityEngine;

public class PlayerModel
{
    public float turnSpeed;
    private int m_health;
    private PlayerController m_playerController;
    private PlayerObject m_playerData;
    public PlayerModel(PlayerObject _playerObjectData)
    {
        m_playerData = _playerObjectData;
    }
    public void SetController(PlayerController _playercontroller)
    {
        m_playerController = _playercontroller;
    }
    public int Health   {   get{return m_health;}   set{m_health = value;}  }
    public float Speed   {   get{return m_playerData.Speed;}  }
}
