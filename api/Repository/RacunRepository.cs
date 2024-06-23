
using Microsoft.EntityFrameworkCore;

public class RacunRepository:IRacunRepository{
    private readonly DataContext _dataContext;
    public RacunRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<RacunGetDTO> VratiRacun(int korpaId)
    {
        RacunGetDTO noviRacun = new RacunGetDTO();
        double iznos = 0;
        int brojProizvoda =0;
        List<string> proizvodi = new List<string>();
        foreach(var stavka in _dataContext.ProizvodKorpe.Where(pk=>pk.KorpaId == korpaId).Include(pk=>pk.Proizvod)){
            iznos+=stavka.Proizvod.Cena*stavka.BrojProizvoda;
            brojProizvoda+=stavka.BrojProizvoda;
            proizvodi.Add(stavka.Proizvod.Naziv);
        }
        noviRacun.BrojProizvoda = brojProizvoda;
        noviRacun.Iznos = iznos;
        noviRacun.Proizvodi = proizvodi;
        return noviRacun;
    }
}