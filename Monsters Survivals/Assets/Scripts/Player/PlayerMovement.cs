using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public 
class PlayerMovement: MovementObject {
   
    [SerializeField] private Player _player;

    private Rigidbody2D _rigidBodyPlayer;

    private void Start() {

        _rigidBodyPlayer = GetComponent<Rigidbody2D>();       
    }


    public override void Movement() {

        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        _rigidBodyPlayer.velocity = moveInput * _player.Hero.Stats.MoveSpeed;
        
        FlipPlayerHorizontal (Mathf.RoundToInt(_rigidBodyPlayer.velocity.x));
        
        ChangePlayerState(_rigidBodyPlayer.velocity);
    }

    private void FlipPlayerHorizontal(int velocityHorizontal) {
          
        if(velocityHorizontal == 0) return;

        else if(velocityHorizontal > 0)
            _player.transform.localEulerAngles = new Vector3(0,0,0);
        
        else 
            _player.transform.localEulerAngles = new Vector3(0,180,0);

    }

    private void ChangePlayerState(Vector2 velocity) {

        if (velocity == Vector2.zero)
            _player.Hero.Behaviour.SetBehaviourIdle();

        else
            _player.Hero.Behaviour.SetBehaviourRun();
    }
}

