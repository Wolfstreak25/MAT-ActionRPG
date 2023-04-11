using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Object List", menuName = "Objects/New Player Object List")]
public class PlayerList : ScriptableObject
{
    public PlayerObject[] Players;
}