using UnityEngine;
using System;

[RequireComponent(typeof(Enemy))]
[RequireComponent(typeof(BoxCollider2D))]

public class EnemyMovement : MovementCharacter {

    [SerializeField] private Player _player;

    [SerializeField] private float _searchRadius;

    [SerializeField] private PlayerCamera _playerCamera;               

        private Enemy _enemy;

    private Vector2 targetPos;

    public bool isStay = false;

    private void Start() {

        _enemy = GetComponent<Enemy>();
        targetPos = new Vector2( UnityEngine.Random.Range(_enemy.transform.position.x  - _searchRadius, _enemy.transform.position.x + _searchRadius), UnityEngine.Random.Range(_enemy.transform.position.y  - _searchRadius, _enemy.transform.position.y + _searchRadius));
    }

    public void Stay() {

        isStay = true;
        _enemy.Behaviour.SetBehaviourIdle();
    }

    public override void Movement() {

        if(Vector2.Distance(_enemy.transform.position, _player.Hero.transform.position) < _searchRadius) {
            targetPos = _player.Hero.transform.position;
            ChaseHero();
        }

        else {
            SetRandomTargerPos();
            MoveToPoint(targetPos);
        }

        _enemy.Behaviour.SetBehaviourRun();
        
        FlipEnemyHorizontal(Mathf.RoundToInt(GetDirectionEnemy().x));
    }

    public void ChaseHero() => _enemy.transform.position = Vector2.MoveTowards(_enemy.transform.position, _player.Hero.transform.position, _enemy.Stats.MoveSpeed * Time.deltaTime);

    public void MoveToPoint(Vector2 point) => _enemy.transform.position = Vector2.MoveTowards(_enemy.transform.position, point, _enemy.Stats.MoveSpeed * Time.deltaTime);
    
    private void FlipEnemyHorizontal(int velocityHorizontal) {
          
        if(velocityHorizontal == 0) return;

        else if(velocityHorizontal > 0)
            _enemy.transform.localEulerAngles = new Vector3(0,0,0);
        
        else 
            _enemy.transform.localEulerAngles = new Vector3(0,180,0);
    }

    private void SetRandomTargerPos() {

        if(targetPos == (Vector2) _enemy.transform.position)
            targetPos = new Vector2( UnityEngine.Random.Range(_enemy.transform.position.x - _searchRadius, _enemy.transform.position.x + _searchRadius), UnityEngine.Random.Range(_enemy.transform.position.y  - _searchRadius, _enemy.transform.position.y + _searchRadius));
            
        while(targetPos.x <=  _playerCamera.MapSize.x || targetPos.x >= _playerCamera.MapSize.y || targetPos.y <= _playerCamera.MapSize.z || targetPos.y >= _playerCamera.MapSize.w) 
            targetPos = new Vector2( UnityEngine.Random.Range(_enemy.transform.position.x - _searchRadius, _enemy.transform.position.x + _searchRadius), UnityEngine.Random.Range(_enemy.transform.position.y  - _searchRadius, _enemy.transform.position.y + _searchRadius));
    }
    
    private  Vector2 GetDirectionEnemy() {
       
        Vector2 vectorBetweenEnemyAndHero = GetVectorBetweenEnemyAndTargetPoint();

        int directionEnemyX;

        try {
            directionEnemyX = (int)vectorBetweenEnemyAndHero.x /(int) Mathf.Abs(vectorBetweenEnemyAndHero.x);
        }
        catch(DivideByZeroException) {
            directionEnemyX = 0;
        }

        int directionEnemyY ;

        try {
            directionEnemyY = (int)vectorBetweenEnemyAndHero.y /(int) Mathf.Abs(vectorBetweenEnemyAndHero.y);
        }
        catch(DivideByZeroException) {

            directionEnemyY = 0;
        }

        return new Vector2( directionEnemyX,directionEnemyY);
    }
    
    private Vector2 GetVectorBetweenEnemyAndTargetPoint() => ((Vector2)targetPos - (Vector2) _enemy.transform.position);
    
    // private void OnDrawGizmosSelected() {
    
    //     Gizmos.color = Color.green;
    //     Gizmos.DrawWireSphere(_enemy.transform.position, _searchRadius);
    // }  

    // private void OnDrawGizmos() {

    //     Gizmos.color = Color.red;
    //     Gizmos.DrawLine(_enemy.transform.position, targetPos);
    // }
}
