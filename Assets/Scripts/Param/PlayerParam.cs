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

        [SerializeField, Range(1f, 5f)]
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
        protected Transform _fireTarget;

        protected bool _canShoot;
    }
}
