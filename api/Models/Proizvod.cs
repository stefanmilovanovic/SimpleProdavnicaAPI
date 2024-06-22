public class Proizvod{
    public int Id {get; set;}
    public string Naziv {get; set;}
    public double Cena {get; set;}
    public ICollection<ProizvodKorpa> ProizvodKorpe{get; set;}
}