using UnityEngine;
using System;
public class PlayerAttack : Attacker {

    [SerializeField] private Player _player;
    
    [SerializeField] private Transform _attackPoint;

    [SerializeField] private LayerMask _enemyLayers;

    public override void Attack() {

        _player.Behaviour.SetBehaviourAttacking();

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _player.Hero.Stats.AttackRange,_enemyLayers);

        foreach(var enemy in hitEnemies) {

            var _enemy = enemy.GetComponent<Enemy>();

            _enemy.TakeDamage((uint)_player.Hero.Stats.Damage, () => { _player.Behaviour.SetBehaviorTakingDamage();});
        }
    }

    private void OnDrawGizmosSelected() {
        
        if(_attackPoint == null)
            return;

        Gizmos.DrawWireSphere(_attackPoint.position,_player.Hero.Stats.AttackRange);       
    }
}
