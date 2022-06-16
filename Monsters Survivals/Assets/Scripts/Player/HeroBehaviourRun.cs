
public class HeroBehaviourRun : PlayerHeroBehaviour {

    public HeroBehaviourRun(Hero hero) : base(hero) {}

    public override void Enter() {
        
        Hero.HeroAnimationSwitcher.PlayAnimationRun();
    }

    public override void Exit() {
        
    }
    
    public override void Update() {
        
    }
}
