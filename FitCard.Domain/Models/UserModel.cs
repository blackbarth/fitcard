﻿using System;

namespace FitCard.Domain.Models
{
    public class UserModel
    {
		private int _id;

		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _nome;

		public string Nome
		{
			get { return _nome; }
			set { _nome = value; }
		}

		private string _email;

		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}

	}
}