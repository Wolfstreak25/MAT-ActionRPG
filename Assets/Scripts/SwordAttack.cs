using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public enum AttackDirection
{
    Left,
    Right,
    Up,
    Down
}
public class SwordAttack : MonoBehaviour
{
    public AttackDirection attackDirection;
    [SerializeField] private Collider2D[] SwordStrike;
    public void Attack()
    {
        switch (attackDirection)
        {
            case AttackDirection.Left :
                SwordStrike[0].enabled = true;
                break;
            case AttackDirection.Right :
                SwordStrike[1].enabled = true;
                break;
            case AttackDirection.Up :
                SwordStrike[2].enabled = true;
                break;
            case AttackDirection.Down :
                SwordStrike[3].enabled = true;
                break;
        };
    }
    public void StopAttack() {
        SwordStrike[0].enabled = false;
        SwordStrike[1].enabled = false;
        SwordStrike[2].enabled = false;
        SwordStrike[3].enabled = false;
    }
    
}
