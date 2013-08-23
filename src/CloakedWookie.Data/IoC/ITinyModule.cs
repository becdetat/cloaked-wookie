using System;
using TinyIoC;

namespace CloakedWookie.Data
{
	public interface ITinyModule
	{
		void Register(TinyIoCContainer container);
	}
}

