using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game;

public class PlayerMovement : MonoBehaviour
{
    //Declare variables
    Rigidbody2D                   rb;
    public PlayerScriptableObject characterData;
    public PlayerSound            playerSound;
    public float                  lastHorizontalVector;
    public float                  lastVerticalVector;
    public Vector2                moveDir;

    private bool isDashing = false;
    bool         canDash   = true;

    public ParticleSystem dashParticle;



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

        if (GameManager.Instance.GetCurrentState() == GameManager.State.Paused)
        {if (Input.GetKeyDown(KeyCode.Escape)){
                GameManager.Instance.UnpauseGame();
            }
            return;
            }
        if (GameManager.Instance.GetCurrentState() == GameManager.State.None)
        {
        if (Input.GetKeyDown(KeyCode.Escape)){
            GameManager.Instance.PauseGame();
            return;}
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
    }

    void Move(){
        if (isDashing){
            return;
        };
        rb.velocity = new Vector2(moveDir.x * characterData.MoveSpeed, moveDir.y * characterData.MoveSpeed);

        if (moveDir == Vector2.zero)
        {
            playerSound.StopRun();
        }
        else playerSound.PlayRun();
    }

    IEnumerator Dash(){
        dashParticle.Play();
        playerSound.PlayDash();
        canDash = false;
        isDashing = true;
        rb.velocity = new Vector2(moveDir.x * characterData.DashSpeed, moveDir.y * characterData.DashSpeed);    
        yield return new WaitForSeconds(characterData.DashDuration);
        isDashing = false;
        yield return new WaitForSeconds(characterData.DashCooldown);
        canDash = true;
        dashParticle.Stop();
    }

}
