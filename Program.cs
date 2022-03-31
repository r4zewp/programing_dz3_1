DB Database = new DB();

/// проверяем на наличие фильмов
if (Database.ExistFilms?.Count == 0)
{
    Film.AddFilms(Database.ExistFilms, Database.ExistHalls!);
    Constants.Welcome();
}
else
{
    Constants.Welcome();
}
///

bool mainChecker = true;
while (mainChecker)
{
    var pressedKey = Console.ReadKey(true);
    switch (pressedKey.Key)
    {
        case ConsoleKey.A:
            Console.WriteLine(Constants.ComingToAdmin);

            Thread.Sleep(1500);
            Console.Clear();

            Constants.AdminSign();
            User existAdmin = User.UserSignIn(Database.ExistUsers!);

            Thread.Sleep(1500);
            Console.Clear();

            Constants.AdminChooseCommand();
            bool adminCommand = true;
            while (adminCommand)
            { 
                var adminKey = Console.ReadKey(true);
                switch (adminKey.Key) 
                {
                    case ConsoleKey.A:
                        var updatedHalls = Hall.AddNewHall(Database.ExistHalls!);
                        Database.ExistHalls = updatedHalls;
                        break;

                    default:
                        Console.WriteLine(Constants.wrongBut + "\n");
                        break;
                }
            }

            break;

        case ConsoleKey.U:
            Console.WriteLine(Constants.ComingToUser);

            Thread.Sleep(1500);
            Console.Clear();

            Constants.UserRegOrSign();
            bool userChecker = true;
            while (userChecker)
            {
                var userPressed = Console.ReadKey(true);
                switch (userPressed.Key)
                {
                    case ConsoleKey.S:
                        User existUser = User.UserSignIn(Database.ExistUsers!);
                        userChecker = false;
                        ///
                        Console.Clear();
                        ///
                        Constants.UserChooseCommand(existUser);
                        bool commandChecker = true;
                        while (commandChecker)
                        {
                            var commandPressed = Console.ReadKey(true);
                            switch (commandPressed.Key)
                            {
                                case ConsoleKey.B:
                                    User.ShowUserBalance(existUser);
                                    break;

                                case ConsoleKey.Backspace:
                                    commandChecker = false;
                                    userChecker = true;
                                    break;

                                default:
                                    Console.WriteLine(Constants.wrongData);
                                    break;
                            }
                        }
                        break;

                    case ConsoleKey.R:
                        User newUser = User.CreateNewUser(Database.ExistUsers!);
                        var updatedUsers = User.UpdateAdditionalInformation(newUser);
                        Database.ExistUsers = updatedUsers;
                        break;

                    case ConsoleKey.Backspace:
                        Console.Clear();
                        userChecker = false;
                        commandChecker = true;
                        break;

                    default:
                        Console.WriteLine(Constants.wrongBut + "\n");
                        break;
                }
            }
            break;

        case ConsoleKey.Escape:
            Console.WriteLine("Всего доброго!");
            Thread.Sleep(1500);
            Environment.Exit(0);
            break;


        default:
            Console.WriteLine(Constants.wrongBut);
           

            break;
    }

}