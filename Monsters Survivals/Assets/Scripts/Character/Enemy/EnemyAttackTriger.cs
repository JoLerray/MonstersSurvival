using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider2D))]

public class EnemyAttackTriger : MonoBehaviour {
    
    [SerializeField] private Enemy _enemy;
    
    [SerializeField] private CircleCollider2D _collider;

    private Hero _hero;

    private void OnTriggerEnter2D(Collider2D other) {
  
        _hero = other.GetComponent<Hero>();      
    }

    private void OnTriggerStay2D(Collider2D other) {
      
        if(_hero != null) {
           StartCoroutine(Attack());
           _enemy.Movement.isStay = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) {

        if (other.GetComponent<Hero>() != null) {
            StopCoroutine(Attack());
            _enemy.Behaviour.SetBehaviourIdle();
            Debug.Log("Hero Exit");
            _enemy.Movement.isStay = false;
        }
    }

    private void Update() {

        _collider.radius = _enemy.Stats.AttackRange;
    }
    
    private IEnumerator Attack() {

        while(true) {
            _enemy.Behaviour.SetBehaviourAttacking();
            _enemy.Attack.Attack();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
