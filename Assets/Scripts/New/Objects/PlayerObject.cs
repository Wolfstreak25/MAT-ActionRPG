using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Player Object", menuName = "Objects/New Player Object")]
public class PlayerObject : ScriptableObject
{
    [Header("Object Type")]
    public PlayerView PlayerView;
    [Header("Model Type")]
    public PlayerType PlayerType;
    [Header("Speed")]
    public float Speed;
    [Header("Hitpoints")]
    public int Health;
    [Header("Power")]
    public int Damage;
    [Header("Material")]
    public Material color;
}
