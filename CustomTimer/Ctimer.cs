using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gladiator_Manager.CustomTimer
{
    internal class Ctimer
    {
        public Ctimer(int duration)
        {
            _duration = new TimeSpan(0, 0, duration);
        }

        private DateTime _targetTime { get; set; }
        private TimeSpan _duration { get; set; }
        private DateTime _currentTime { get; set; }

        public DateTime TargetTime => _targetTime;
        public TimeSpan Duration => _duration;


        public void StartTimer()
        {
            _currentTime = DateTime.Now;
            _targetTime = _currentTime + _duration;

            do
            {

            } while (_targetTime > DateTime.Now);

        }

        public void SetDuration(int duration)
        {
            _duration = new TimeSpan(0, 0, duration);
        }

    }
}
