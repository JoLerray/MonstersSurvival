using UnityEngine;

public sealed class Player : MonoBehaviour {
    
    [SerializeField] private Hero _hero;
    
    [SerializeField] private MovementObject _movement;
    
    [SerializeField] private Attacker _attack;
    
    public Hero Hero {get {return _hero;}}

    private void FixedUpdate() {

        _movement.Movement();
    }

    private void Update() {

        if(Input.GetMouseButton(0))
            _attack.Attack();
    }
}
