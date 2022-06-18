using System;
using System.Collections.Generic;

public class EnemyBehaviour {
    private Dictionary<Type,IBehaviour> _behaviourMap;
    
    private IBehaviour _behaviourCurrent;
    private Enemy _enemy;

    public IBehaviour BehaviourCurrent{ get{ return  _behaviourCurrent;}}

    public EnemyBehaviour(Enemy enemy) {
        
        if(enemy == null) throw new ArgumentNullException("Enemy not set !");
        _enemy = enemy;

        InitBehaviour();
        SetBehaviorByDefault();
    }

    private void InitBehaviour() {
        
        _behaviourMap = new Dictionary<Type, IBehaviour>();

        _behaviourMap[typeof(EnemyIdleBehaviour)] = new EnemyIdleBehaviour(_enemy); 
        _behaviourMap[typeof(EnemyRunBehaviour)] = new EnemyRunBehaviour(_enemy);  
        _behaviourMap[typeof(EnemyAttackBehaviour)] = new EnemyAttackBehaviour(_enemy); 
        _behaviourMap[typeof(EnemyTakeDamageBehaviour)] = new EnemyTakeDamageBehaviour(_enemy); 
        _behaviourMap[typeof(EnemyDeathBehaviour)] = new EnemyDeathBehaviour(_enemy); 
    }
    
    private void SetBehavior(IBehaviour newBehaviour) {

        if(newBehaviour == null) throw new ArgumentNullException("New Player Behaviour is NULL !");

        if(_behaviourCurrent != null)
            _behaviourCurrent.Exit();

        _behaviourCurrent = newBehaviour;
        _behaviourCurrent.Enter();
    }

    private IBehaviour GetBehaviour<T>() where T : IBehaviour {
        
        var type = typeof(T);
        return _behaviourMap[type];
    }

    private void SetBehaviorByDefault() {

        var behaviourByDefault = GetBehaviour<EnemyIdleBehaviour>();
        SetBehavior(behaviourByDefault);
    }

    public void SetBehaviourIdle() {

        var behaviour = GetBehaviour<EnemyIdleBehaviour>();
        SetBehavior(behaviour);
    }
    
    public void SetBehaviourRun() {
        
        var behaviour = GetBehaviour<EnemyRunBehaviour>();
        SetBehavior(behaviour);
    }

    public void SetBehaviourAttacking() {
        
        var behaviour = GetBehaviour<EnemyAttackBehaviour>();
        SetBehavior(behaviour);
    }

    public void SetBehaviorTakingDamage() {

        var behaviour = GetBehaviour<EnemyTakeDamageBehaviour>();
        SetBehavior(behaviour);
    }

    public void SetBehaviorDeath() {
        
        var behaviour = GetBehaviour<EnemyDeathBehaviour>();
        SetBehavior(behaviour);
    }

    private void Update() {
        
        if(_behaviourCurrent != null)
             _behaviourCurrent.Update();
    }
}
