using System;
namespace SalesManager.Application.Interfaces
{
	public abstract class GenericUsecase<I, O>
	{
		public GenericUsecase()
		{
		}

		public Task<O> Perform(I input)
		{
			return ApplyInteralLogic(input);
		}

		protected abstract Task<O> ApplyInteralLogic(I input);
	}
}


