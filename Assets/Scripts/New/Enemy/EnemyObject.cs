using System;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Enemy Player Object", menuName = "Objects/New Enemy Player Object")]
public class EnemyObject : ScriptableObject
{
   [Header("Object Type")]
   [Header("Player Properties")]
   public EnemyView View;
   public EnemyType EnemyType;
   [Header("Player stats")]
   public float Speed;
   public int Health;
   public int Damage;
   [Header("Detection parameters")]
   public float EngageRadius;
   public float AttackRadius;
   public float attackDelay;
}
