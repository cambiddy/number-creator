﻿// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography;
using static System.Console;

int usrNumber = 0;
string NL = Environment.NewLine; // shortcut
string NORMAL = IsOutputRedirected ? "" : "\x1b[39m";
string RED = IsOutputRedirected ? "" : "\x1b[91m";
string GREEN = IsOutputRedirected ? "" : "\x1b[92m";
string YELLOW = IsOutputRedirected ? "" : "\x1b[93m";
string BLUE = IsOutputRedirected ? "" : "\x1b[94m";
string MAGENTA = IsOutputRedirected ? "" : "\x1b[95m";
string CYAN = IsOutputRedirected ? "" : "\x1b[96m";
string GREY = IsOutputRedirected ? "" : "\x1b[97m";
string BOLD = IsOutputRedirected ? "" : "\x1b[1m";
string NOBOLD = IsOutputRedirected ? "" : "\x1b[22m";
string UNDERLINE = IsOutputRedirected ? "" : "\x1b[4m";
string NOUNDERLINE = IsOutputRedirected ? "" : "\x1b[24m";
string REVERSE = IsOutputRedirected ? "" : "\x1b[7m";
string NOREVERSE = IsOutputRedirected ? "" : "\x1b[27m";

mainMenu();




void newNumber()
{
	Clear();
	WriteLine($"Welcome to the Number Creator! Would you like to {RED}create your own number,{NORMAL} or would you like to be {YELLOW}assigned a number?{NORMAL}");
    WriteLine();
	WriteLine($"{RED}0: Create my own");
	WriteLine($"{YELLOW}1: Random number{NORMAL}");
	switch (usrActionInput(0, 1))
	{
		case 0:
			Clear();
            bool x = false;
            WriteLine("What would you like your number to be?");
            while (x == false)
            {
                string actionInput = ReadLine();

                if (int.TryParse(actionInput, out usrNumber))
                {
                    x = true;
                }
                else
                {
                    WriteLine("Please enter a valid number: ");
                }

            }
            Clear();
            WriteLine("Your number is now: " + usrNumber );
            WriteLine("What do you want to do now?");
            WriteLine("0: Go back to the main menu");
            WriteLine("1: Edit my number");
            switch(usrActionInput(0, 1))
            {
                case 0:
                    mainMenu();
                    break;
                case 1:
                    break;
                default:
                    WriteLine("what have you done?!?!");
                    break;

            }


            break;
		case 1:
			Clear();
			usrNumber = randomNumber();
			WriteLine("Your number is: " + usrNumber);
            Clear();
            WriteLine("Your number is now: " + usrNumber);
            WriteLine("What do you want to do now?");
            WriteLine("0: Go back to the main menu");
            WriteLine("1: Edit my number");
            switch (usrActionInput(0, 1))
            {
                case 0:
                    mainMenu();
                    break;
                case 1:
                    break;
                default:
                    WriteLine("what have you done?!?!");
                    break;

            }
            break;
		default:
			WriteLine("what have you done???");
			break;
	}
}

int randomNumber()
{
    int rFrom = 0;
    bool x = false;
	WriteLine("Where would you like your number to start?");
    while (x == false)
    {
        string actionInput = ReadLine();

        if (int.TryParse(actionInput, out rFrom))
        {
            x = true;
        }
        else
        {
            WriteLine("Please enter a valid number: ");
        }

    }

    int rTo = 0;
    x = false;
    WriteLine("Where would you like your number to end?");
    while (x == false)
    {
        string actionInput = ReadLine();

        if (int.TryParse(actionInput, out rTo) && (rTo > rFrom))
        {
            x = true;
        }
        else
        {
            WriteLine("Please enter a valid number greater than what you started with: ");
        }

    }
    Random number = new();
	return number.Next(rFrom, rTo);
}

static int usrActionInput(int rFrom, int rTo)
{
	int usrAction = 0;
	bool x = false;
	while (x == false)
	{
		string actionInput = ReadLine();



		if (int.TryParse(actionInput, out usrAction) && (rFrom <= usrAction) && (usrAction <= rTo))
		{
			x = true;
		}
		else
		{
			WriteLine("Please enter a valid number between " +rFrom +" and "+ rTo + ":");
		}

	}
	return usrAction;
}

void mainMenu()
{
    Clear();
    WriteLine($"{YELLOW}Welcome to the Number Creator!{NORMAL}");
    WriteLine();
    WriteLine("Your current number is: " + usrNumber);
    WriteLine();
    WriteLine("What would you like to do now?: ");
    WriteLine("0:New Number");
    WriteLine("1:HELP");
    WriteLine("2:Settings");
    WriteLine("3: Quit");
    switch (usrActionInput(0, 3))
    {
        case 0:
            newNumber();
            break;
        case 1:
            WriteLine("1:HELP");
            break;
        case 2:
            WriteLine("2:Settings");
            break;
        case 3:
            Environment.Exit(0);
            break;
        default:
            WriteLine("something went really really wrong.");
            break;
    }

}