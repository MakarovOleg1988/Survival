using UnityEngine;

namespace Survival
{
    public class SoundManager : MonoBehaviour, IEventManager
    {
        [SerializeField]
        private AudioSource _shootRifleSound;

        [SerializeField]
        private AudioSource _DamagePlayerSound;

        [SerializeField]
        private AudioSource _reloadRevolverSound;

        private void Start()
        {
            IEventManager._onSetShootRifle += SetShootRifleSound;
            IEventManager._onSetDamagePlayer += SetDamageplayerSound;
            IEventManager._onSetReloadWeapon += SetReloadWeaponSound;
        }

        private void SetShootRifleSound()
        {
            _shootRifleSound.Play();
        }

        private void SetDamageplayerSound()
        {
            _DamagePlayerSound.Play();
        }

        private void SetReloadWeaponSound()
        {
            _reloadRevolverSound.Play();
        }

        private void OnDestroy()
        {
            IEventManager._onSetShootRifle -= SetShootRifleSound;
            IEventManager._onSetDamagePlayer -= SetDamageplayerSound;
            IEventManager._onSetReloadWeapon -= SetReloadWeaponSound;
        }
    }
}
