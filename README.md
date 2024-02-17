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

Example:
![image](https://github.com/fra00/NETLidarLD20/assets/9625783/135cf7e1-6bcd-46fd-bb8d-2977514e4f57)
