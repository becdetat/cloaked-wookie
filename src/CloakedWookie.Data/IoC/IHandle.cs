using System;

namespace CloakedWookie.Data
{
	public interface IHandle<T>
	{
		void Handle(T message);
	}
}

