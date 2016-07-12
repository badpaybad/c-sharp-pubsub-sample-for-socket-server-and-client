using System;

namespace PubSubServicesSample
{
    public interface IPubSubServices
    {
        void PublishToAllChannel(string message);
        void SubcribeAllChannel(string subcriber, Func<string, bool> callBack);
        void Publish(string chanelKey, string message);
        void Subcribe(string subcriber, string channelKey, Func<string, bool> callBack);
        void Unsubcribe(string subcriber, string channelKey);
        void UnsubcribeAllChannel(string subcriber);
        void RemoveChannel(string channelKey);
    }
}