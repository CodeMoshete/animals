public class AddPlayerDataAction : CustomAction
{
    public string DataId;
    public int AmountToAdd;

    public override void Initiate()
    {
        Service.PlayerData.UpdateStat(DataId, AmountToAdd);
    }
}
