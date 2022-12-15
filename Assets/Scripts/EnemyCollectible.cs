using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollectible : MonoBehaviour
{
    public PlayerController player;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player") 
            {
                Debug.Log("Item Collected");
                player.Collected();
                Destroy(gameObject);
            }
    }
}
