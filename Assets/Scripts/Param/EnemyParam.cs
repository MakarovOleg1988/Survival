using UnityEngine;

namespace Survival
{
    public class EnemyParam : UnitParam
    {
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
    }
}
