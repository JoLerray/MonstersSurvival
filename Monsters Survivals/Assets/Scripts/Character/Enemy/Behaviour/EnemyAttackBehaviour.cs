
public class EnemyAttackBehaviour  : BaseEnemyBehaviour {

    public EnemyAttackBehaviour(Enemy enemy) : base (enemy) {}

    public override void Enter() {

        Enemy.AnimationSwitcher.PlayAnimationAttack();
    }

    public override void Exit() {
        
    }

    public override void Update() {
        
    }
}
