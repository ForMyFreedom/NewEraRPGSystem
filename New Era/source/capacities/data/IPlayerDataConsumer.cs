
public interface IPlayerDataConsumer
{
    void InjectPlayerData(IVolatilePlayerData playerData);
    IVolatilePlayerData GetVolatilePlayerData();
}
