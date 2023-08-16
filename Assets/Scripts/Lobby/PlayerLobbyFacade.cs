using Zenject;

namespace RoboBall
{
    public class PlayerLobbyFacade
    {
        private LobbySlot playerSlot;
        //private CharacterSelector characterSelector;
        private PlayerData playerData;
        private int characterIndex;

        public bool IsReady { get; private set; }

        public PlayerLobbyFacade(PlayerData playerData, LobbySlot.Factory factory/*, CharacterSelection */)
        {
            this.playerData = playerData;
            playerSlot = factory.Create(playerData.InputUser.pairedDevices[0].displayName, "P1");
            //characterSelector create
        }

        public class Factory : PlaceholderFactory<PlayerData, PlayerLobbyFacade>
        {
        }
    }
}
