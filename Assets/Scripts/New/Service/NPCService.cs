using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCService : Singleton<NPCService>
{
    [SerializeField] private List<NPCObject> m_npcObject;
    public void Spawn()
    {
        int index = Random.Range(0,m_npcObject.Count);
        NPModel m_npModel = new NPModel(m_npcObject[index]);
        NPController m_controller = new NPController(m_npModel, m_npcObject[index].View);
    }
}
