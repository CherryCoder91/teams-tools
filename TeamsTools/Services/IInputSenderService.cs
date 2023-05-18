namespace TeamsTools.Services
{
    /// <summary>
    /// A Service that can send Input commands to the OS.
    /// </summary>
    public interface IInputSenderService
    {
        void ClickKey(ushort scanCode);
        void SendKeyboardInput(InputSenderService.KeyboardInput[] kbInputs);
        void SendMouseInput(InputSenderService.MouseInput[] mInputs);
    }
}