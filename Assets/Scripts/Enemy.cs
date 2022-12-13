using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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
        animator.SetTrigger("Death");
        Instantiate(CollectiblePrefab, transform.position, Quaternion.identity);
    }

    public void RemoveEnemy() {
        Destroy(gameObject);
    }
}
