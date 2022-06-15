
public sealed class PlayerBehaviourAttacking : PlayerHeroBehaviour
{
    public PlayerBehaviourAttacking(Hero hero) : base(hero) {}

    public override void Enter() {

        _hero.AnimationPlayer.PlayAnimationAttack();
    }

    public override void Exit() {
        
    }
    
    public override void Update() {
        
    }
}
