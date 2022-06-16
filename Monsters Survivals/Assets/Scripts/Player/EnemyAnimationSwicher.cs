using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyAnimationSwicher : CharacterAnimationSwicher
{
    private Enemy _enemy;

    private void Start() {    
        
        _enemy = GetComponent<Enemy>();
    }

    public override void PlayAnimationRun() {

       Animator.speed = _enemy.Stats.MoveSpeed / 5;
       Animator.SetBool("isRunning", true);
    }

    public override void PlayAnimationAttack() {
          
        Animator.speed = _enemy.Stats.AttackSpeed;
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
