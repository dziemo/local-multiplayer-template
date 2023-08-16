using UnityEngine.InputSystem.Users;

namespace RoboBall
{
    public class PlayerData
    {
        private readonly InputUser inputUser;
        private readonly GameActions gameActions;

        public InputUser InputUser => inputUser;
        public GameActions GameActions => gameActions;

        public PlayerData(InputUser inputUser, GameActions gameActions)
        {
            this.inputUser = inputUser;
            this.gameActions = gameActions;
        }

        public PlayerData()
        {
        }
    }
}
