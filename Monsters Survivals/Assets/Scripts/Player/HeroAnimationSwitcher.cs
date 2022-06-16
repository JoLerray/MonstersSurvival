using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HeroAnimationSwitcher : MonoBehaviour
{

    [SerializeField] private Hero _hero;
    [SerializeField] private  Animator _animator;
   
    private void Start()
    {
        _animator = GetComponent<Animator>();
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
