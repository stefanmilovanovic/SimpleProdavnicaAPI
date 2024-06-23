
using Microsoft.EntityFrameworkCore;

public class ProizvodRepository:IProizvodRepository{
    private readonly DataContext _dataContext;
    public ProizvodRepository(DataContext dataContext)
    {
        this._dataContext = dataContext;
    }

    public async Task<bool> DodajProizvod(ProizvodPostDTO proizvodPostDTO)
    {
        Proizvod noviProizvod = new Proizvod(){
            Naziv = proizvodPostDTO.Naziv,
            Cena = proizvodPostDTO.Cena
        };
        await _dataContext.Proizvodi.AddAsync(noviProizvod);
        return await Save();
    }

    public async Task<bool> IzmeniProizvod(ProizvodPutDTO proizvodPutDTO)
    {
        Proizvod proizvodZaIzmenu = await _dataContext.Proizvodi.FirstOrDefaultAsync(p=>p.Id == proizvodPutDTO.Id);
        proizvodZaIzmenu.Naziv = proizvodPutDTO.Naziv;
        proizvodZaIzmenu.Cena = proizvodPutDTO.Cena;
        _dataContext.Proizvodi.Update(proizvodZaIzmenu);
        return await Save();
    }

    public async Task<bool> ObrisiProizvod(int proizvodId)
    {
        var proizvodZaBrisanje = await _dataContext.Proizvodi.FirstOrDefaultAsync(p=>p.Id == proizvodId);
        _dataContext.Proizvodi.Remove(proizvodZaBrisanje);
        return await Save();
    }

    public bool ProizvodPostoji(int proizvodId)
    {
        return _dataContext.Proizvodi.Any(p=>p.Id==proizvodId);
    }

    public async Task<bool> Save()
    {
        var saved = await _dataContext.SaveChangesAsync();
        return saved>0?true:false;
    }

    public async Task<Proizvod> VratiProizvodPoId(int proizvodId)
    {
        return await _dataContext.Proizvodi.FirstOrDefaultAsync(p=>p.Id == proizvodId);
    }

    public async Task<ICollection<Proizvod>> VratiSveProizvode()
    {
        return await _dataContext.Proizvodi.ToListAsync();
    }
}