
public class HeroBehaviourIdle : PlayerHeroBehaviour  {

    public HeroBehaviourIdle(Hero hero) : base(hero) {}

    public override void Enter() {
        
        Hero.AnimationSwitcher.PlayAnimationIdle();
    }

    public override void Exit() {}
    
    public override void Update() {}
}
