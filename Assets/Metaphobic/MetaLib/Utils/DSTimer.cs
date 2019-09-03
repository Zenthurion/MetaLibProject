using System.Threading.Tasks;
using System.Timers;

namespace DwarvenSoftware.Framework.Utils
{
    public class DSTimer
    {
        private float _elapsed;
        private int _stepSize;
        private bool _running;
        
        public float Elapsed => _elapsed;

        public DSTimer(int stepSize = 100)
        {
            _stepSize = stepSize;
        }
        
        public void Start()
        {
            if(!_running)
                new Task(Timer).Start();
        }

        private async void Timer()
        {
            _running = true;
            while (_running)
            {
                await Task.Delay(_stepSize);
                _elapsed += _stepSize / 1000f;
            }
        }

        public void Stop()
        {
            _running = false;
        }

        public void Reset()
        {
            _running = false;
            _elapsed = 0;
        }
    }
}