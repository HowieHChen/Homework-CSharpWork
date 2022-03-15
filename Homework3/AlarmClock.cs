using System;
using System.Collections.Generic;
using System.Linq;
namespace Homework3
{
    public class AlarmClock
    {
        DateTime alarmTime;

        public delegate void AlarmHandler(object sender, DateTime e);
        public event AlarmHandler OnTick;
        public event AlarmHandler OnAlarm;

        public AlarmClock()
        {
            OnTick += AlarmClock_OnTick;
            OnAlarm += AlarmClock_OnAlarm;
        }

        public void Start()
        {
            DateTime nowTime = DateTime.Now;
            DateTime endTime = nowTime.AddSeconds(60);
            while (nowTime < endTime)
            {
                nowTime = DateTime.Now;
                OnTick(this, nowTime);
                if (nowTime.ToString("G") == alarmTime.ToString("G"))
                {
                    OnAlarm(this, nowTime);
                }
                Thread.Sleep(1000);
            }
        }

        public void SetAlarm(int sec)
        {
            alarmTime = DateTime.Now;
            alarmTime = alarmTime.AddSeconds(sec);
            Console.WriteLine("The alarm will go off at " + alarmTime.ToString());
        }

        private void AlarmClock_OnAlarm(object sender, DateTime e)
        {
            //throw new NotImplementedException();
            Console.WriteLine("Attention! It's now " + alarmTime.ToString());
        }

        private void AlarmClock_OnTick(object sender, DateTime e)
        {
            //throw new NotImplementedException();
            Console.WriteLine("It's " + e.ToString());
        }
    }
}
