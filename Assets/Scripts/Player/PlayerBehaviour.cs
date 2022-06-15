using System;
using System.Collections.Generic;

public sealed class PlayerBehaviour
{
    private Dictionary<Type,IPlayerBehaviour> _behaviourMap;
    
    private IPlayerBehaviour _behaviourCurrent;

    private Hero _hero;

    public IPlayerBehaviour BehaviourCurrent{ get{ return  _behaviourCurrent;}}

    public PlayerBehaviour(Hero hero) {
        
        if(hero == null) throw new ArgumentNullException("Hero is NULL !");
        _hero = hero;

        InitBehaviour();
        SetBehaviorByDefault();
        
    }

    private void InitBehaviour() {
        
        _behaviourMap = new Dictionary<Type, IPlayerBehaviour>();

        _behaviourMap[typeof(PlayerBehaviourIdle)] = new PlayerBehaviourIdle(_hero); 
        _behaviourMap[typeof(PlayerBehaviourRun)] = new PlayerBehaviourRun(_hero);  
        _behaviourMap[typeof(PlayerBehaviourAttacking)] = new PlayerBehaviourAttacking(_hero); 
        _behaviourMap[typeof(PlayerBehaviourTakingDamage)] = new PlayerBehaviourTakingDamage(_hero); 
        _behaviourMap[typeof(PlayerBehaviourDeath)] = new PlayerBehaviourDeath(_hero); 
    }
    
    private void SetBehavior(IPlayerBehaviour newBehaviour) {

        if(newBehaviour == null) throw new ArgumentNullException("New Player Behaviour is NULL !");

        if(_behaviourCurrent != null)
            _behaviourCurrent.Exit();

        _behaviourCurrent = newBehaviour;
        _behaviourCurrent.Enter();
    }

    private IPlayerBehaviour GetBehaviour<T>() where T : IPlayerBehaviour {
        
        var type = typeof(T);
        return _behaviourMap[type];
    }

    private void SetBehaviorByDefault() {

        var behaviourByDefault = GetBehaviour<PlayerBehaviourIdle>();
        SetBehavior(behaviourByDefault);
    }

    public void SetBehaviourIdle() {

        var behaviour = GetBehaviour<PlayerBehaviourIdle>();
        SetBehavior(behaviour);
    }
    
    public void SetBehaviourRun() {
        
        var behaviour = GetBehaviour<PlayerBehaviourRun>();
        SetBehavior(behaviour);
    }

    public void SetBehaviourAttacking() {
        
        var behaviour = GetBehaviour<PlayerBehaviourAttacking>();
        SetBehavior(behaviour);
    }

    public void SetBehaviorTakingDamage() {

        var behaviour = GetBehaviour<PlayerBehaviourTakingDamage>();
        SetBehavior(behaviour);
    }

    public void SetBehaviorDeath() {
        
        var behaviour = GetBehaviour<PlayerBehaviourDeath>();
        SetBehavior(behaviour);
    }

}
