using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Declare variables

    public float moveSpeed;
    public float dashSpeed;
    public float dashCooldown;
    public float dashDuration;
    Rigidbody2D rb;
    bool isDashing = false;
    bool canDash = true;
    public float lastHorizontalVector;
    public float lastVerticalVector;
    public Vector2 moveDir;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canDash = true;
    }

    // Update is called once per frame
    void Update(){
        InputManagement();
    }

    void FixedUpdate(){
        Move();
    }

    void InputManagement(){
        if (isDashing){
            return;
        };
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY =  Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(moveX, moveY).normalized;
        if (moveDir.x != 0){
            lastHorizontalVector = moveDir.x;
        }

        if (moveDir.y !=0){
            lastVerticalVector = moveDir.y;
        }
        if (Input.GetKeyDown(KeyCode.Space) && canDash){
            StartCoroutine(Dash());
        }

    }

    void Move(){
        if (isDashing){
            return;
        };
        rb.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }

    IEnumerator Dash(){
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(moveDir.x * dashSpeed, moveDir.y * dashSpeed);    
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }

}
