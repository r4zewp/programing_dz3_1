[Serializable]
internal class Ticket
{
    public string? OwnerName { get; set; }
    public string? OwnerSurname { get; set; }
    public string? OwnerSName { get; set; }
    public int? Price { get; set; }
    public DateTime? Date { get; set; }
    public string? Film { get; set; }
    public int? AgeLimit { get; set; }
    public bool? IsBought { get; set; } = false;
    public int? HallNumber { get; set; }

    public Ticket(int? _price, DateTime? _date, string? _film, int? _ageL, int? _hallN)
    {
        this.Price = _price;
        this.Date = _date;
        this.Film = _film;
        this.HallNumber = _hallN;
        this.AgeLimit = _ageL; 
    }
}