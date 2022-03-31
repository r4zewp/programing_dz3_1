internal class Constants
{
    public const string wrongBut = "Нажата неверная клавиша. Повторите нажатие!";
    public const string wrongData = "Ввведены неверные данные. Повторите ввод!";
    public const string ComingToAdmin = "Переходим в консоль администратора...";
    public const string ComingToUser = "Переходим в консоль пользователя...";
    public const string UserExists = "Пользователь с таким именем уже зарегистрирован.";
    public const string UserNotExists = "Пользователя с таким именем не существует.";
    public const string WrongSignData = "Вы ввели неверное имя пользователя или пароль.";
    public const string HallAlreadyExists = "Зал с таким номером уже существует. Повторите ввод!";
    public static void Welcome()
    {
        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("Добро пожаловать в модель кинокассы!".Length / 2)) + "}",
            "Добро пожаловать в модель кинокассы!"));
        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("Вам предстоит выбрать пользователя для продолжения".Length / 2)) + "}",
           "Вам предстоит выбрать пользователя для продолжения"));
        Console.WriteLine(String.Empty);
        Console.WriteLine("~ Для того, чтобы продолжить администратором, нажмите на клавишу 'a',");
        Console.WriteLine("~ Чтобы продолжить обычным пользователем - нажмите на клавишу 'u',");
        Console.WriteLine("~ Чтобы завершить программу, нажмите на 'ESC'.");
    }

    public static void UserRegOrSign()
    {
        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("Привет, пользователь!".Length / 2)) + "}",
            "Привет, пользователь!"));
        Console.WriteLine(String.Empty);
        Console.WriteLine("Вы хотите войти или зарегистрироваться?");
        Console.WriteLine("~ Для того, чтобы зарегистрироваться, нажмите на кнопку 'r',");
        Console.WriteLine("~ Чтобы войти, нажмите на кнопку 's',");
        Console.WriteLine("~ Чтобы вернуться назад, нажмите 'Backspace'.");
        Console.WriteLine(String.Empty);
    }

    public static void UserAddInfo(User user)
    {
        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ($"Привет, {user.Username}".Length / 2)) + "}",
            $"Привет, {user.Username}!"));
        Console.WriteLine(String.Empty);
        Console.WriteLine("Тебе предстоит заполнить дополнительную информацию: \n");
    }

    public static void UserChooseCommand(User user)
    {
        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ($"Привет, {user.Name}".Length / 2)) + "}",
            $"Привет, {user.Name}!"));
        Console.WriteLine("~ Для того, чтобы проверить баланс, нажмите 'b',");
    }

    public static void AdminSign()
    {
        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("С возвращением!".Length / 2)) + "}",
           "С возвращением!"));
        Console.WriteLine(String.Empty);
        Console.WriteLine("Имя пользователя администратора - admin,");
        Console.WriteLine("Пароль администратора - admin. \n");
    }

    public static void AdminChooseCommand()
    {
        Console.WriteLine(String.Format("{0," + ((Console.WindowWidth / 2) + ("С возвращением!".Length / 2)) + "}",
           "С возвращением!"));
        Console.WriteLine(String.Empty);
        Console.WriteLine("~ Чтобы добавить новый зал, нажмите на 'a',");
    }

}