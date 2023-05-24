using UnityEngine;

namespace Survival
{
    public class EnemyNavigation: MonoBehaviour
    {
        private Transform _player;

        [SerializeField, Range(2f, 50f)]
        protected float _agroDistance;

        public Vector2 _directionToPlayer { get; private set; }

        public bool _awareOfPlayer { get; private set; }

        private void Start()
        {
            _player = FindObjectOfType<PlayerMovementAndAttack>().transform;
        }

        private void Update()
        {
            if (_player == null) return;

            Vector2 vectorToPlayer = _player.position - transform.position;
            _directionToPlayer = vectorToPlayer.normalized;

            if (vectorToPlayer.magnitude <= _agroDistance) _awareOfPlayer = true;
            else _awareOfPlayer = false;
        }
    }
}
