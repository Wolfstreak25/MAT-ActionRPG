using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : SwordAttack
{
    // Start is called before the first frame update
    private void Awake() {
        Debug.Log("trigger active");
    }
    public float damage = 3;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy") {
            Debug.Log("enemy hit");
            Enemy enemy = other.GetComponent<Enemy>();

            if(enemy != null) {
                enemy.Health -= damage;
            }
        }
    }
}
