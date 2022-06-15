
public sealed class HeroBehaviourRun : PlayerHeroBehaviour {

    public HeroBehaviourRun(Hero hero) : base(hero) {}

    public override void Enter() {
        
        _hero.AnimationPlayer.PlayAnimationRun();
    }

    public override void Exit() {
        
    }
    
    public override void Update() {
        
    }
}
