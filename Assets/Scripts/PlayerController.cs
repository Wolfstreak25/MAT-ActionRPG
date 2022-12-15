using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 movementInput;
    Rigidbody2D rb; 
    Animator animator;
    SpriteRenderer spriteRenderer;
    public int Health;
    public int Experiance;
    public int Gold;
    public Quest quest;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float collisionOffset = 0.02f;
    [SerializeField] private ContactFilter2D movementFilter;
    [SerializeField] private SwordAttack SwordHit;
    bool canMove = true;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if(canMove){
            if(movementInput != Vector2.zero){
            bool isOnMove = isMoving(movementInput);
            if(!isOnMove){
                isOnMove = isMoving(new Vector2(movementInput.x, 0));
            }
            if(!isOnMove){
                isOnMove = isMoving(new Vector2(0, movementInput.y));
            }
            animator.SetBool("IsMoving", isOnMove);
            
            }
            else{
                animator.SetBool("IsMoving", false);
            }

            if(movementInput.x < 0){
                SwordHit.attackDirection = AttackDirection.Left;
            }else if(movementInput.x > 0){
                SwordHit.attackDirection = AttackDirection.Right;
            }else if(movementInput.y > 0){
                SwordHit.attackDirection = AttackDirection.Up;
            }else if(movementInput.y < 0){
                SwordHit.attackDirection = AttackDirection.Down;
            }
        }
        
    }
    private bool isMoving (Vector2 direction) {
        if(direction != Vector2.zero)
        {
            int count = rb.Cast(direction,movementFilter,castCollisions,moveSpeed* Time.fixedDeltaTime + collisionOffset);
            if(count == 0){
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else{
                return false;
            }
        }
        else{
            return false;
        }
    }
    void OnMove(InputValue movementvalue)
    {
         movementInput = movementvalue.Get<Vector2>();
         if(movementInput != Vector2.zero)
         {
            animator.SetFloat("Horizontal", movementInput.x);
            animator.SetFloat("Verticle", movementInput.y);
         }
    }
    void OnFire()
    {
        animator.SetTrigger("Attack");
    }
    public void MovementLocked()
    {
        canMove = false;
        SwordHit.Attack();
    }
    public void MovementUnLocked()
    {
        canMove = true;
        SwordHit.StopAttack();
    }

    public void Killed()
    {
        if(quest.isActive)
        {
            quest.goal.EnemyKilled();
            Debug.Log("Player Killed called");
            if(quest.goal.IsReached())
            {
                Experiance += quest.ExperienceReward;
                Gold += quest.GoldReward;
                quest.complete();
            }
        }
    }
    public void Collected()
    {
        
        if(quest.isActive)
        {
            Debug.Log("Player collected called");
            quest.goal.ItemCollected();
            if(quest.goal.IsReached())
            {
                Experiance += quest.ExperienceReward;
                Gold += quest.GoldReward;
                quest.complete();
            }
        }
    }
}
