using System;
using System.Collections.Generic;
using UnityEngine;

public class TimerService : MonoBehaviour
{
    public static TimerService Instance { get; private set; }

    private class TimerInstance
    {
        public float TimeLeft;
        public Action<object> Callback;
        public object Cookie;
    }

    private List<TimerInstance> timers;
    private Stack<TimerInstance> timersToRemove;

    public TimerService()
    {
        timers = new List<TimerInstance>();
        timersToRemove = new Stack<TimerInstance>();
    }

    public void Start()
    {
        Instance = this;
    }

    public void CreateTimer(float duration, Action<object> callback, object cookie)
    {
        TimerInstance timer = new TimerInstance { TimeLeft = duration, Callback = callback, Cookie = cookie };
        timers.Add(timer);
    }

    public void Update()
    {
        float dt = Time.deltaTime;

        for (int i = 0, count = timers.Count; i < count; ++i)
        {
            timers[i].TimeLeft -= dt;
            if (timers[i].TimeLeft <= 0)
            {
                timers[i].Callback.Invoke(timers[i].Cookie);
                timersToRemove.Push(timers[i]);
            }
        }

        while(timersToRemove.Count > 0)
        {
            timers.Remove(timersToRemove.Pop());
        }
    }
}
