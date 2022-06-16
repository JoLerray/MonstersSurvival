using UnityEngine;

public class Stats : MonoBehaviour {
    [SerializeField] private uint _level;

    [SerializeField] private float _healthPointsIncreasePerLevel;

    [SerializeField] private float _damageIncreasePerLevel;

    [SerializeField] private float _armorPointsIncreasePerLevel;

    [SerializeField] private float _moveSpeedIncreasePerLevel;

    [SerializeField] private float _attackSpeedIncreasePerLevel;

    [SerializeField] private float _attackRangeIncreasePerLevel;

    [SerializeField] private float _healthRegenerationIncreasePerLevel;

// Max Current Stats

    [SerializeField] private float _maxHealthPoints;

    [SerializeField] private float _maxDamage;

    [SerializeField] private float _maxArmor;

    [SerializeField] private float _maxMoveSpeed;

    [SerializeField] private float _maxAttackSpeed;

    [SerializeField] private float _maxAttackRange;

    [SerializeField] private float _maxHealthRegeneration;

    public float MaxHealthPoints {get {return _maxHealthPoints;}}

    public float MaxDamage {get {return _maxDamage;}}

    public float MaxArmor {get {return _maxArmor;}}

    public float MaxMoveSpeed {get {return _maxMoveSpeed;}}

    public float MaxAttackSpeed {get {return _maxAttackSpeed;}}

    public float MaxAttackRange {get {return _maxAttackRange;}}

    public float MaxHealthRegeneration {get {return _maxHealthRegeneration;}}

//Current Stats

    private float _healthPoints;

    private float _damage; 

    private float _armor;

    private float _moveSpeed; 

    private float _attackSpeed;

    private float _attackRange;

    private float _healthRegeneration;

    public float HealthPoints {get {return _healthPoints;} set {_healthPoints = value;}}

    public float Damage {get {return _damage;} set {_damage = value;}}

    public float Armor {get {return _armor;} set {_armor = value;}}

    public float MoveSpeed {get {return _moveSpeed;} set {_moveSpeed = value;}}

    public float AttackSpeed {get {return _attackSpeed;} set {_attackSpeed = value;}}

    public float AttackRange {get {return _attackRange;} set {_attackRange = value;}}

    public float HealthRegeneration {get {return _healthRegeneration;} set {_healthRegeneration =value;}}



    private void Start() {

        _healthPoints = _maxHealthPoints;
        _damage = _maxDamage;
        _armor = _maxArmor;
        _moveSpeed = _maxMoveSpeed;
        _attackSpeed = _maxAttackSpeed;
        _attackRange = _maxAttackRange;
        _healthRegeneration = _maxHealthRegeneration;
    }

    public void LevelUp(uint levels = 1) {
        
        _level += levels;

        _maxHealthPoints += levels * _healthPointsIncreasePerLevel;
        _maxDamage += levels * _damageIncreasePerLevel;
        _maxAttackSpeed += levels * _armorPointsIncreasePerLevel;
        _maxMoveSpeed += levels * _moveSpeedIncreasePerLevel;
        _maxAttackRange += levels * _maxAttackRange;
        _maxHealthRegeneration += levels * _maxHealthRegeneration;
    }
}
