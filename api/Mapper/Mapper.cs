public static class Mapper{
    public static ProizvodGetDTO ProizvodUGetDTO(this Proizvod proizvod){
        return new ProizvodGetDTO(){
            Id = proizvod.Id,
            Naziv = proizvod.Naziv,
            Cena = proizvod.Cena
        };
    }
    public static KorpaGetDTO KorpaUGetDTO(this Korpa korpa){
        return new KorpaGetDTO(){
            Id = korpa.Id,
            Firma = korpa.Firma
        };
    }
}