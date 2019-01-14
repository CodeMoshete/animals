public class AddPlayerDataAction : CustomAction
{
    public string DataId;
    public int AmountToAdd;
    public CustomAction OnComplete;

    public override void Initiate()
    {
        Service.PlayerData.UpdateStat(DataId, AmountToAdd);

        if (OnComplete != null)
        {
            OnComplete.Initiate();
        }
    }
}
