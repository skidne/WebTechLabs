﻿using artWars.BusinessLogic.DBModel;
using artWars.Domain.Entities.User;
using artWars.Helpers;
using AutoMapper;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace artWars.BusinessLogic.Core
{
	public class UserApi
	{
		internal ULoginResp UserLoginAction(ULoginData data)
		{
			UDBTable result;
			var validate = new EmailAddressAttribute();

			if (validate.IsValid(data.UserName))
			{
				var pass = LoginHelper.HashGen(data.Password);
				using (var db = new UserContext())
					result = db.Users.FirstOrDefault(u => u.Email == data.UserName && u.Password == pass);

				if (result == null)
					return new ULoginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };

				using (var todo = new UserContext())
				{
					result.LastLogin = data.LoginDateTime;
					todo.Entry(result).State = EntityState.Modified;
					todo.SaveChanges();
				}

				return new ULoginResp { Status = true };
			}
			else
			{
				var pass = LoginHelper.HashGen(data.Password);
				using (var db = new UserContext())
					result = db.Users.FirstOrDefault(u => u.Username == data.UserName && u.Password == pass);

				if (result == null)
					return new ULoginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };

				using (var todo = new UserContext())
				{
					result.LastLogin = data.LoginDateTime;
					todo.Entry(result).State = EntityState.Modified;
					todo.SaveChanges();
				}

				return new ULoginResp { Status = true };
			}
		}

		internal HttpCookie Cookie(string loginCredential)
		{
			var apiCookie = new HttpCookie("X-KEY")
			{
				Value = CookieGenerator.Create(loginCredential)
			};

			using (var db = new SessionContext())
			{
				Session curent;
				var validate = new EmailAddressAttribute();
				if (validate.IsValid(loginCredential))
					curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
				else
					curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();

				if (curent != null)
				{
					curent.CookieString = apiCookie.Value;
					curent.ExpireTime = DateTime.Now.AddMinutes(60);
					using (var todo = new SessionContext())
					{
						todo.Entry(curent).State = EntityState.Modified;
						todo.SaveChanges();
					}
				}
				else
				{
					db.Sessions.Add(new Session
					{
						Username = loginCredential,
						CookieString = apiCookie.Value,
						ExpireTime = DateTime.Now.AddMinutes(60)
					});
					db.SaveChanges();
				}
			}

			return apiCookie;
		}

		internal UserMinimal UserCookie(string cookie)
		{
			Session session;
			UDBTable curentUser;

			using (var db = new SessionContext())
				session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);

			if (session == null)
				return null;

			using (var db = new UserContext())
			{
				var validate = new EmailAddressAttribute();
				if (validate.IsValid(session.Username))
					curentUser = db.Users.FirstOrDefault(u => u.Email == session.Username);
				else
					curentUser = db.Users.FirstOrDefault(u => u.Username == session.Username);
			}

			if (curentUser == null)
				return null;

			var userminimal = Mapper.Map<UserMinimal>(curentUser);

			return userminimal;
		}
	}
}
