using System;

class Bluray
{
	//The serial ID to use for the next DVD:
	private static uint NextSerialID = 0;

	//The serial ID of the current ID:
	public uint SerialID
	{
		get;
		private set;
	}

	//The label of the Bluray:
	public string Label
	{
		get;
		private set;
	}

	//The content (as string):
	public string Content
	{
		get;
		private set;
	}

	//Constructor:
	public Bluray(string Label, string Content)
	{
		//Obtain the next serial ID:
		this.SerialID = Bluray.NextSerialID++;

		//Assign label and content:
		this.Label = Label;
		this.Content = Content;
	}
}
