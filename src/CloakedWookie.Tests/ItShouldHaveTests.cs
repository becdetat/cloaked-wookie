using System;
using NUnit.Framework;
using Shouldly;

namespace CloakedWookie.Tests
{
	[TestFixture]
	public class ItShouldHaveTests
	{
		[Test]
		public void AndItDoes()
		{
			"test".ShouldBe ("test");
		}
	}
}

