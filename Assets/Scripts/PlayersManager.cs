using UnityEngine.InputSystem.Users;

namespace RoboBall
{
    public class PlayersManager
    {
        public const int MAX_PLAYERS = 4;
        private readonly PlayerLobbyFacade.Factory facadeFactory;
        private readonly PlayersCollection players;
        private readonly DeviceJoinHandler joinHandler;

        public PlayersManager(PlayerLobbyFacade.Factory facadeFactory,
            PlayersCollection players, DeviceJoinHandler joinHandler)
        {
            this.facadeFactory = facadeFactory;
            this.players = players;
            this.joinHandler = joinHandler;
            CheckPlayerCount();
        }

        ~PlayersManager()
        {
            joinHandler.OnDeviceJoined -= JoinHandler_OnDeviceJoined;
        }

        private void CheckPlayerCount()
        {
            //TODO: Check for better conditions
            if (players.Count < MAX_PLAYERS && !joinHandler.IsEnabled)
            {
                joinHandler.EnableJoining();
                joinHandler.OnDeviceJoined += JoinHandler_OnDeviceJoined;
            }
            else if (players.Count == MAX_PLAYERS && joinHandler.IsEnabled)
            {
                joinHandler.DisableJoining();
                joinHandler.OnDeviceJoined -= JoinHandler_OnDeviceJoined;
            }
        }

        private void JoinHandler_OnDeviceJoined(InputUser newInputUser)
        {
            AddNewPlayer(newInputUser);
        }

        private void AddNewPlayer(InputUser inputUser)
        {
            GameActions newGameActions = new GameActions();
            inputUser.AssociateActionsWithUser(newGameActions);
            newGameActions.Enable();
            PlayerData newPlayer = new PlayerData(inputUser, newGameActions);
            players.Add(newPlayer);

            facadeFactory.Create(newPlayer);

            CheckPlayerCount();
        }
    }
}
