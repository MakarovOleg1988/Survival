using UnityEngine;

namespace Survival
{
    public class EnemyMovementAndAttack : UnitParam
    {
        private EnemyNavigation enemyNavigation;

        private Vector2 _targetDirection;

        private void Awake()
        {
            _rbUnit = GetComponent<Rigidbody2D>();
            enemyNavigation = GetComponent<EnemyNavigation>();
        }

        private void FixedUpdate()
        {
            ChooseTargetDirection();
            RotateTowardsTarget();
            SetVelocity();
        }

        private void ChooseTargetDirection()
        {
            if (enemyNavigation._awareOfPlayer)
            {
                _targetDirection = enemyNavigation._directionToPlayer;
            }
            else
            {
                _targetDirection = Vector2.zero;
            }
        }

        private void RotateTowardsTarget()
        {
            if (_targetDirection == Vector2.zero) return;

            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, _targetDirection);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, SpeedRotation() * Time.deltaTime);

            _rbUnit.SetRotation(rotation);
        }

        private void SetVelocity()
        {
            if (_targetDirection == Vector2.zero)
            {
                _rbUnit.velocity = Vector2.zero;
            }
            else
            {
                _rbUnit.velocity = transform.up * SpeedMovement();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            int random = Random.Range(0, _items.Length);

            if (collision.GetComponent<Projectile>())
            {
                CurrentHealth--;
                if (CurrentHealth <= 0)
                {
                    Instantiate(_items[random], transform.position, transform.rotation);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}