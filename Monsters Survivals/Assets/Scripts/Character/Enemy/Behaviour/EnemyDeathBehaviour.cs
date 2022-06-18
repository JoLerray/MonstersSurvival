
public class EnemyDeathBehaviour  : BaseEnemyBehaviour {

    public EnemyDeathBehaviour(Enemy enemy) : base (enemy) {}

    public override void Enter() {

        Enemy.AnimationSwitcher.PlayAnimationDeath();
    }
    
    public override void Exit() {
    
    }

    public override void Update() {
        
    }

}
