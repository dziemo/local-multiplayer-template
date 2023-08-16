using TMPro;
using UnityEngine;
using Zenject;

namespace RoboBall
{
    public class LobbySlot : MonoBehaviour, IPoolable<string, string, IMemoryPool>
    {
        [SerializeField]
        private TMP_Text slotName;
        [SerializeField]
        private TMP_Text slotShortName;
        private IMemoryPool pool;

        public void OnPlayerLeft()
        {
            pool.Despawn(this);
        }

        public void OnSpawned(string name, string shortName, IMemoryPool pool)
        {
            this.pool = pool;
            slotName.text = name;
            slotShortName.text = shortName;
        }

        public void OnDespawned()
        {
            pool = null;
        }

        public class Factory : PlaceholderFactory<string, string, LobbySlot>
        {
        }
    }
}
