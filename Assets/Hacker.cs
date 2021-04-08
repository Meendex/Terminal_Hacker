using UnityEngine;

public class Hacker : MonoBehaviour {

    // Game state

    int level;
    string password;
    enum Screen {MainMenu, Password, Win };
    Screen currentScreen;


    //Game configuration data
    const string menuHint = "You may type menu at any time.";
    string[] level1Passwords = { "books", "aisle", "shelf", "password", "font", "borrow"};
    string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest"};
    string[] level3Passwords = { "mars", "earth", "galaxy", "spaceship", "calisto", "jupiter"};
    
    
    // Use this for initialization
    void Start ()
    {
        print(level1Passwords [0]);
        ShowMainMenu ();

	}
   
	void ShowMainMenu () 
	{
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
		Terminal.WriteLine("What would you like to hack into?");
		Terminal.WriteLine("");
		Terminal.WriteLine("Press 1 for the local library");
		Terminal.WriteLine("Press 2 for the police station");
		Terminal.WriteLine("press 3 for NASA");
		Terminal.WriteLine("");
		Terminal.WriteLine("Enter your selection ");
		
	}

    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "quit" || input == "exit")
        {
            
            Application.Quit();
        }
        else if (currentScreen == Screen.MainMenu)
        { 
        RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book...");
                Terminal.WriteLine(@"
    _______
   /     //
  /     //
 /_____//
(_____(/"
                );
                break;
            case 2:
                Terminal.WriteLine("You got the prison key");
                Terminal.WriteLine(@"
   __
  /0 \_______
  \__/-=' = '"
                );
                break;

            case 3:
                Terminal.WriteLine("You have a nice rocket trip to the Moon");
                Terminal.WriteLine(@"
  ____
  \   \__________
   |             \
   |   __________/
  /___/
"
                );
                break;
            default:
                Debug.LogError("Invalid level reached");
                break;
        }
        
    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please chose valid level");
            Terminal.WriteLine(menuHint);
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("You have chosen level " + level);
        SetRandomPassword();
        Terminal.WriteLine("Please enter your pasword, hint: " + password.Anagram());
        Terminal.WriteLine(menuHint);

    }

    void SetRandomPassword()
    {
        switch (level)
        {

            case 1:
                int index1 = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[index1];
                break;
            case 2:
                int index2 = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[index2];
                break;
            case 3:
                int index3 = Random.Range(0, level3Passwords.Length);
                password = level3Passwords[index3];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;

        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
