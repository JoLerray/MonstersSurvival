using System;

public abstract class BaseEnemyBehaviour : IBehaviour {
    
    public readonly Enemy Enemy;

    public BaseEnemyBehaviour(Enemy enemy) {
        
        if(enemy == null) throw new ArgumentNullException("Enemy is not set !");
        Enemy = enemy;
    }

    abstract public void Enter();

    abstract public void Exit();
    
    abstract public void Update();
}
