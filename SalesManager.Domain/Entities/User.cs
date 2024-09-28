using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesManager.Domain.Entities
{
	public class User
	{
		[Key]
		[Column("TX_ID")]
		public Guid Id { get; private set; }

		[Column("TX_NOME")]
		public string Name { get; set; }

		[Column("TX_LOGIN")]
		public string UserName { get; private set; }

		[Column("TX_EMAIL")]
		public string Email { get; set; }

		[Column("TX_SENHA")]
		public string Password { get; set; }

		[Column("TX_BLOQUEADO")]
		public UserStatus IsActive { get; set; }

		[Column("TX_CRIADO_EM")]
		public long CreatedAt { get; private set; }

		[Column("TX_ATUALIZADO_EM")]
		public long UpdatedAt { get; private set; }

		public User()
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

