using DataLayer;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Runner
{
	class Program
	{
		private static IConfigurationRoot config;

		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
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
			return new ContactRepository(config.GetConnectionString("DefaultConnection"));
		}
	}
}
