
public sealed class PlayerBehaviourTakingDamage : PlayerHeroBehaviour {

    public PlayerBehaviourTakingDamage(Hero hero) : base(hero) {}

    public override void Enter() {

        _hero.AnimationPlayer.PlayAnimationTakeDamage();
    }

    public override void Exit() {

    }
    
    public override void Update() {
        
    }
}
