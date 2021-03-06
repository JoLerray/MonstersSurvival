using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Hero))]

public class HeroAnimationSwitcher : MonoBehaviour
{

    private Hero _hero;
    
    private Animator _animator;
   
    private void Awake() {
        _animator = GetComponent<Animator>();
        _hero = GetComponent<Hero>();
    }
    
    public virtual void PlayAnimationRun() {

       _animator.speed = _hero.Stats.MoveSpeed / 5;

       _animator.SetBool("isRunning", true);
    }

    public virtual void PlayAnimationAttack() {
          
        _animator.speed = _hero.Stats.AttackSpeed;

        _animator.SetTrigger("Attack");
    }

    public virtual void PlayAnimationTakeDamage() {

        _animator.speed = 1;

        _animator.SetTrigger("TakeHit");
    }

    public virtual void PlayAnimationIdle() {
          
        _animator.speed = 1;

        _animator.SetBool("isRunning", false);
    }

    public virtual void PlayAnimationDeath() {
        
        _animator.speed = 1;

        _animator.SetBool("isLive", false);
    }
    
}
