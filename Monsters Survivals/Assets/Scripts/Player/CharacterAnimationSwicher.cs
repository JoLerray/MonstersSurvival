using UnityEngine;

[RequireComponent(typeof(Animator))]

public abstract class CharacterAnimationSwicher : MonoBehaviour
{
    private  Animator _animator;

    public Animator Animator{get {return _animator;}}

    private void Start() {

        _animator = GetComponent<Animator>();
    }

    public abstract void PlayAnimationRun();

    public abstract void PlayAnimationAttack();

    public abstract void PlayAnimationTakeDamage();

    public abstract void PlayAnimationIdle();

    public abstract void PlayAnimationDeath();
}
