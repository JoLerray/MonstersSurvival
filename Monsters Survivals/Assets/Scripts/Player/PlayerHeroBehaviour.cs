using System;

public abstract class PlayerHeroBehaviour : IBehaviour
{
    public readonly Hero _hero;

    public PlayerHeroBehaviour(Hero hero) {
        
        if(hero == null) throw new ArgumentNullException("Hero is NULL !");
        _hero = hero;
    }

    abstract public void Enter();

    abstract public void Exit();
    
    abstract public void Update();
}
