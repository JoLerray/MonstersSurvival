
public class HeroBehaviourIdle : PlayerHeroBehaviour  {

    public HeroBehaviourIdle(Hero hero) : base(hero) {}

    public override void Enter() {
        
        Hero.AnimationPlayer.PlayAnimationIdle();
    }

    public override void Exit() {

    }
    
    public override void Update() {
        
    }
}