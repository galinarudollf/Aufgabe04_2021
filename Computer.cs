using System;
using System.IO;
using System.Threading;


class Computer
{
	private string UserNameField;

	public string UserName
	{
		get
		{
			return this.UserNameField;
		}
	}

	public void SwitchUser(string NewUserName)
	{
		Console.WriteLine("Logging out ...");
		Thread.Sleep(1000);
		Console.WriteLine("Logging in as {0} ...", NewUserName);
		Thread.Sleep(1000);

		this.UserNameField = NewUserName;
	}

	private Random CrashRandom;

	public bool HasCrashed
	{
		get;
		private set;
	}

	public void SaveFile(string FileName)
	{
		SaveFile(Path.Combine(@"C:", "Users", this.UserNameField, "Desktop"), FileName);
	}

	public void SaveFile(string FilePath, string FileName)
	{
		//Crashed?
		if (this.HasCrashed)
		{
			throw new InvalidOperationException("Sorry, the computer has already crashed. Please reboot.");
		}

		//Output details ...
		Console.WriteLine("Saving file: {0}", Path.Combine(FilePath, FileName));

		//Trigger crash by random:
		if ((this.CrashRandom.Next() % 4) == 3)
		{
			this.HasCrashed = true;
			throw new InvalidOperationException("Oh no, the computer has crashed :( ...");
		}
	}

	public void Reboot()
	{
		Console.WriteLine("Rebooting ...");
		Thread.Sleep(2000);

		Console.Beep();
		Console.WriteLine("Reboot complete!");

		this.HasCrashed = false;
	}

	private byte[] IPAddressBytes;

	public string IPAddress
	{
		get
		{
			return IPTools.IPAddressToString(this.IPAddressBytes);
		}

		set
		{
			this.IPAddressBytes = IPTools.StringToIPAddress(value);
		}
	}

	 public void BurnBluray(string Label, string Content, out Bluray blurayToBurn)
	 {
	 	Console.WriteLine("Burning Bluray ({0}) ...", Label);
	 	Thread.Sleep(2000);

	 	blurayToBurn = new Bluray(Label, Content);
	 	Console.WriteLine("Bluray has been burned successfully.");
	 }

	public void Print()
	{
		Console.WriteLine("========================================");
		Console.WriteLine("{0,-20}: {1}", "Current user", this.UserName);
		Console.WriteLine("{0,-20}: {1}", "IP address", this.IPAddress);
		Console.WriteLine("{0,-20}: {1}", "Has crashed", this.HasCrashed);
		Console.WriteLine("========================================");
	}
	
	public Computer(Random Rand)
	{
		//Start as administrator:
		this.UserNameField = "Administrator";

		//Initialize the random object:
		this.CrashRandom = Rand;

		//Not crashed since last reboot:
		this.HasCrashed = false;

		//Use a default, valid IP address:
		this.IPAddressBytes = IPTools.LocalHostBytes;
	}
}
