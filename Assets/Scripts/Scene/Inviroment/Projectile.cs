using UnityEngine;

namespace Survival
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Projectile : ProjectileParam
    {
        private void Start()
        {
            _rbProjectile = GetComponent<Rigidbody2D>();

            _fireTarget = GameObject.FindGameObjectWithTag("FireTarget").transform;
        }

        private void Update()
        {
            MovementBullet();
        }

        private void MovementBullet()
        {
            _rbProjectile.AddForce(_fireTarget.up * _speedMovementBullet, ForceMode2D.Impulse);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerMovementAndAttack>()) return;

            if (collision.GetComponent<Collider2D>())
            {
                Destroy(this.gameObject);
            }
        }
    }
}
