using System;
using TinyIoC;

namespace CloakedWookie.Data
{
	public class DataModule : ITinyModule
	{
		public void Register(TinyIoCContainer container)
		{
			container
				.Register<IMessageBus, MessageBus> ()
				.AsSingleton ();
		}
	}
}

