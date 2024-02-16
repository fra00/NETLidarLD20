using ClassLibrary1;
using System;

namespace LidarLD20Driver.Model
{
    public class LidarFrame
    {
        public byte Header;
        public byte VerLen;
        public int Speed;
        public int StartAngle;
        public List<PointStruct> points;
        public int EndAngle;
        public int Timestamp;
        public byte Crc8;

        public LidarFrame(byte[] data)
        {
            this.points = new List<PointStruct>();
            //byte 0 0X54
            this.Header = data[0];
            //byte 1 0x2c
            this.VerLen = data[1];

            //byte 3-4 speed 
            this.Speed = data[3] << 8 | data[2];
            //Debug.WriteLine("Radar Speed " + this.speed);

            this.StartAngle = data[5] << 8 | data[4];
            //Debug.WriteLine("Start Angle " + this.start_angle);

            this.EndAngle = data[Config.LenghtPack - 4] << 8 | data[Config.LenghtPack - 5];
            //Debug.WriteLine("end Angle " + this.end_angle);

            this.Timestamp = data[Config.LenghtPack - 2] << 8 | data[Config.LenghtPack - 3];

            this.Crc8 = data[Config.LenghtPack - 1];

            var points = data.Skip(6).Take(Config.PointPerPack * 3);
            var l = points.Count();
            for (var i = 0; i < l / 3; i = i + 1)
            {
                int diff = (this.EndAngle + 36000 - this.StartAngle) % 36000;
                var step = diff / (Config.PointPerPack - 1) / 100.0;
                var start = (this.StartAngle / 100.0) + Config.CorrectionAngle;

                double angle = start + step * i;
                // Max angle of 360 degrees
                angle = (angle % 360 + 360) % 360;

                var pointBytes = data.Skip(3 * i + 6).Take(3);
                this.points.Add(new PointStruct(pointBytes, angle));
            }
        }
    }
}
