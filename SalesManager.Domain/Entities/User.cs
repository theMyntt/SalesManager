using System;
namespace SalesManager.Domain.Entities
{
	public class User
	{
		public Guid Id { get; private set; }
		public string Name { get; set; }
		public string UserName { get; private set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public UserStatus IsActive { get; set; }
		public long CreatedAt { get; private set; }
		public long UpdatedAt { get; private set; }

		private User()
		{
		}

		public User(
			string Name,
			string Email,
			string Password)
		{
			this.Name = Name;
			this.Email = Email;
			this.Password = Password;

			Id = Guid.NewGuid();
			IsActive = UserStatus.Active;
			CreatedAt = GenerateTimestamp();
			UpdatedAt = GenerateTimestamp();
			UserName = GenerateUserName(Name);
		}

		public User(
			Guid Id,
            string Name,
			string UserName,
            string Email,
            string Password,
			UserStatus IsActive,
			long CreatedAt,
			long UpdatedAt
            )
		{
			this.Id = Id;
			this.Name = Name;
			this.UserName = UserName;
			this.Email = Email;
			this.Password = Password;
			this.IsActive = IsActive;
			this.CreatedAt = CreatedAt;
			this.UpdatedAt = UpdatedAt;
		}

		private static long GenerateTimestamp()
		{
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

		private static string GenerateUserName(string Name)
		{
			List<string> fullName = new(Name.Split(" "));

			string finalName = "";
			finalName += fullName[0][0];
			finalName += fullName[fullName.Count - 1];

			return finalName;
		}
	}

	public enum UserStatus
	{
		Active,
		Inactive
	}
}

