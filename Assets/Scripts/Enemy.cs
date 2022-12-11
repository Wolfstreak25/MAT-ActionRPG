using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animator animator;

    public float Health {
        set {
            health = value;

            if(health <= 0) {
                Debug.Log("Defeated");
                RemoveEnemy();
            }
        }
        get {
            return health;
        }
    }

    public float health = 3;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void RemoveEnemy() {
        Destroy(gameObject);
    }
}
