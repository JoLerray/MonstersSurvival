using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
[RequireComponent (typeof (HeroAttack))] 
[RequireComponent (typeof (HeroMovement))] 
[RequireComponent (typeof (HeroAnimationSwitcher))] 

public class Hero: Character 
{  
    [SerializeField] private HeroAnimationSwitcher _animationSwitcher;
    
    [SerializeField] private HeroMovement _movement;
    
    [SerializeField] private HeroAttack _attack;

    private HeroBehaviour _behaviour;

    public HeroBehaviour Behaviour { get {return _behaviour;}}

    public HeroAnimationSwitcher HeroAnimationSwitcher {get {return _animationSwitcher;}}

    public override void TakeDamage(uint damage) {

        Stats.HealthPoints -= damage;
        _behaviour.SetBehaviorTakingDamage();
    }

    private void Start() {

        _behaviour = new HeroBehaviour(this);
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
