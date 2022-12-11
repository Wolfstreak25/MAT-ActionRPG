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
    public GameObject[] SwordStrike;
    public void Attack()
    {
        switch (attackDirection)
        {
            case AttackDirection.Left :
                SwordStrike[0].SetActive(true);
                break;
            case AttackDirection.Right :
                SwordStrike[1].SetActive(true);
                break;
            case AttackDirection.Up :
                SwordStrike[2].SetActive(true);
                break;
            case AttackDirection.Down :
                SwordStrike[3].SetActive(true);
                break;
        };
    }
    public void StopAttack() {
        SwordStrike[0].SetActive(false);
        SwordStrike[1].SetActive(false);
        SwordStrike[2].SetActive(false);
        SwordStrike[3].SetActive(false);
    }
    
}
