using MainScripts.Animation;

namespace MainScripts.Stats
{
    public class HeroStats : MainAnimator
    {
        private float _healthPoints = 100f;
        private float _maxHealthPoints = 100f;
        private float _damage = 25f;
        private float _attackRange = 1.417f;
        private float _armor = 5f;
        private float _speedAttack = 1f;
        private float _jumpUpSize = 4.5f;
        private float _speed = 7f;
        private float _jumpForce = 13f;

        public float healthPoints
        {
            get => _healthPoints;
            set => healthPoints = value > maxHealthPoints 
                ? _healthPoints = _maxHealthPoints 
                : _healthPoints = value;            
        }

        public float maxHealthPoints
        {
            get => _maxHealthPoints;            
            set => _maxHealthPoints = value;
        }

        public float damage
        {
            get => _damage;
            set => _damage = value;
        }

        public float attackRange
        {
            get => _attackRange; 
            set => _attackRange = value;
        }

        public float armor
        {
            get => _armor; 
            set => _armor = value;
        }

        public float speedAttack
        {
            get => _speedAttack; 
            set => _speedAttack = value;
        }

        public float speed
        {
            get => _speed; 
            set => _speed = value;
        }

        public float jumpForce
        {
            get => _jumpForce; 
            set => _jumpForce = value;
        }

        public float jumpUpSize
        {
            get => _jumpUpSize; 
            set => _jumpUpSize = value;
        }
    }
}