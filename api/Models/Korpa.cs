public class Korpa{
    public int Id {get; set;}
    public string Firma {get;set;}
    public ICollection<ProizvodKorpa> ProizvodKorpe{get; set;}
}