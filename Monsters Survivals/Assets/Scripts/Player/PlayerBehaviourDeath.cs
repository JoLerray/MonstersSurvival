
public sealed class PlayerBehaviourDeath : PlayerHeroBehaviour {

    public PlayerBehaviourDeath(Hero hero):base(hero) {}

    public override void Enter() {
        
        _hero.AnimationPlayer.PlayAnimationDeath();
    }

    public override void Exit() {

    }
    
    public override void Update() {
        
    }
}
