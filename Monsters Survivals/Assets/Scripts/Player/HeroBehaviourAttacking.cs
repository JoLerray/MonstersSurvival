public sealed class HeroBehaviourAttacking : PlayerHeroBehaviour
{
    public HeroBehaviourAttacking(Hero hero) : base(hero) {}

    public override void Enter() {

        Hero.AnimationPlayer.PlayAnimationAttack();
    }

    public override void Exit() {

    }
    
    public override void Update() {

    }
}