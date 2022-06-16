
public class HeroBehaviourDeath : PlayerHeroBehaviour {

    public HeroBehaviourDeath(Hero hero):base(hero) {}

    public override void Enter() {
        
        Hero.HeroAnimationSwitcher.PlayAnimationDeath();
    }

    public override void Exit() {

    }
    
    public override void Update() {
        
    }
}
