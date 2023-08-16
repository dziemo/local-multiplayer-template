using RoboBall;
using UnityEngine;
using Zenject;

public class LobbyInstaller : MonoInstaller
{
    [SerializeField]
    private PlayersCollection playersCollection;
    [SerializeField]
    private LobbySlot lobbySlotPrefab;
    [SerializeField]
    private Transform lobbySlotsParent;

    public override void InstallBindings()
    {
        Container.Bind<PlayersManager>().AsSingle().NonLazy();
        Container.Bind<PlayersCollection>().FromInstance(playersCollection).AsSingle();
        Container.Bind<DeviceJoinHandler>().AsSingle();

        Container.BindFactory<string, string, LobbySlot, LobbySlot.Factory>()
            .FromPoolableMemoryPool<string, string, LobbySlot, LobbySlotPool>(poolBinder => poolBinder
            .WithInitialSize(PlayersManager.MAX_PLAYERS)
            .FromComponentInNewPrefab(lobbySlotPrefab)
            .UnderTransform(lobbySlotsParent));

        Container.Bind<PlayerLobbyFacade>().AsSingle();
        Container.BindFactory<PlayerData, PlayerLobbyFacade, PlayerLobbyFacade.Factory>();

        //LobbySignalsInstaller.Install(Container);
    }

    private class LobbySlotPool : MonoPoolableMemoryPool<string, string, IMemoryPool, LobbySlot>
    {
    }
}