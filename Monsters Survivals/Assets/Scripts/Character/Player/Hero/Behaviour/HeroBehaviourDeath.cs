
public class HeroBehaviourDeath : PlayerHeroBehaviour {

    public HeroBehaviourDeath(Hero hero):base(hero) {}

    public override void Enter() {
        
        Hero.AnimationSwitcher.PlayAnimationDeath();
    }

    public override void Exit() {}
    
    public override void Update() {}
}
