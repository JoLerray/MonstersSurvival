using UnityEngine;

[RequireComponent(typeof(Hero))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public 
class HeroMovement: MovementCharacter {
   
    private Hero _hero;

    private Rigidbody2D _rigidBody;

    private void Awake() {
        
        _hero = GetComponent<Hero>();
        _rigidBody = GetComponent<Rigidbody2D>();       
    }


    public override void Movement() {

        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        _rigidBody.velocity = moveInput * _hero.Stats.MoveSpeed;
        
        FlipHeroHorizontal (Mathf.RoundToInt(_rigidBody.velocity.x));
       
        ChangeHeroState(_rigidBody.velocity);
    }

    private void FlipHeroHorizontal(int velocityHorizontal) {
          
        if(velocityHorizontal == 0) return;

        else if(velocityHorizontal > 0)
            _hero.transform.localEulerAngles = new Vector3(0,0,0);
        
        else 
            _hero.transform.localEulerAngles = new Vector3(0,180,0);

    }

    private void ChangeHeroState(Vector2 velocity) {

        if (velocity == Vector2.zero)
            _hero.Behaviour.SetBehaviourIdle();

        else
            _hero.Behaviour.SetBehaviourRun();
    }
}

