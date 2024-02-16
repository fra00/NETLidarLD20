namespace LidarLD20Driver.Interface
{
    public interface ISerial
    {
        void CloseSerial();
        void OpenSerialByte(string serialName, int speed, Action<byte[]> dataReceivedHandler);
        void WriteLine(string message);
    }
}