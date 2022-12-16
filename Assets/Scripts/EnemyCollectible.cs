using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollectible : MonoBehaviour
{
    public CollectibleType type;
    public Sprite Icon;
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if(other.tag == "Player") 
            {
                Debug.Log("Item Collected");
                player.Collected(this);
                Destroy(gameObject);
            }
    }
}
public enum CollectibleType
{
    none,
    EnemySlime,
    Coins,
}
