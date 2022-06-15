using UnityEngine;
using System.Collections;

public class HeroAttack : Attacker {

    [SerializeField] private Hero _hero;
    
    [SerializeField] private Transform _attackPoint;

    [SerializeField] private LayerMask _enemyLayers;

    [SerializeField] private float _baseAttackDelay;

    private float _nextAttackTime = 0f;

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

        foreach(var enemy in hitEnemies) {

            var _enemy = enemy.GetComponent<Enemy>();
            _enemy.TakeDamage((uint)_hero.Stats.Damage);
        }

        // Waited when animation end and change state
        yield return new WaitForSeconds(_baseAttackDelay / (_hero.Stats.AttackSpeed + _baseAttackDelay) );
        _hero.Behaviour.SetBehaviourIdle();
    }
}
