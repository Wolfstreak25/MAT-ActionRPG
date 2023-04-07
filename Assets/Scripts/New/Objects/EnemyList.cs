using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Player Object List", menuName = "Objects/New Enemy Player Object List")]
public class EnemyList : ScriptableObject
{
    public EnemyObject[] Enemy;
}