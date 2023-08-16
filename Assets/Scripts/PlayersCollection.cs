using System.Collections.Generic;
using UnityEngine;

namespace RoboBall
{
    [CreateAssetMenu(fileName = "PlayersCollection", menuName = "PlayersCollection")]
    public class PlayersCollection : ScriptableObject
    {
        private List<PlayerData> players = new List<PlayerData>();
        public List<PlayerData> Players => players;

        public int Count => players.Count;

        public void Add(PlayerData data)
        {
            players.Add(data);
        }

        private void OnDisable()
        {
            players.Clear();
        }
    }
}
