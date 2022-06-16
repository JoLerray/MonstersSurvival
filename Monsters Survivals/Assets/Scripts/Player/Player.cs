using UnityEngine;

public sealed class Player : MonoBehaviour {
    
    [SerializeField] private Hero _hero;
    
    [SerializeField] private MovementObject _movement;
    
    [SerializeField] private Attacker _attack;
    
    public Hero Hero {get {return _hero;}}

    private void FixedUpdate() {

        if(_hero.Behaviour.BehaviourCurrent.GetType() != typeof(HeroBehaviourAttacking))
            _movement.Movement();
    }

    private void Update() {

        if(Input.GetMouseButton(0) && _hero.Behaviour.BehaviourCurrent.GetType() !=  typeof(HeroBehaviourRun))
            _attack.Attack();
    }
}
