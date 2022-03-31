using Newtonsoft.Json;

[Serializable]
internal class Hall
{
    public int Number { get; set; }
    public int[]? NumberOfSitsAndRows { get; set; }
    public int[,]? SchemeOfSits { get; set; } = null;
    public List<Film>? FilmsShown { get; set; } = null;
    /// <summary>
    /// Дефолтное значение
    /// </summary>
    public static int DefaultTicketPrice = 200;
    public string? HallType = "Обычный";

    public Hall()
    { }
    public Hall(int _number, int[] _numberofsar, int[,] _sos)
    {
        this.Number = _number;
        this.NumberOfSitsAndRows = _numberofsar;
        this.SchemeOfSits = _sos;
    }

    protected internal static List<Hall> AddNewHall(List<Hall> existHalls)
    {
        /// объявляем результативные переменные
        int finalNumber = 0;
        int[] finalRAS = new int[] { };
        string finalType = String.Empty;
        int[,] finalScheme = new int[,] { { } };
        List<Ticket> ticketList = new List<Ticket>();

        /// ввод номера зала (номер - аналог ид, для более легкого обращения к ним)
        bool checker = true;
        while (checker)
        {
            Console.WriteLine("Напоминаем, номер зала не должен превышать 100.");
            Console.Write("Введите номер зала: ");
            try
            {
                var inputNumber = int.Parse(Console.ReadLine()!);
                if (inputNumber <= 0 || inputNumber > 100)
                {
                    Console.WriteLine(Constants.wrongData);
                }
                else
                {
                    if (existHalls.Count != 0)
                    {
                        bool flag = false;
                        foreach (var hall in existHalls)
                        {
                            if (inputNumber == hall.Number)
                            {
                                flag = true;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        if (flag)
                        {
                            Console.WriteLine(Constants.HallAlreadyExists + "\n");
                        }
                        else
                        {
                            finalNumber = inputNumber;
                            checker = false;
                        }
                    }
                    else
                    {
                        finalNumber = inputNumber;
                        checker = false;
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine(Constants.wrongData);
            }
        }

        checker = true;

        /// вводим количество рядов и сидений для схемы цен
        while (checker)
        {

            Console.Write("Введите количество рядов и сидений в одном ряду (через пробел): ");
            string[] temp = Console.ReadLine()!.Split(" ");
            if (temp.Length == 0 || temp.Length > 2 || temp.Length == 1)
            {
                Console.WriteLine(Constants.wrongData);
            }
            else
            {
                try
                {
                    int[] inputSitsAndRows = new int[2];
                    for (int i = 0; i < temp.Length; i++)
                    {
                        inputSitsAndRows[i] = int.Parse(temp[i]);
                    }
                    finalRAS = inputSitsAndRows;
                    checker = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine(Constants.wrongData);
                }
            }
        }

        /// выбираем тип зала
        checker = true;
        while (checker)
        {
            Console.Write("Введите тип зала (Обычный, Большой, Малый): ");
            var inputType = Console.ReadLine();
            if (inputType!.Equals("Большой") || inputType.Equals("Обычный") || inputType.Equals("Малый"))
            {

                finalType = inputType;
                checker = false;

            }
            else
            {
                Console.WriteLine(Constants.wrongData);
            }
        }

        /// ценовая схема зала будет заполняться автоматически, учитывая дефолтную цену для каждого зала
        /// в дальнейшем администратор может изменить цену каждого билета на цену, не меньше дефолтной

        var tempScheme = new int[finalRAS[0], finalRAS[1]];
        for (int i = 0; i < finalRAS[0]; i++)
        {
            for (int j = 0; j < finalRAS[1]; j++)
            {
                if (finalType == "Большой")
                {
                    tempScheme[i, j] = BigHall.DefaultTicketPrice;

                }
                else if (finalType == "Малый")
                {
                    tempScheme[i, j] = SmallHall.DefaultTicketPrice;

                }
                else if (finalType == "Обычный")
                {
                    tempScheme[i, j] = Hall.DefaultTicketPrice;
                }
            }
        }
        finalScheme = tempScheme;

        /// создаем объект зала и сериализуем его
        if (finalType == "Обычный")
        {
            existHalls.Add(new Hall(finalNumber, finalRAS, finalScheme));
            Console.WriteLine("Успешно!\n");
        }
        else if (finalType == "Малый")
        {
            existHalls.Add(new SmallHall(finalNumber, finalRAS, finalScheme));
            Console.WriteLine("Успешно!\n");
        }
        else if (finalType == "Большой")
        {
            existHalls.Add(new BigHall(finalNumber, finalRAS, finalScheme));
            Console.WriteLine("Успешно!\n");
        }
        /// "подключаемся" к бд и добавляем зал
        DB.SerializeHalls(existHalls);

        return existHalls;
    }
}
[Serializable]
internal class BigHall : Hall
{
    public static new int DefaultTicketPrice = 300;
    public new string? HallType = "Большой";

    public BigHall() : base()
    { }

    public BigHall(int _number, int[] _numberofsar, int[,] _sos) :
        base(_number, _numberofsar, _sos)
    {
        this.Number = _number;
        this.NumberOfSitsAndRows = _numberofsar;
        this.SchemeOfSits = _sos;
    }
}

[Serializable]
internal class SmallHall : Hall
{
    public static new int DefaultTicketPrice = 400;
    public new string? HallType = "Малый";
    public SmallHall() : base()
    { }
    public SmallHall(int _number, int[] _numberofsar, int[,] _sos) :
        base(_number, _numberofsar, _sos)
    {
        this.Number = _number;
        this.SchemeOfSits = _sos;
        this.NumberOfSitsAndRows = _numberofsar;
    }
}