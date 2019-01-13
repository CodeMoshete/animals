public static class Service
{
    public static CharacterData Characters
    {
        get
        {
            return CharacterData.Instance;
        }
    }

    public static UIController Ui
    {
        get
        {
            return UIController.Instance;
        }
    }

    public static TimerService Timers
    {
        get
        {
            return TimerService.Instance;
        }
    }
}
