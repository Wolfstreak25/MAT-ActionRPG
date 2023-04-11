using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC Object", menuName = "Objects/New NPC Object")]
public class NPCObject : ScriptableObject
{
    [Header("Object Type")]
    public ObjectType objectType;
    public NPView View;
    public NPCType npcType;
    public DialogueObject dialogueObject;
    public QuestObject questObject;
}
