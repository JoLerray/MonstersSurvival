
public class EnemyRunBehaviour  : BaseEnemyBehaviour {

    public EnemyRunBehaviour(Enemy enemy) : base (enemy) {}

    public override void Enter() {

        Enemy.AnimationSwitcher.PlayAnimationRun();
    }
    
    public override void Exit() {

    }

    public override void Update() {

    }
}
