using UnityEngine;
using System.Collections;

public class HeroAttack : Attacker {

    [SerializeField] private Transform _attackPoint;

    [SerializeField] private LayerMask _enemyLayers;

    [SerializeField] private float _baseAttackDelay;

    private Hero _hero;
    
    private float _nextAttackTime = 0f;

    private void Start() {
        
        _hero = GetComponent<Hero>();
    }

    public override void Attack() {

        if(Time.time < _nextAttackTime) return;

        _hero.Behaviour.SetBehaviourAttacking();
        StartCoroutine(AttackDelay());

        _nextAttackTime = Time.time + 1f / _hero.Stats.AttackSpeed;
    }

    // Sync animation hero attack with take enemy damage
    public virtual IEnumerator AttackDelay() {

        // Waited when animation attack  visual touch Enemy
        yield return new WaitForSeconds(_baseAttackDelay / (_hero.Stats.AttackSpeed + _baseAttackDelay) );

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _hero.Stats.AttackRange,_enemyLayers);

        foreach(var enemyCollider in hitEnemies) {

            var enemy = enemyCollider.GetComponent<Enemy>();
            enemy.TakeDamage((uint)_hero.Stats.Damage);
        }

        // Waited when animation end and change state
        yield return new WaitForSeconds(_baseAttackDelay / (_hero.Stats.AttackSpeed + _baseAttackDelay) );
        _hero.Behaviour.SetBehaviourIdle();
    }
}
