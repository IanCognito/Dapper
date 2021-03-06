﻿using DataLayer;
using Microsoft.Extensions.Configuration;
using System;
using System.Diagnostics;
using System.IO;

namespace Runner
{
	class Program
	{
		private static IConfigurationRoot config;

		static void Main(string[] args)
		{
			Initialize();
			Get_all_should_return_6_results();
		}

		static void Get_all_should_return_6_results()
		{
			// arrange
			var repository = CreateRepository();

			// act
			var contacts = repository.GetAll();

			// assert
			Console.WriteLine($"Count: {contacts.Count}");
			Debug.Assert(contacts.Count == 6);
			contacts.Output();

		}

		private static void Initialize()
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
			config = builder.Build();
		}

		private static IContactRepository CreateRepository()
		{
			return new ContactRepository(config.GetConnectionString("DefaultConnection")); // does not work
		}
	}
}
