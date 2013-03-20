using OrganizerClassLibrary.Interfaces;
using System;
using System.Timers;

namespace OrganizerClassLibrary
{
    public class Reminder : IAlarmTime
    {
        //fields
        private EventHandler alarmEvent;
        private Timer timer;
        private bool enabled;

        public DateTime AlarmTime { get; set; }
        public string Message { get; set; }

        //constructor
        public Reminder(DateTime alarmTime, string message)
        {
            try
            {
                this.Message = message;
                this.AlarmTime = alarmTime;
                this.timer = new Timer();
                this.timer.Elapsed += TimeElapsed;
                this.timer.Interval = 100;
                this.timer.Start();
                this.enabled = true;

                if (AlarmTime.Date < DateTime.Now.Date || AlarmTime.TimeOfDay < DateTime.Now.TimeOfDay)
                {
                    throw new OrganizerException("DueDate must be after the Current Date!");
                }
            }
            catch(OrganizerException oex)
            {
                Console.WriteLine(oex.Message);
            }
        }

        //methods
        //Event handler
        void TimeElapsed(object sender, ElapsedEventArgs e)
        {
            if (enabled && DateTime.Now.Date == AlarmTime.Date
                && DateTime.Now.TimeOfDay > AlarmTime.TimeOfDay)
            {
                enabled = false;
                OnAlarm();
                timer.Stop();
            }
        }

        //This method raises a new event
        protected virtual void OnAlarm()
        {
            if (alarmEvent != null)
            {
                alarmEvent(this, EventArgs.Empty);
            }
        }

        //New event delegate
        public event EventHandler Alarm
        {
            add
            {
                alarmEvent += value;
            }
            remove
            {
                alarmEvent -= value;
            }
        }
    }
}
