using Newtonsoft.Json;

/// <summary>
///  Класс, обозначающий сеанс
/// </summary>
[Serializable]
internal class Show
{
    public int? Hall { get; set; }
    public string? Film { get; set; }
    public DateTime? Date { get; set; }
    public int? AgeLimit { get; set; }
    public List<Ticket>? Tickets { get; set; }
    public bool? AnyFreePlaces { get; protected internal set; }


    public Show()
    { }

    public Show(int? _hall, string? _film, DateTime? _date, int? _age, List<Ticket> _tickets)
    { 
        this.Film = _film;
        this.Date = _date;
        this.AgeLimit = _age;
        this.Hall = _hall;
        this.Tickets = _tickets;
    }

}