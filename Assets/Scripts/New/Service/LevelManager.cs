using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    private void Start() 
    {
        PlayerService.Instance.Spawn();
        EnemyService.Instance.Spawn();
    }
}
