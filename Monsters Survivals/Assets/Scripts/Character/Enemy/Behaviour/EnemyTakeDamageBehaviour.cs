
public class EnemyTakeDamageBehaviour : BaseEnemyBehaviour {

    public EnemyTakeDamageBehaviour(Enemy enemy) : base (enemy) {}

    public override void Enter() {
        
        Enemy.AnimationSwitcher.PlayAnimationTakeDamage();
        Enemy.Movement.Stay();
    }

    public override void Exit() {

    }

    public override void Update() {

    }
}
