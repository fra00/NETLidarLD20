Documentation link 
https://wiki.youyeetoo.com/en/Lidar/LD20

Example:
~~~
  private LidarLD20 lidarDriver;
  lidarDriver.callbackReadPackage = (LidarFrame frame) =>
  {
    string pack = JsonConvert.SerializeObject(frame);
    Debug.WriteLine(pack);
  };
  lidarDriver.Read();
~~~
