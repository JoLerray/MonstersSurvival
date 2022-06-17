using UnityEngine;

public class EnemyAnimationSwitcher : MonoBehaviour {

    private Enemy _enemy;
    private  Animator _animator;
   
    private void Awake() {

        _animator = GetComponent<Animator>();
        _enemy = GetComponent<Enemy>();
    }
    
    public virtual void PlayAnimationRun() {

       _animator.speed = _enemy.Stats.MoveSpeed / 5;

       _animator.SetBool("isRun", true);
    }

    public virtual void PlayAnimationAttack() {
          
        _animator.speed = _enemy.Stats.AttackSpeed;

        _animator.SetTrigger("Attack");
    }

    public virtual void PlayAnimationTakeDamage() {

        _animator.speed = 1;
        _animator.SetTrigger("TakeDamage");
    }

    public virtual void PlayAnimationIdle() {
          
        _animator.speed = 1;

        _animator.SetBool("isRun", false);
    }

    public virtual void PlayAnimationDeath() {
        
        _animator.speed = 1;

        _animator.SetBool("isLive", false);
    }
}