namespace LidarLD20Driver.Model
{
    public class PointStruct
    {
        public int distance;
        public byte intensity;
        public double angle;

        public PointStruct(IEnumerable<byte> points , double angle)
        {
            var packet = points.ToArray();
            this.distance = packet[1] << 8 | packet[0];
            //Debug.WriteLine("distance " + this.distance);
            this.intensity = packet[2];
            //Debug.WriteLine("intensity " + this.intensity);
            this.angle = angle;
        }
    }
}
