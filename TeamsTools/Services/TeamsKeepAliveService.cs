using System;
using System.Windows.Threading;

namespace TeamsTools.Services
{
    /// <inheritdoc cref="ITeamsKeepAliveService"/>
    internal class TeamsKeepAliveService : ITeamsKeepAliveService
    {
        private readonly bool TeamsAliveRegistered = false;
        private bool TeamsAliveActive = false;
        private readonly DispatcherTimer MoveMouseTimer = new();
        private const short secondsToRenewLifespan = 60;
        public IInputSenderService InputSenderService { get; }
        public event EventHandler<bool>? ActiveStateChanged;

        public TeamsKeepAliveService(IInputSenderService inputSenderService)
        {
            InputSenderService = inputSenderService;
        }

        public void ToggleTeamsAlive()
        {
            if (!TeamsAliveRegistered)
            {
                MoveMouseTimer.Tick += new EventHandler(CreateTeamsKeepAliveSignal);
                MoveMouseTimer.Interval = new TimeSpan(0, 0, secondsToRenewLifespan);
            }

            TeamsAliveActive = !TeamsAliveActive;
            if (TeamsAliveActive)
            {
                MoveMouseTimer.Start();
                OnActiveStateChanged(true);
            }
            else
            {
                MoveMouseTimer.Stop();
                OnActiveStateChanged(false);
            }
        }

        /// <summary>
        /// Cause an action that will similulate user activity to keep teams alive
        /// </summary>
        private void CreateTeamsKeepAliveSignal(object? sender, EventArgs e)
        {
            if (!TeamsAliveActive) return;

            InputSenderService.SendMouseInput(new InputSenderService.MouseInput[]
           {
                new InputSenderService.MouseInput
                {
                    dx = 0,
                    dy = 0,
                    dwFlags = (uint)MouseEventF.Move
                }
           });
        }

        protected virtual void OnActiveStateChanged(bool e)
        {
            ActiveStateChanged?.Invoke(this, e);
        }
    }
}
