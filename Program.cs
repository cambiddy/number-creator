// See https://aka.ms/new-console-template for more information
using System.Drawing;
using System.Security.Cryptography;
using static System.Console;

int usrNumber = 0;
int colorIndex = 0;

string NL   = Environment.NewLine; // shortcut
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

string[] colors = {NORMAL, RED, GREEN, YELLOW, BLUE, MAGENTA, CYAN, GREY };


mainMenu();

void editNumber()
{
    Clear();
    currentNumber();
    WriteLine("What would you like to do with your number?");
    WriteLine("0: ADD");
    WriteLine("1: SUBTRACT");
    WriteLine("2: MULTIPLY");
    WriteLine("3: DIVIDE");
    WriteLine("4: Color Change");
    WriteLine("5: New number");
    WriteLine("6: Main Menu");

    switch (usrActionInput(0, 6))
    {
        case 0:
            addNumber();
            break;
        case 1:
            break;
        case 2:
            break;
        case 3:
            break;
        case 4:
            colorChange();
            break;
        case 5:
            newNumber();
            break;
        case 6:
            mainMenu();
            break;
        default:
            mainMenu();
            break;
    }

}
void addNumber()
{
    Clear();

    WriteLine("What would you like to add to your number?");
    WriteLine($"{colors[colorIndex]}" + usrNumber + $"{colors[0]}" + " + ");
    int addNum = usrChooseNumber();
    usrNumber = usrNumber + addNum;
    currentNumber();
    WriteLine();
    WriteLine("What would you like to do now?");
    WriteLine("0: Add another Number");
    goBackWriteLine();



}
static void goBackWriteLine()
{
    WriteLine("1: Go back to the edit screen");
    WriteLine("2: Go back to the number creator");
    WriteLine("3: Go back to the main menu");
}
int usrChooseNumber()
{
    int chosenNumber = 0;
    bool x = false;
    while (x == false)
    {
        string actionInput = ReadLine();
        
        if (int.TryParse(actionInput, out chosenNumber))
        {
            x = true;
            
        }
        else
        {
            WriteLine("Please enter a valid number: ");
        }

    }
    return chosenNumber;
}
void newNumber()
{
	Clear();
    WriteLine($"Welcome to the Number Creator!");
    currentNumber();
    WriteLine($"Would you like to {colors[1]}create your own number,{colors[0]} or would you like to be {YELLOW}assigned a number?{NORMAL}");
	WriteLine($"{RED}0: Create my own");
	WriteLine($"{YELLOW}1: Random number{NORMAL}");
	switch (usrActionInput(0, 1))
	{
		case 0:
            Clear();
            WriteLine("What would you like your number to be?");
            usrNumber = usrChooseNumber();
            colorChange();


            break;
		case 1:
            rerollHelp();
            break;
		default:
			WriteLine("what have you done???");
			break;
	}
}

void rerollHelp()
{
    Clear();
    usrNumber = randomNumber();
    currentNumber();
    Clear();
    currentNumber();
    WriteLine("What do you want to do now?");
    WriteLine("0: Go back to the main menu");
    WriteLine("1: Edit my number");
    WriteLine("2: Re-roll my number");
            switch (usrActionInput(0, 2))
            {
                case 0:
            mainMenu();
            break;
        case 1:
            editNumber();
            break;
        case 2:
            rerollHelp();
            break;
        default:
            WriteLine("what have you done?!?!");
            break;

        }
    }
int randomNumber()
{
    int rFrom = 0;
    int rTo = 0;
    bool x = false;
    Clear();
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


    x = false;
    Clear();
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
    Random color = new();
    colorIndex = color.Next(0, 7);
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

void colorChange()
{
    Clear();
    currentNumber();
    WriteLine("What color would you like your number to be?");
    WriteLine("0: White");
    WriteLine("1: Red");
    WriteLine("2: Green");
    WriteLine("3: Yellow");
    WriteLine("4: Blue");
    WriteLine("5: Magenta");
    WriteLine("6: Cyan");
    WriteLine("7: Grey");
    colorIndex = usrActionInput(0, 7);
    Clear();
    currentNumber();
    WriteLine("What do you want to do now?");
    WriteLine("0: Go back to the main menu");
    WriteLine("1: Edit my number");
    switch (usrActionInput(0, 1))
    {
        case 0:
            mainMenu();
            break;
        case 1:
            editNumber();
            break;
        default:
            WriteLine("what have you done?!?!");
            break;

    }
}
void mainMenu()
{
    Clear();
    WriteLine($"{colors[3]}Welcome to the Number Creator!{colors[0]}");
    WriteLine();
    currentNumber();
    WriteLine();
    WriteLine("What would you like to do now?: ");
    WriteLine("0:New Number");
    WriteLine("1:Edit Current Number");
    WriteLine("2:HELP");
    WriteLine("3:Settings");
    WriteLine("4:Quit");
    switch (usrActionInput(0, 3))
    {
        case 0:
            newNumber();
            break;
        case 1:
            editNumber();
            break;
        case 2:
            help();
            break;
        case 3:
            settings();
            break;
        case 4:
            Environment.Exit(0);
            break;
        default:
            WriteLine("something went really really wrong.");
            break;
    }

}
void help()
{
    Clear();
    WriteLine("What do you need help with?");
    WriteLine("0: How do I create a number?");
    WriteLine("1; Who created this?");
    WriteLine("2: Why did you create this?");
    WriteLine("3: Will my number save after I quit?");
    WriteLine("4: Isn't this just a calculator?");
    WriteLine("5: Go home");
    switch (usrActionInput(0, 5))
    {
        case 0:
            Clear();
            WriteLine("Just go back to the home screen and choose 'New Number' From there you can edit it however you'd like!");
            WriteLine("0: Back to help");
            WriteLine("1: Back to home");
            switch (usrActionInput(0, 1))
            {
                case 0:
                    help();
                    break;
                case 1:
                    mainMenu();
                    break;
                default:
                    WriteLine("what have you done?");
                    break;
            }
            break;

        case 1:
            Clear();
            WriteLine("This was created by Cameron Biddinger on August 9th, 2024. John Dunckell helped me a lot with this, big thanks to him!");
            WriteLine("0: Back to help");
            WriteLine("1: Back to home");
            switch (usrActionInput(0, 1))
            {
                case 0:
                    help();
                    break;
                case 1:
                    mainMenu();
                    break;
                default:
                    WriteLine("what have you done?");
                    break;
            }
            break;

        case 2:
            Clear();
            WriteLine("Good question!");
            WriteLine("0: Back to help");
            WriteLine("1: Back to home");
            switch (usrActionInput(0, 1))
            {
                case 0:
                    help();
                    break;
                case 1:
                    mainMenu();
                    break;
                default:
                    WriteLine("what have you done?");
                    break;
            }
            break;
        case 3:
            Clear();
            WriteLine("Not currently. That will (hopefully) be added in version 2.0 of the Number Creator!");
            WriteLine("0: Back to help");
            WriteLine("1: Back to home");
            switch (usrActionInput(0, 1))
            {
                case 0:
                    help();
                    break;
                case 1:
                    mainMenu();
                    break;
                default:
                    WriteLine("what have you done?");
                    break;
            }
            break;
        case 4:
            Clear();
            WriteLine("No! It's a Number Creator!");
            WriteLine("0: Back to help");
            WriteLine("1: Back to home");
            switch (usrActionInput(0, 1))
            {
                case 0:
                    help();
                    break;
                case 1:
                    mainMenu();
                    break;
                default:
                    WriteLine("what have you done?");
                    break;
            }
            break;
        case 5:
            Clear();
            mainMenu();
            break;
        default:
            WriteLine("something went really really wrong.");
            break;
    }
}

void settings()
{
    Clear();
    WriteLine("NOT DEVELOPED YET. BAD");
    
} 

void currentNumber()
{
   WriteLine($"Your current number is: {colors[colorIndex]}" + usrNumber + $"{colors[0]}");
}