using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 movementInput;
    Rigidbody2D rb; 
    public float moveSpeed = 1f;
    public float collisionOffset = 0.02f;
    public ContactFilter2D movementFilter;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if(movementInput != Vector2.zero){
            bool isOnMove = isMoving(movementInput);
            if(!isOnMove){
                isOnMove = isMoving(new Vector2(movementInput.x, 0));
                if(!isOnMove){
                    isOnMove = isMoving(new Vector2(0, movementInput.y));
                }
            }
        }
        
    }
    private bool isMoving (Vector2 direction) {
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
    }
    void OnMove(InputValue movementvalue)
    {
         movementInput = movementvalue.Get<Vector2>();
    }
}
