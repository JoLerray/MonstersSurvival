
public sealed class HeroBehaviourDeath : PlayerHeroBehaviour {

    public HeroBehaviourDeath(Hero hero):base(hero) {}

    public override void Enter() {
        
        _hero.AnimationPlayer.PlayAnimationDeath();
    }

    public override void Exit() {

    }
    
    public override void Update() {
        
    }
}
