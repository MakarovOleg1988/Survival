using System;

namespace Survival
{
    public interface IEventManager
    {
        public static event Action _onSetShootRifle;
        public static event Action _onSetDamagePlayer;
        public static event Action _onSetReloadWeapon;

        public static void SendSetShootRifle()
        {
            _onSetShootRifle?.Invoke();
        }

        public static void SendSetDamagePlayer()
        {
            _onSetDamagePlayer?.Invoke();
        }

        public static void SendSetReloadWeapon()
        {
            _onSetReloadWeapon?.Invoke();
        }
    }
}
