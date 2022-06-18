using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
[RequireComponent (typeof (HeroAttack))] 
[RequireComponent (typeof (HeroMovement))] 
[RequireComponent (typeof (HeroAnimationSwitcher))] 

public class Hero: Character {  
    
    [SerializeField] private HeroAnimationSwitcher _animationSwitcher;
    
    [SerializeField] private HeroMovement _movement;
    
    [SerializeField] private HeroAttack _attack;

    private HeroBehaviour _behaviour;

    private SpriteRenderer _spriteRenderer;

    public HeroBehaviour Behaviour { get {return _behaviour;}}

    public HeroAnimationSwitcher AnimationSwitcher {get {return _animationSwitcher;}}

    public SpriteRenderer SpriteRenderer{get {return _spriteRenderer;}}

    public override void TakeDamage(uint damage) {

        Stats.HealthPoints -= damage;
        _behaviour.SetBehaviorTakingDamage();
        if (Stats.HealthPoints <= 0) Behaviour.SetBehaviorDeath();
        
    }

    private void Start() {

        _behaviour = new HeroBehaviour(this);
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Move() {

        if(Behaviour.BehaviourCurrent.GetType() != typeof(HeroBehaviourAttacking))
            _movement.Movement();
    }

    public void Attack() {

        if(Input.GetMouseButton(0) && Behaviour.BehaviourCurrent.GetType() !=  typeof(HeroBehaviourRun))
            _attack.Attack();
    }
}
