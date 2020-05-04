using Prism.Events;

namespace DSSW.Client.Events
{
    /// <summary>
    /// 获得新史诗时触发此事件
    /// </summary>
    public class NewScreenShotEvent : PubSubEvent<string>
    {
        public string NewScreenShotPath { get; set; }
    }
}
