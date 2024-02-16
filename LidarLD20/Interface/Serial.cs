
using System.IO.Ports;

namespace LidarLD20Driver.Interface
{
    public class Serial : ISerial
    {
        private SerialPort serialPort { get; set; }

        public void OpenSerialByte(string serialName, int speed, Action<byte[]> dataReceivedHandler)
        {
            // Crea un oggetto SerialPort
            serialPort = new SerialPort(serialName, speed);

            serialPort.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived); // Aggiunge l'handler per l'evento DataReceived
            serialPort.Open(); // Apre la porta

            // Definisce l'handler per l'evento DataReceived
            void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
            {
                byte[] buffer = new byte[serialPort.BytesToRead];
                serialPort.Read(buffer, 0, buffer.Length);

                dataReceivedHandler(buffer);
            }
        }

        public void WriteLine(string message)
        {
            serialPort.WriteLine(message); // Scrive il messaggio seguito da un carattere di nuova linea
        }

        public void CloseSerial()
        {
            // Chiude la porta quando si esce dal programma
            serialPort.Close();
        }
    }
}
