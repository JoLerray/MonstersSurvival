
public sealed class PlayerBehaviourRun : PlayerHeroBehaviour {

    public PlayerBehaviourRun(Hero hero) : base(hero) {}

    public override void Enter() {
        
        _hero.AnimationPlayer.PlayAnimationRun();
    }

    public override void Exit() {
        
    }
    
    public override void Update() {
        
    }
}
