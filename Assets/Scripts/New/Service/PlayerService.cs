using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerService : Singleton<PlayerService>
{
    [SerializeField] private PlayerObject m_playerObject;
    public void Spawn()
    {
        PlayerModel m_playerModel = new PlayerModel(m_playerObject);
        PlayerController m_controller = new PlayerController(m_playerModel, m_playerObject.PlayerView);
    }
}
