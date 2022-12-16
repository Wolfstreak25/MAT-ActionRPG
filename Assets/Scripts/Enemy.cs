using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerController player;
    [SerializeField] private GameObject CollectiblePrefab;
    Animator animator;

    public float Health {
        set {
            health = value;

            if(health <= 0) {
                Defeated();
            }
        }
        get {
            return health;
        }
    }

    public float health = 1;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void Defeated(){
        SoundManager.Instance.Play(Sounds.EnemyKill);
        animator.SetTrigger("Death");
        Debug.Log("Enemy killed");
        player.Killed();
        Instantiate(CollectiblePrefab, transform.position, Quaternion.identity);
    }

    public void RemoveEnemy() {
        Destroy(gameObject);
    }
}
