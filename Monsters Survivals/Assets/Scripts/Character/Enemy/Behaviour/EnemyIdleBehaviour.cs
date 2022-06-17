
public class EnemyIdleBehaviour  : BaseEnemyBehaviour {

    public EnemyIdleBehaviour(Enemy enemy) : base (enemy) {}

    public override void Enter() {

        Enemy.AnimationSwitcher.PlayAnimationIdle();
    }

    public override void Exit() {
        
    }
    
    public override void Update() {
      
    }
}
