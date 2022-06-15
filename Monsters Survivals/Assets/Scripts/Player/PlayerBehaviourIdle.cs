
public sealed class PlayerBehaviourIdle : PlayerHeroBehaviour  {

    public PlayerBehaviourIdle(Hero hero) : base(hero) {}

    public override void Enter() {
        
        _hero.AnimationPlayer.PlayAnimationIdle();
    }

    public override void Exit() {

    }
    
    public override void Update() {
        
    }
}
