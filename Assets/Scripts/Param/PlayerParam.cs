using UnityEngine;
using UnityEngine.UI;

namespace Survival
{
    public class PlayerParam : UnitParam
    {
        protected NewControls _controller;

        protected Rigidbody2D _rbPlayer;
        protected Animator _animPlayer;
        protected Transform _enemy;

        public int _currentCapacityClipRifle;
        public int _maxCapacityClipRifle;

        [SerializeField, Range(0.1f, 5f)]
        protected float _timeBetweenShoot;

        [SerializeField]
        protected GameObject _bulletPrefab;

        [SerializeField]
        protected GameObject _weapon;

        [SerializeField]
        protected Slider _healthBar;

        [SerializeField]
        protected GameObject _losePanel;

        [SerializeField]
        protected GameObject[] _InventoryItems;

        [SerializeField]
        protected Transform _fireTarget;

        [SerializeField]
        private int _health;
        public int CurrentHealth
        {
            get { return _health; }
            set { _health = value; }
        }

        protected int _maxHealth;
        public int MaxHealth
        {
            get { return _maxHealth; }
            set { _maxHealth = value; }
        }

        protected bool _canShoot;
    }
}
