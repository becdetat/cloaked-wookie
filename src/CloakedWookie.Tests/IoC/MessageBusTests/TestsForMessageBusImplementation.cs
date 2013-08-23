using System;
using NUnit.Framework;
using CloakedWookie.Data;
using TinyIoC;
using Shouldly;

namespace CloakedWookie.Tests
{
	[TestFixture]
	public class TestsForMessageBusImplementation
	{
		public class TestMessage
		{
			public string Payload{ get; set;}
		}

		public class Handler1 : IHandle<TestMessage>
		{
			public string Result{ get; set;}
			public void Handle(TestMessage message)
			{
				Result = string.Format ("Handler1: {0}", message.Payload);
			}
		}
		public class Handler2 : IHandle<TestMessage>
		{
			public string Result{get;set;}
			public void Handle(TestMessage message)
			{
				Result = string.Format ("Handler2: {0}", message.Payload);
			}
		}

		[Test]
		public void ItWorks()
		{
			var container = new TinyIoCContainer ();
			container.Register<IHandle<TestMessage>, Handler1> ().AsSingleton ();
			container.Register<IHandle<TestMessage>, Handler2> ().AsSingleton ();

			var handler1 = container.Resolve<Handler1> ();
			var handler2 = container.Resolve<Handler2> ();

			var bus = container.Resolve<IMessageBus> ();

			bus.Publish (new TestMessage { Payload = "test" });

			handler1.Result.ShouldBe ("Handler1: test");
			handler2.Result.ShouldBe ("Handler2: test");
		}

	}
}

