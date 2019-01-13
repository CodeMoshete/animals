public class SetPlayerDataAction : CustomAction
{
    public string DataId;
    public int Value;

    public override void Initiate()
    {
        Service.PlayerData.SetStat(DataId, Value);
    }
}
