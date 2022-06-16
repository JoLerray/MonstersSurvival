using UnityEngine;

public sealed class Player : MonoBehaviour {
    
    [SerializeField] private Hero _hero;
    
    public Hero Hero {get {return _hero;}}

    private void Update() {

        Hero.Move();
        Hero.Attack();

        transform.position = Hero.transform.position;
    }

}
