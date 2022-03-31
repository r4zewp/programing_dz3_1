using Newtonsoft.Json;
internal class DB
{
    public List<User>? ExistUsers { get; set; }
    public List<Hall>? ExistHalls { get; set; }
    public List<Film>? ExistFilms { get; set; }
    public List<Show>? ExistShows { get; set; }
    private static string userFile = "users.json";
    private static string hallFile = "halls.json";
    private static string filmFile = "films.json";
    private static string showFile = "shows.json";

    public DB()
    {
        this.ExistUsers = GetAllUsers();
        this.ExistHalls = GetAllHalls();
        this.ExistFilms = GetAllFilms();
        this.ExistShows = GetAllShows();
    }
    protected internal static List<User> GetAllUsers()
    {
        JsonSerializer ser = new JsonSerializer();

        if (File.Exists(userFile))
        {
            using (StreamReader sr = new StreamReader(userFile))
            {
                using (JsonReader jr = new JsonTextReader(sr))
                {
                    ser.TypeNameHandling = TypeNameHandling.All;
                    List<User>? existUsers = ser.Deserialize<List<User>>(jr);
                    return existUsers!;
                }
            }
        }
        else
        {
            return new List<User>();
        }
    }

    protected internal static User SerializeNewUser(User newUser)
    {
        List<User> existUsers = GetAllUsers();

        existUsers.Add(newUser);

        JsonSerializer ser = new JsonSerializer();

        using (StreamWriter sr = new StreamWriter(userFile))
        {
            using (JsonTextWriter jr = new JsonTextWriter(sr))
            {
                jr.Formatting = Formatting.Indented;
                ser.TypeNameHandling = TypeNameHandling.All;
                ser.Serialize(jr, existUsers);
                Console.WriteLine("Успешно!");

                Thread.Sleep(1500);
                Console.Clear();

                return newUser;
            }
        }

    }

    protected internal static List<User> UpdateUser(User user, string name, string surname, string secondName, int balance)
    {
        List<User> existUsers = GetAllUsers();
        var indexToUpdate = 0;
        foreach (User userItem in existUsers)
        {
            if (userItem.Username == user.Username)
            {
                indexToUpdate = existUsers.IndexOf(userItem);
            }
            else
            {
                continue;
            }
        }
        existUsers[indexToUpdate].Name = name;
        existUsers[indexToUpdate].Surname = surname;
        existUsers[indexToUpdate].SecondName = secondName;
        existUsers[indexToUpdate].Balance = balance;

        JsonSerializer sr = new JsonSerializer();
        using (StreamWriter sw = new StreamWriter(userFile))
        {
            using (JsonTextWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;
                sr.Serialize(jw, existUsers);
                return existUsers;
            }
        }
    }

    protected internal static List<Hall> GetAllHalls()
    {
        if (File.Exists(hallFile))
        {
            JsonSerializer jsr = new JsonSerializer();
            using (StreamReader sr = new StreamReader(hallFile))
            {
                using (JsonTextReader jr = new JsonTextReader(sr))
                {

                    jsr.TypeNameHandling = TypeNameHandling.All;
                    var existHalls = jsr.Deserialize<List<Hall>>(jr);
                    if (existHalls?.Count != null)
                    {
                        return existHalls;
                    }
                    else
                    {
                        return new List<Hall>();
                    }
                }
            }
        }
        else
        {
            return new List<Hall>();
        }
    }

    protected internal static List<Hall> SerializeHalls(List<Hall> existHalls)
    {
        JsonSerializer jsr = new JsonSerializer();
        using (StreamWriter sw = new StreamWriter(hallFile))
        {
            using (JsonTextWriter jw = new JsonTextWriter(sw))
            {
                jsr.TypeNameHandling = TypeNameHandling.All;
                jsr.Formatting = Formatting.Indented;
                jsr.Serialize(jw, existHalls);
            }
        }
        return existHalls;
    }

    protected internal static List<Film> GetAllFilms()
    {
        if (File.Exists(filmFile))
        {
            JsonSerializer jsr = new JsonSerializer();
            using (StreamReader sr = new StreamReader(filmFile))
            {
                using (JsonTextReader jr = new JsonTextReader(sr))
                {
                    jsr.TypeNameHandling = TypeNameHandling.All;
                    var existFilms = jsr.Deserialize<List<Film>>(jr);
                    if (existFilms?.Count != null)
                    {
                        return existFilms;
                    }
                    else
                    {
                        return new List<Film>();
                    }
                }
            }
        }
        else
        {
            return new List<Film>();
        }
    }

    protected internal static List<Film> SerializeFilms(List<Film> existFilms)
    {
        JsonSerializer jsr = new JsonSerializer();
        using (StreamWriter sw = new StreamWriter(filmFile))
        {
            using (JsonTextWriter jw = new JsonTextWriter(sw))
            { 
                jsr.Formatting = Formatting.Indented;
                jsr.TypeNameHandling = TypeNameHandling.All;
                jsr.Serialize(jw, existFilms);

                return existFilms;
            }
        }
    }

    protected internal static List<Show> GetAllShows()
    {
        List<Show> existShows = new List<Show>();
        JsonSerializer jsr = new JsonSerializer();
        if (File.Exists(showFile))
        {
            using (StreamReader sr = new StreamReader(showFile))
            {
                using (JsonTextReader jr = new JsonTextReader(sr))
                {
                    jsr.TypeNameHandling = TypeNameHandling.All;
                    existShows = jsr.Deserialize<List<Show>>(jr)!;
                    return existShows;
                }
            }
        }
        else
        {
            return new List<Show>();
        }
    }

    protected internal static List<Show> SerializeShows(List<Show> existShows)
    {
        JsonSerializer jsr = new JsonSerializer();
        using (StreamWriter sw = new StreamWriter(showFile))
        {
            using (JsonTextWriter jw = new JsonTextWriter(sw))
            {
                jsr.Formatting = Formatting.Indented;
                jsr.TypeNameHandling = TypeNameHandling.All;
                jsr.Serialize(jw, existShows);

                return existShows;
            }
        }
    }
}

