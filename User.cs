using Newtonsoft.Json;

[Serializable]
internal class User
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? SecondName { get; set; }
    public int Balance { get; set; } = 0;

    public User() { }
    public User(string uname, string password)
    {
        this.Username = uname;
        this.Password = password;
    }

    protected internal static List<User> UpdateAdditionalInformation(User user)
    {
        Constants.UserAddInfo(user);
        while (true)
        {
            Console.Write("Как тебя зовут? - ");
            var inputName = Console.ReadLine();
            if (inputName != String.Empty)
            {
                Console.Write("Введи свою фамилию - ");
                var inputSurname = Console.ReadLine();
                if (inputSurname != String.Empty)
                {
                    Console.Write("Введи свое отчество - ");
                    var inputSecondName = Console.ReadLine();
                    if (inputSecondName != String.Empty)
                    {
                        Console.WriteLine("И последнее...");
                        Console.Write("Введи сумму, на которую хочешь пополнить баланс (не более 1000 руб.) - ");
                        try
                        {
                            int inputBalance = Convert.ToInt32(Console.ReadLine());
                            if (inputBalance > 0 && inputBalance <= 1000)
                            {
                                Console.WriteLine("Мы успешно обновили твои данные!");
                                var updatedUsers = DB.UpdateUser(user, inputName!, inputSurname!, inputSecondName!, inputBalance);

                                Thread.Sleep(1500);
                                Console.Clear();
                                return updatedUsers;
                            }
                            else
                            {
                                Console.WriteLine(Constants.wrongData + "\n");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine(Constants.wrongData);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine(Constants.wrongData + "\n");
            }
        }
    }

    protected internal static User CreateNewUser(List<User> existUsers)
    {
        while (true)
        {
            Console.Write("Введите имя пользователя (не более 10 символов): ");
            string? inputUsername = Console.ReadLine();
            if (inputUsername!.Length > 0 && inputUsername.Length <= 10)
            {
                Console.Write("Введите пароль (не более 8 символов): ");
                string? inputPassword = Console.ReadLine();
                if (inputPassword!.Length > 0 && inputPassword.Length <= 8)
                {
                    bool isSignedUp = false;
                    foreach (User user in existUsers)
                    {
                        if (user.Username == inputUsername)
                        {
                            isSignedUp = true;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    if (isSignedUp)
                    {
                        Console.WriteLine(Constants.UserExists + "\n");
                    }
                    else
                    {
                       User newUser = new User(inputUsername, inputPassword);
                       DB.SerializeNewUser(newUser);

                    }
                }
                else
                {
                    Console.WriteLine(Constants.wrongData + "\n");
                }
            }
            else
            {
                Console.WriteLine(Constants.wrongData + "\n");
            }
        }
    }

    protected internal static User UserSignIn(List<User> existUsers)
    {
        var existUserPassword = String.Empty;
        User existUser = new User();

        while (true)
        {
            Console.Write("Введите свое имя пользователя: ");
            var inputUsername = Console.ReadLine();
            if (inputUsername != String.Empty)
            {
                foreach (var user in existUsers)
                {
                    if (user.Username == inputUsername)
                    {
                        existUser = user;
                    }
                    else
                    {
                        continue;
                    }
                }
                Console.Write("Введите пароль: ");
                var inputPassword = Console.ReadLine();
                if (inputPassword != String.Empty)
                {
                    if (inputPassword == existUser.Password)
                    {
                        Console.WriteLine("Успешно!");
                        Thread.Sleep(1500);
                        Console.Clear();

                        return existUser;
                    }
                    else
                    {
                        Console.WriteLine(Constants.WrongSignData + "\n");
                    }
                }
                else
                {
                    Console.WriteLine(Constants.wrongData + "\n");
                }
            }
            else
            {
                Console.WriteLine(Constants.wrongData);
            }
        }
    }
    protected internal static void ShowUserBalance(User user)
    {
        Console.WriteLine($"Ваш баланс - {user.Balance} руб.");
    }
}
