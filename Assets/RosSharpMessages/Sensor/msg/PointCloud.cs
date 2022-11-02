/* 
 * This message is auto generated by ROS#. Please DO NOT modify.
 * Note:
 * - Comments from the original code will be written in their own line 
 * - Variable sized arrays will be initialized to array of size 0 
 * Please report any issues at 
 * <https://github.com/siemens/ros-sharp> 
 */



using RosSharp.RosBridgeClient.MessageTypes.Std;
using RosSharp.RosBridgeClient.MessageTypes.Geometry;

namespace RosSharp.RosBridgeClient.MessageTypes.Sensor
{
    public class PointCloud : Message
    {
        public const string RosMessageName = "sensor_msgs/PointCloud";

        //  This message holds a collection of 3d points, plus optional additional
        //  information about each point.
        //  Time of sensor data acquisition, coordinate frame ID.
        public Header header { get; set; }
        //  Array of 3d points. Each Point32 should be interpreted as a 3d point
        //  in the frame given in the header.
        public Point32[] points { get; set; }
        //  Each channel should have the same number of elements as points array,
        //  and the data in each channel should correspond 1:1 with each point.
        //  Channel names in common practice are listed in ChannelFloat32.msg.
        public ChannelFloat32[] channels { get; set; }

        public PointCloud()
        {
            this.header = new Header();
            this.points = new Point32[0];
            this.channels = new ChannelFloat32[0];
        }

        public PointCloud(Header header, Point32[] points, ChannelFloat32[] channels)
        {
            this.header = header;
            this.points = points;
            this.channels = channels;
        }
    }
}
