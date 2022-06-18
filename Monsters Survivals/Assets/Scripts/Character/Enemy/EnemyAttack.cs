using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Enemy))]

public class EnemyAttack : Attacker {

    [SerializeField] private Transform _attackPoint;

    [SerializeField] private LayerMask _enemyLayers;

    [SerializeField] private float _baseAttackDelay;

    [SerializeField] private Vector2 _pushForce;

    private Enemy _enemy;
    
    private float _nextAttackTime = 0f;

    private void Awake() {
        
        _enemy = GetComponent<Enemy>();
    }

    public override void Attack() {

        if(_enemy.Stats.HealthPoints <= 0) return;
        
        if(Time.time < _nextAttackTime) return;
        
        StartCoroutine(AttackDelay());
        _enemy.Behaviour.SetBehaviourAttacking();
        _enemy.Movement.isStay = true;
        _nextAttackTime = Time.time + 1f / _enemy.Stats.AttackSpeed;
    }


    public virtual IEnumerator AttackDelay() {
     
        yield return new WaitForSeconds(_baseAttackDelay / (_enemy.Stats.AttackSpeed + _baseAttackDelay) );

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _enemy.Stats.AttackRange, _enemyLayers);

        foreach(var enemyCollider in hitEnemies) {

            var enemy = enemyCollider.GetComponent<Hero>();
            enemy.TakeDamage((uint)_enemy.Stats.Damage);
            PushAwayHero(enemy);
        }
    }

    private void PushAwayHero(Hero hero) {

        hero.transform.position += new Vector3(_pushForce.x * _enemy.Movement.GetDirectionEnemy().x, _pushForce.y * _enemy.Movement.GetDirectionEnemy().y, 0f);
    }
}
