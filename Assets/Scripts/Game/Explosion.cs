using UnityEngine;

public class Explosion : AutoDestroyObject
{
    public Animator animator;

    protected override void OnEnable()
    {
        base.OnEnable();
        
        animator.Rebind();
        animator.Play("Idle");
    }
}