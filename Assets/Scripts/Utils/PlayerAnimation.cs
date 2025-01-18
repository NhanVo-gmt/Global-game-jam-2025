using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Watermelon;

public class PlayerAnimation : MonoBehaviour
{
    enum State
    {
        None,
        Idle,
        Move,
        Hit,
        Die,
        Attack,
    }

    [SerializeField] private State currentState = State.None;

    [Header("Attack")]
    [SerializeField] private float attackDuration = 1f;

    [Header("Flash")]
    [SerializeField] private Color flashColor;
    [SerializeField] private int numberOfFlashes;
    
    //Declaration
    Animator       am;
    PlayerMovement pm;
    SpriteRenderer sr;

    private bool canChangeState = true;

    // Start is called before the first frame update
    void Start()
    {
        am = GetComponent<Animator>();
        pm = GetComponent<PlayerMovement>();
        sr = GetComponent<SpriteRenderer>();

        EnemySpawner_2.OnKillEnemy += OnKillEnemy;

        ChangeState(State.Idle);
    }
    
    private void OnKillEnemy()
    {
        ChangeState(State.Attack, false);
        Tween.DelayedCall(attackDuration, () => canChangeState = true);
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

    void ChangeState(State newState, bool newChangeState = true)
    {
        if (!canChangeState || currentState == newState || currentState == State.Die) return;

        canChangeState = newChangeState;
        currentState   = newState;
        am.Play(currentState.ToString());
    }

    public void Hit(float invincibleTime)
    {
        ChangeState(State.Hit);
        StartCoroutine(FlashCoroutine(invincibleTime, flashColor, numberOfFlashes));
    }

    public IEnumerator FlashCoroutine(float flashDuration, Color flashColor, int numberOfFlashes)
    {
        Color startColor             = sr.color;
        float elapsedFlashTime       = 0;
        float elapsedFlashPercentage = 0;

        while (elapsedFlashTime < flashDuration)
        {
            elapsedFlashTime       += Time.deltaTime;
            elapsedFlashPercentage =  elapsedFlashTime / flashDuration;

            if (elapsedFlashPercentage > 1)
            {
                elapsedFlashPercentage = 1;
            }
            
            float pingPongPercentage = Mathf.PingPong(elapsedFlashPercentage * 2 * numberOfFlashes, 1);
            sr.color = Color.Lerp(startColor, flashColor, pingPongPercentage);

            yield return null;
        }

        
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
