using System;
using NUnit.Framework;

namespace CloakedWookie.Tests
{
	public abstract class ConcernFor<T>
	{
		protected abstract T Given();

		protected T Subject { get; private set; }

		protected virtual void When() {
		}

		[TestFixtureSetUp]
		public void Initialise() {
			Subject = Given ();
			When ();
		}
	}
}

