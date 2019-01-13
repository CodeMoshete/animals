public class EvaluatePlayerDataAction : CustomAction
{
    public enum EvaluationType
    {
        GreaterThan,
        GreaterThanOrEqualTo,
        LessThan,
        LessThanOrEqualTo,
        EqualTo
    }

    public string DataId;
    public EvaluationType Evaluation;
    public int Comparison;
    public CustomAction OnTrue;
    public CustomAction OnFalse;

    public override void Initiate()
    {
        bool isSuccess = false;
        int playerDataVal = Service.PlayerData.GetStat(DataId);
        switch(Evaluation)
        {
            case EvaluationType.EqualTo:
                isSuccess = playerDataVal == Comparison;
                break;
            case EvaluationType.GreaterThan:
                isSuccess = playerDataVal > Comparison;
                break;
            case EvaluationType.LessThan:
                isSuccess = playerDataVal < Comparison;
                break;
            case EvaluationType.LessThanOrEqualTo:
                isSuccess = playerDataVal <= Comparison;
                break;
            case EvaluationType.GreaterThanOrEqualTo:
                isSuccess = playerDataVal >= Comparison;
                break;
        }

        if (isSuccess && OnTrue != null)
        {
            OnTrue.Initiate();
        }
        else if (!isSuccess && OnFalse != null)
        {
            OnFalse.Initiate();
        }
    }
}
