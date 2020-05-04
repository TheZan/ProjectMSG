using System;

namespace ProjectMSG.Service
{
    internal class EventSubscriber : IDisposable
    {
        private readonly Action<EventSubscriber> _action;

        public EventSubscriber(Type messageType, Action<EventSubscriber> action)
        {
            MessageType = messageType;
            _action = action;
        }

        public Type MessageType { get; }

        public void Dispose()
        {
            _action?.Invoke(this);
        }
    }

    internal class MessageSubscriber : IDisposable
    {
        private readonly Action<MessageSubscriber> _action;

        public MessageSubscriber(Type receiverType, Type messageType, Action<MessageSubscriber> action)
        {
            ReceiverType = receiverType;
            MessageType = messageType;
            _action = action;
        }

        public Type ReceiverType { get; }
        public Type MessageType { get; }

        public void Dispose()
        {
            _action?.Invoke(this);
        }
    }
}