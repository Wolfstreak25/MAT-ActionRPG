using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC Object List", menuName = "Objects/New NPC Object List")]
public class NPCList : ScriptableObject
{
    public NPCObject[] NPCs;
}