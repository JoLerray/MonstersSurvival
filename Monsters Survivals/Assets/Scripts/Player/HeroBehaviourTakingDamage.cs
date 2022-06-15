
public sealed class HeroBehaviourTakingDamage : PlayerHeroBehaviour {

    public HeroBehaviourTakingDamage(Hero hero) : base(hero) {}

    public override void Enter() {

        _hero.AnimationPlayer.PlayAnimationTakeDamage();
    }

    public override void Exit() {

    }
    
    public override void Update() {
        
    }
}
