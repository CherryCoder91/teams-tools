using System;

namespace LoadoutDrop.Services
{
    /// <summary>
    /// A Service that can prevent the MS Teams application from going inactive while the user is away from their PC.
    /// </summary>
    /// <remarks>
    /// Likely to also keep other apps from triggering AFK actions.
    /// </remarks>
    public interface ITeamsKeepAliveService
    {
        /// <summary>
        /// Emits when the functionality of keeping teams alive is toggled on/off.
        /// </summary>
        event EventHandler<bool>? ActiveStateChanged;

        /// <summary>
        /// Toggle the functionality of keeping teams alive on/off
        /// </summary>
        void ToggleTeamsAlive();
    }
}