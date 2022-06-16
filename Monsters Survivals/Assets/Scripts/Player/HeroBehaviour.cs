using System;
using System.Collections.Generic;

public class HeroBehaviour
{
    private Dictionary<Type,IBehaviour> _behaviourMap;
    
    private IBehaviour _behaviourCurrent;
    private Hero _hero;

    public IBehaviour BehaviourCurrent{ get{ return  _behaviourCurrent;}}

    public HeroBehaviour(Hero hero) {
        
        if(hero == null) throw new ArgumentNullException("Hero is NULL !");
        _hero = hero;

        InitBehaviour();
        SetBehaviorByDefault();
    }

    private void InitBehaviour() {
        
        _behaviourMap = new Dictionary<Type, IBehaviour>();

        _behaviourMap[typeof(HeroBehaviourIdle)] = new HeroBehaviourIdle(_hero); 
        _behaviourMap[typeof(HeroBehaviourRun)] = new HeroBehaviourRun(_hero);  
        _behaviourMap[typeof(HeroBehaviourAttacking)] = new HeroBehaviourAttacking(_hero); 
        _behaviourMap[typeof(HeroBehaviourTakingDamage)] = new HeroBehaviourTakingDamage(_hero); 
        _behaviourMap[typeof(HeroBehaviourDeath)] = new HeroBehaviourDeath(_hero); 
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

        var behaviourByDefault = GetBehaviour<HeroBehaviourIdle>();
        SetBehavior(behaviourByDefault);
    }

    public void SetBehaviourIdle() {

        var behaviour = GetBehaviour<HeroBehaviourIdle>();
        SetBehavior(behaviour);
    }
    
    public void SetBehaviourRun() {
        
        var behaviour = GetBehaviour<HeroBehaviourRun>();
        SetBehavior(behaviour);
    }

    public void SetBehaviourAttacking() {
        
        var behaviour = GetBehaviour<HeroBehaviourAttacking>();
        SetBehavior(behaviour);
    }

    public void SetBehaviorTakingDamage() {

        var behaviour = GetBehaviour<HeroBehaviourTakingDamage>();
        SetBehavior(behaviour);
    }

    public void SetBehaviorDeath() {
        
        var behaviour = GetBehaviour<HeroBehaviourDeath>();
        SetBehavior(behaviour);
    }

    private void Update() {

        if(_behaviourCurrent != null)
             _behaviourCurrent.Update();
    }
}
