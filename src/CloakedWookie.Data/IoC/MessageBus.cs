using System;
using TinyIoC;

namespace CloakedWookie.Data
{
	public interface IMessageBus
	{
		void Publish<T> (T message);
	}

	internal class MessageBus : IMessageBus
	{
		readonly TinyIoCContainer _container;

		public MessageBus (TinyIoCContainer container)
		{
			_container = container;
		}

		public void Publish<T>(T message)
		{
			foreach (var handler in _container.ResolveAll<IHandle<T>>())
			{
				handler.Handle (message);
			}
		}
	}
}

