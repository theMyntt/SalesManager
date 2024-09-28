using System;
using SalesManager.Domain.Entities;

namespace SalesManager.Domain.Schemas
{
	public class UserLoginResponse : StandardResponse
	{
		public User? User { get; set; }
	}
}

