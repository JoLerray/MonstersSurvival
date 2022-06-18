using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
[RequireComponent (typeof (EnemyAttack))] 
[RequireComponent (typeof (EnemyMovement))] 
[RequireComponent (typeof (EnemyAnimationSwitcher))] 

public class Enemy : Character {
    
    [SerializeField] private EnemyAnimationSwitcher _animationSwitcher;

    [SerializeField] private EnemyMovement _movement;
   
    [SerializeField] private EnemyAttack _attack;

    private EnemyBehaviour _behaviour;

    private SpriteRenderer _spriteRenderer;

    public EnemyBehaviour Behaviour { get {return _behaviour;}}

    public EnemyMovement Movement {get {return _movement;}}

    public EnemyAttack Attack {get {return _attack;}}

    public EnemyAnimationSwitcher AnimationSwitcher {get {return _animationSwitcher;}}

    public override void TakeDamage(uint damage) {
        
        Stats.HealthPoints -= damage;
        Behaviour.SetBehaviorTakingDamage();
        
        if (Stats.HealthPoints <= 0) {
            
            Behaviour.SetBehaviorDeath();
            Destroy(gameObject, 1);
        }
    }

    private void Start() {

        _behaviour = new EnemyBehaviour(this);
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {

        if(Stats.HealthPoints <= 0) return;
        
        if(Movement.isStay == false) _movement.Movement();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if(other.GetComponent<Hero>() != null){
            Movement.Stay();
            Attack.Attack();
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
       
        if(other.GetComponent<Hero>() != null){
            Attack.Attack();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        
        if(other.GetComponent<Hero>() != null){
            Movement.isStay = false;
        }
    }
}
