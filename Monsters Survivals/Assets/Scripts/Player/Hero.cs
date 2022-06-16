using UnityEngine;

public class Hero : Character
{  
   
    private HeroBehaviour _behaviour;

    public HeroBehaviour Behaviour { get {return _behaviour;}}

    public HeroAnimationSwicher HeroAnimationSwicher {get { return (HeroAnimationSwicher) HeroAnimationSwicher;}}

    public override void TakeDamage(uint damage) {

        Stats.HealthPoints -= damage;
        _behaviour.SetBehaviorTakingDamage();
    }

    private void Start() {
        _behaviour = new HeroBehaviour(this);
    }
}
