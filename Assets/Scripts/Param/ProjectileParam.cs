using UnityEngine;

namespace Survival
{
    public class ProjectileParam : MonoBehaviour
    {
        protected Rigidbody2D _rbProjectile;
        protected Transform _fireTarget;

        [SerializeField, Range(1, 5)]
        protected int _damage;
        
        [SerializeField, Range(1f, 10f)]
        protected float _speedMovementBullet;

        [SerializeField, Range(1f, 3f)]
        protected float _lifeTime;
    }
}
