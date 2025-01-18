using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    enum State
    {
        None,
        Idle,
        Move,
        Hit,
        Die
    }

    [SerializeField] private State currentState = State.None;
    
    //Declaration
    Animator       am;
    PlayerMovement pm;
    SpriteRenderer sr;
    private bool   canChangeState = false;

    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();

        ChangeState(State.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.moveDir.x != 0 || pm.moveDir.y != 0){
            ChangeState(State.Move);
            SpriteDirectionChecker();
        }
        else {
            ChangeState(State.Idle);
        }
        
    }

    void ChangeState(State newState)
    {
        if (!canChangeState || currentState == newState || currentState == State.Die) return;
        
        am.Play(currentState.ToString());
    }

    public void Hit()
    {
        ChangeState(State.Hit);
    }
    
    public void Die()
    {
        ChangeState(State.Die);
    }

    void SpriteDirectionChecker(){
        if (pm.lastHorizontalVector < 0 ){
            sr.flipX = true;
        }
        else sr.flipX = false;


    }


}
