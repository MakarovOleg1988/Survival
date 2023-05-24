using UnityEngine;

namespace Survival
{
    public abstract class UnitParam: MonoBehaviour
    {
        protected Rigidbody2D _rbUnit;

        [SerializeField, Range(1f, 10f)]
        protected float _speedMovement;
        protected float SpeedMovement() => _speedMovement;

        [SerializeField, Range(1f, 100f)]
        private float _speedRotation;
        protected float SpeedRotation() => _speedRotation;

        [SerializeField]
        protected GameObject[] _items;
    }
}
