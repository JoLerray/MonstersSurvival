
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class HeroAnimationSwicher : MonoBehaviour
{
    [SerializeField] private  Animator _animator;
   
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayAnimationRun() {

       _animator.SetBool("isRunning", true);
    }

    public void PlayAnimationAttack() {
          
        _animator.SetTrigger("Attack");
    }

    public void PlayAnimationTakeDamage() {

        _animator.SetTrigger("TakeHit");
    }

    public void PlayAnimationIdle() {
          
        _animator.SetBool("isRunning", false);
        _animator.SetBool("isTakeDamage", false);
        _animator.SetBool("isAttacking", false);
    }

    public void PlayAnimationDeath() {

         _animator.SetBool("isLive", false);
    }
    
}
