
public class HeroBehaviourTakingDamage : PlayerHeroBehaviour {

    public HeroBehaviourTakingDamage(Hero hero) : base(hero) {}

    public override void Enter() {

        Hero.HeroAnimationSwitcher.PlayAnimationTakeDamage();
    }

    public override void Exit() {}
    
    public override void Update() {}
}
