using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Hero))]

public class HeroAnimationSwitcher : MonoBehaviour
{

    private Hero _hero;
    private  Animator _animator;
   
    private void Awake() {
        _animator = GetComponent<Animator>();
        _hero = GetComponent<Hero>();
    }
    
    public void PlayAnimationRun() {

       _animator.speed = _hero.Stats.MoveSpeed / 5;

       _animator.SetBool("isRunning", true);
    }

    public void PlayAnimationAttack() {
          
        _animator.speed = _hero.Stats.AttackSpeed;

        _animator.SetTrigger("Attack");
    }

    public void PlayAnimationTakeDamage() {

        _animator.speed = 1;

        _animator.SetTrigger("TakeHit");
    }

    public void PlayAnimationIdle() {
          
        _animator.speed = 1;

        _animator.SetBool("isRunning", false);
        _animator.SetBool("isTakeDamage", false);
        _animator.SetBool("isAttacking", false);
    }

    public void PlayAnimationDeath() {
        
        _animator.speed = 1;

        _animator.SetBool("isLive", false);
    }
    
}
