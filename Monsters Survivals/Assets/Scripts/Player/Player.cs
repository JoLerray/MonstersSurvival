using UnityEngine;

public sealed class Player : MonoBehaviour {
    
    [SerializeField] private Hero _hero;
    
    [SerializeField] private MovementObject _movement;
    
    [SerializeField] private Attacker _attack;
    
    private PlayerBehaviour _behaviour;

    public PlayerBehaviour Behaviour { get {return _behaviour;}}

    public Hero Hero {get {return _hero;}}

    private void Start() {

        _behaviour = new PlayerBehaviour(_hero);
    }

    private void FixedUpdate() {

        _movement.Movement();
    }

    private void Update() {

        if(Input.GetMouseButton(0))
            _attack.Attack();
    }
}
