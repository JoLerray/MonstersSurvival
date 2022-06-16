using UnityEngine;

[RequireComponent(typeof(Hero))]

public class HeroAnimationSwicher : CharacterAnimationSwicher {
    
    private Hero _hero;
   
    private void Start() {
        _hero = GetComponent<Hero>();
    }

    public override void PlayAnimationRun() {

       Animator.speed = _hero.Stats.MoveSpeed / 5;
       Animator.SetBool("isRunning", true);
    }

    public override void PlayAnimationAttack() {
          
        Animator.speed = _hero.Stats.AttackSpeed;
        Animator.SetTrigger("Attack");
    }

    public override void PlayAnimationTakeDamage() {

        Animator.speed = 1;
        Animator.SetTrigger("TakeHit");
    }

    public override void PlayAnimationIdle() {
          
        Animator.speed = 1;
        Animator.SetBool("isRunning", false);
        Animator.SetBool("isTakeDamage", false);
        Animator.SetBool("isAttacking", false);
    }

    public override void PlayAnimationDeath() {
        
        Animator.speed = 1;
        Animator.SetBool("isLive", false);
    }
}
