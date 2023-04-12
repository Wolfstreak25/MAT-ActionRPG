using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCService : Singleton<NPCService>
{
    [SerializeField] private NPCObject m_npcObject;
    public void Spawn()
    {
        NPModel m_npModel = new NPModel(m_npcObject);
        NPController m_controller = new NPController(m_npModel, m_npcObject.View);
    }
    public void Spawn(Transform _spawn)
    {
        NPModel m_npModel = new NPModel(m_npcObject);
        NPController m_controller = new NPController(m_npModel, m_npcObject.View, _spawn);
    }
}
