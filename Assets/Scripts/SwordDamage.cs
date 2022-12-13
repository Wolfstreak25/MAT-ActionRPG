using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
        public float damage = 3;
        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.tag == "Enemy") 
            {
                Debug.Log("enemy hit");
                Enemy enemy = other.GetComponent<Enemy>();

                if(enemy != null) {
                enemy.Health -= damage;
                }
            }
        }
}
