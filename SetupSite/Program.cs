using System;
using System.Linq;
using Microsoft.Web.Administration;

namespace SetupSite
{
	class Program
	{
		private static bool allowBlank;
		private static string userName;
		private static string password;

		static void Main()
		{
			AddSite("vsm", (mgr, site) =>
			{
				site.SetPhysicalPath(@"C:\Temp\vsm");
				site.BindToPort(9898);
				site.ServerAutoStart = true;

				site.Applications.First().VirtualDirectories.Add("/static", @"C:\Temp\static");

				var rootDir = site.Applications.First().VirtualDirectories.First();
				GetAuthInfo("Site " + site.Name, (u, p) =>
				{
					rootDir.UserName = u;
					rootDir.Password = p;
				});

			}, (mgr, appPool) =>
			{
				appPool.ManagedRuntimeVersion = "V2.0";
				appPool.ManagedPipelineMode = ManagedPipelineMode.Classic;
				appPool.Enable32BitAppOnWin64 = true;

				appPool.ProcessModel.IdentityType = ProcessModelIdentityType.SpecificUser;
				GetAuthInfo("AppPool " + appPool.Name, (u, p) =>
				{
					appPool.ProcessModel.UserName = u;
					appPool.ProcessModel.Password = p;
				});
			});
		}

		private static void AddSite(string siteName, Action<ServerManager, Site> siteConfigurator, Action<ServerManager, ApplicationPool> appPoolConfigurator)
		{
			using (var sm = new ServerManager())
			{
				var invalidChars = SiteCollection.InvalidSiteNameCharacters();
				if (siteName.IndexOfAny(invalidChars) > -1)
				{
					throw new Exception(String.Format("Invalid Site Name: {0}", siteName));
				}

				var poolName = siteName + "_AppPool";
				var appPool = sm.ApplicationPools.Add(poolName);
				appPoolConfigurator(sm, appPool);

				var site = sm.Sites.Add(siteName, "", 0);
				site.Applications.First().ApplicationPoolName = poolName;
				siteConfigurator(sm, site);

				sm.CommitChanges();
			}
		}

		private static void GetAuthInfo(string item, Action<string, string> authHandler)
		{
			Console.WriteLine("Please enter authentication information for: {0}", item);
			if( allowBlank)
				Console.WriteLine("(Leave blank to use same credentials as last time)");

			while (true)
			{
				Console.Write("Username: ");
				var inputUser = Console.ReadLine();
				if (allowBlank && String.IsNullOrEmpty(inputUser))
				{
					authHandler(userName, password);
					return;
				}

				Console.Write("Password: ");
				var inputPassword = GetPassword();
				if (!String.IsNullOrEmpty(inputPassword))
				{
					userName = inputUser;
					password = inputPassword;

					authHandler(userName, password);
					allowBlank = true;
					return;
				}
			}
		}

		private static string GetPassword()
		{
			var passwd = String.Empty;
			while (true)
			{
				var ki = Console.ReadKey(true);
				if (ki.Key == ConsoleKey.Enter)
				{
					break;
				}
				
				if (ki.Key == ConsoleKey.Backspace)
				{
					if (passwd.Length > 0)
					{
						passwd = passwd.Substring(0, passwd.Length - 1);
						Console.Write("\b \b");
					}
				}
				else
				{
					passwd += (ki.KeyChar);
					Console.Write("*");
				}
			}
			return passwd;
		}
	}

	static class Extensions
	{
		public static void SetPhysicalPath(this Site site, string path)
		{
			site.Applications.First().VirtualDirectories.First().PhysicalPath = path;
		}

		public static void BindToPort(this Site site, int port)
		{
			site.Bindings.First().BindingInformation = String.Format("*:{0}:", port);
		}
	}
}
