using UnityEngine;

[RequireComponent(typeof(Stats))]

public abstract class Character : MonoBehaviour
{
    [SerializeField] private Stats _stats;

    [SerializeField] private CharacterAnimationSwicher _animationSwicher;

    public Stats Stats {get {return _stats;}}

    public CharacterAnimationSwicher AnimationSwicher {get { return _animationSwicher;}}
    
    public abstract void TakeDamage(uint damage);
}
