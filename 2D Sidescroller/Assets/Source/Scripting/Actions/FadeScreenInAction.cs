using UnityEngine;

public class FadeScreenInAction : CustomAction
{
    public float Delay;
    public float Duration;
    private float totalDuration;
    private bool isInitialized;

    public override void Initiate()
    {
    }

    public void Update()
    {
        if (isInitialized)
        {
            float dt = Time.deltaTime;
            if (Delay > 0)
            {
                Delay -= dt;
                return;
            }

            Duration -= dt;
            if (Duration <= 0f)
            {
                Duration = 0f;
                isInitialized = false;
            }

            float pct = Duration / totalDuration;
        }
    }
}
