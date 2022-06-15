
public sealed class HeroBehaviourIdle : PlayerHeroBehaviour  {

    public HeroBehaviourIdle(Hero hero) : base(hero) {}

    public override void Enter() {
        
        _hero.AnimationPlayer.PlayAnimationIdle();
    }

    public override void Exit() {

    }
    
    public override void Update() {
        
    }
}
