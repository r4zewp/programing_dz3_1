using Newtonsoft.Json;

internal class Film
{
    public string? Name { get; set; } = null;
    public int? AgeLimit { get; set; } = null;
    public string? FilmType { get; set; }
    public Film(string? _name, int? _ageLimit, string? _filmType)
    {
        this.Name = _name;
        this.AgeLimit = _ageLimit;
        this.FilmType = _filmType;
    }

    protected internal static List<Film> AddFilms(List<Film> existFilms, List<Hall> existHalls)
    {
        int finalFilmNumber = 0;
        List<Film> films = new List<Film>();

        bool checker = true;
        while (checker)
        {
            Console.Write("Введите количество фильмов, которые хотите добавить (не больше 3 за раз): ");
            try
            {
                int inputFilmNumber = int.Parse(Console.ReadLine()!);
                finalFilmNumber = inputFilmNumber;

            }
            catch (Exception)
            {
                Console.WriteLine(Constants.wrongData);
            }
            if (finalFilmNumber < 3 && finalFilmNumber > 0)
            {
                Console.WriteLine("Начнем заполнение информации для каждого фильма...");
                checker = false;
            }
            else
            {
                Console.WriteLine(Constants.wrongData + "\n");
            }
        }
        /// переменные для использования при возвращении результата
        string inputFilmName = String.Empty;
        string filmType = String.Empty;
        int ageLimit = 0;
        int showsCount = 0;
        List<int> hallsToShow = new List<int>();
        DateTime tempDate = DateTime.Now;
        List<DateTime> dates = new List<DateTime>();
        List<Show> shows = new List<Show>();
        ///

        checker = true;
        while (checker)
        {
            for (int i = 0; i < finalFilmNumber; i++)
            {
                bool innerChecker = true;
                while (innerChecker)
                {
                    Console.Write($" Введите название {i + 1}-го фильма: ");
                    inputFilmName = Console.ReadLine()!;
                    if (inputFilmName != String.Empty)
                    {
                        innerChecker = false;
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(Constants.wrongData);
                    }
                }

                innerChecker = true;
                while (innerChecker)
                {
                    Console.Write($" Введите тип {i + 1}-го фильма (Предпоказ, Обычный): ");
                    var inputType = Console.ReadLine()!;
                    if (inputType != String.Empty)
                    {
                        if (inputType.ToLower() == "обычный" || inputType.ToLower() == "предпоказ")
                        {
                            filmType = inputType;
                            innerChecker = false;
                        }
                        else
                        {
                            Console.WriteLine(Constants.wrongData);
                        }
                    }
                    else
                    {
                        Console.WriteLine(Constants.wrongData);
                    }
                }

                innerChecker = true;
                while (innerChecker)
                {
                    Console.Write(" Введите возрастное ограничение для фильма (исключительно цифры): ");
                    try
                    {
                        ageLimit = int.Parse(Console.ReadLine()!);
                        if (ageLimit > 0 && ageLimit < 21)
                        {
                            innerChecker = false;
                        }
                        else
                        {
                            Console.WriteLine(Constants.wrongData);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(Constants.wrongData);
                    }
                }

                innerChecker = true;
                while (innerChecker)
                {
                    Console.Write(" Введите количество сеансов для данного фильма: ");
                    try
                    {
                        showsCount = int.Parse(Console.ReadLine()!);
                        innerChecker = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(Constants.wrongData);
                    }
                }

                innerChecker = true;
                while (innerChecker)
                {
                    for (int j = 0; j < showsCount; j++)
                    {
                        bool localChecker = true;
                        while (localChecker)
                        {
                            try
                            {
                                bool dateChecker = true;
                                while (dateChecker)
                                {
                                    Console.Write($"    Введите дату {j + 1}-го сеанса (в формате дд/мм/гггг чч:мм): ");
                                    tempDate = Convert.ToDateTime(Console.ReadLine()!);
                                    if (tempDate > DateTime.Now)
                                    {
                                        bool dateFlag = false;
                                        for (int x = 0; x < dates.Count; x++)
                                        {
                                            if (tempDate == dates[x])
                                            {
                                                dateFlag = true;
                                            }
                                            else
                                            {
                                                continue;
                                            }
                                        }
                                        if (dateFlag)
                                        {
                                            Console.WriteLine("Сеанс в эту дату уже установлен.");
                                        }
                                        else
                                        {
                                            dates.Add(tempDate);
                                            dateChecker = false;
                                            localChecker = false;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine(Constants.wrongData);
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine(Constants.wrongData);
                            }
                        }
                        localChecker = true;
                        while (localChecker)
                        {
                            if (existHalls!.Count != 0)
                            {
                                Console.WriteLine("    Доступные залы: ");
                                foreach (var hall in existHalls)
                                {
                                    Console.WriteLine($"    Зал №{hall.Number}");
                                }
                                Console.Write("    Через пробел введите залы, в которых проходят сеансы: ");
                                try
                                {
                                    var tempHallsToShow = Console.ReadLine()!.Split(" ");
                                    if (tempHallsToShow.Length <= existHalls.Count && tempHallsToShow.Length > 0)
                                    {
                                        try
                                        {
                                            foreach (var hall in existHalls)
                                            {
                                                for (int k = 0; k < tempHallsToShow.Length; k++)
                                                {
                                                    int tempHall = int.Parse(tempHallsToShow[k]);
                                                    if (tempHall == hall.Number)
                                                    {
                                                        hallsToShow.Add(hall.Number);
                                                        List<Ticket> newList = new List<Ticket>();
                                                        for (int u = 0; u < hall.NumberOfSitsAndRows![0] * hall.NumberOfSitsAndRows![1]; u++)
                                                        {
                                                            if (filmType.ToLower() == "обычный")
                                                            {
                                                                if (hall.HallType == "Обычный")
                                                                {
                                                                    newList.Add(new Ticket(Hall.DefaultTicketPrice, dates[j], inputFilmName,
                                                                        ageLimit, hall.Number));
                                                                }
                                                                else if (hall.HallType == "Большой")
                                                                {
                                                                    newList.Add(new Ticket(BigHall.DefaultTicketPrice, dates[j], inputFilmName,
                                                                        ageLimit, hall.Number));
                                                                }
                                                                else if (hall.HallType == "Малый")
                                                                {
                                                                    newList.Add(new Ticket(SmallHall.DefaultTicketPrice, dates[j], inputFilmName,
                                                                        ageLimit, hall.Number));
                                                                }
                                                            }
                                                            else if (filmType.ToLower() == "предпоказ")
                                                            {
                                                                if (hall.HallType == "Обычный")
                                                                {
                                                                    newList.Add(new Ticket(Hall.DefaultTicketPrice + 200, dates[j], inputFilmName,
                                                                        ageLimit, hall.Number));
                                                                }
                                                                else if (hall.HallType == "Большой")
                                                                {
                                                                    newList.Add(new Ticket(BigHall.DefaultTicketPrice + 200, dates[j], inputFilmName,
                                                                        ageLimit, hall.Number));
                                                                }
                                                                else if (hall.HallType == "Малый")
                                                                {
                                                                    newList.Add(new Ticket(SmallHall.DefaultTicketPrice + 200, dates[j], inputFilmName,
                                                                        ageLimit, hall.Number));
                                                                }
                                                            }
                                                        }
                                                        shows.Add(new(hall.Number, inputFilmName, dates[j], ageLimit, newList));
                                                    }
                                                    else
                                                    {
                                                        continue;
                                                    }
                                                }
                                            }

                                            localChecker = false;
                                            innerChecker = false;
                                            checker = false;

                                            Console.WriteLine(String.Empty);
                                            foreach (int num in hallsToShow)
                                            {
                                                Console.WriteLine($"Зал №{num} успешно добавлен!");
                                            }

                                            Console.WriteLine("Фильм успешно добавлен!");

                                            Thread.Sleep(1500);
                                            Console.Clear();

                                            if (filmType.ToLower() == "предпоказ")
                                            {
                                                films.Add(new Preview(inputFilmName, ageLimit, filmType));
                                            }
                                            else if (filmType.ToLower() == "обычный")
                                            {
                                                films.Add(new Film(inputFilmName, ageLimit, filmType));
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine(Constants.wrongData);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine(Constants.wrongData);
                                    }
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine(Constants.wrongData);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Залов еще не существует.\nДобавьте хотя бы один: ");
                                Hall.AddNewHall(existHalls!);
                                localChecker = false;
                            }
                        }
                    }
                }
            }
        }
        DB.SerializeFilms(films);
        DB.SerializeShows(shows);

        return films;
    }

}

internal class Preview : Film
{
    public Preview(string? _name, int? _ageLimit, string? _filmType) : base(_name, _ageLimit, _filmType)
    {
        this.Name = _name;
        this.AgeLimit = _ageLimit;
        this.FilmType = _filmType;
    }
}