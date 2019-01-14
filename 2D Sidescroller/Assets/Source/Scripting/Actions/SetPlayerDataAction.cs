public class SetPlayerDataAction : CustomAction
{
    public string DataId;
    public int Value;
    public CustomAction OnComplete;

    public override void Initiate()
    {
        Service.PlayerData.SetStat(DataId, Value);

        if (OnComplete != null)
        {
            OnComplete.Initiate();
        }
    }
}
