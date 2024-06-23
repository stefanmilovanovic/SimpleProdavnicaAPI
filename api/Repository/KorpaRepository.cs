
using Microsoft.EntityFrameworkCore;

public class KorpaRepository : IKorpaRepository
{
    private readonly DataContext _dataContext;
    public KorpaRepository(DataContext dataContext)
    {
        this._dataContext = dataContext;
    }

    public async Task<bool> DodajKorpuAsync(KorpaPostDTO korpaPostDTO)
    {
        Korpa novaKorpa = new Korpa(){
            Firma = korpaPostDTO.Firma
        };
        await _dataContext.AddAsync(novaKorpa);
        return await Save();
    }

    public async Task<bool> IzbrisiKorpu(int korpaId)
    {
        Korpa korpaZaBrisanje = await _dataContext.Korpe.FirstOrDefaultAsync(k=>k.Id == korpaId);
        _dataContext.Korpe.Remove(korpaZaBrisanje);
        return await Save();
    }

    public async Task<bool> IzmeniKorpuAsync(KorpaPutDTO korpaPutDTO)
    {
        Korpa korpaZaIzmenu =await _dataContext.Korpe.FirstOrDefaultAsync(k=>k.Id == korpaPutDTO.Id);
        korpaZaIzmenu.Firma = korpaPutDTO.Firma;
        _dataContext.Korpe.Update(korpaZaIzmenu);
        return await Save();
    }

    public bool KorpaPostoji(int id)
    {
        return _dataContext.Korpe.Any(k=>k.Id == id);
    }

    public async Task<bool> Save()
    {
        var saved = await _dataContext.SaveChangesAsync();
        return saved>0?true:false;
    }

    public async Task<Korpa> VratiKorpuPoId(int id)
    {
        return await _dataContext.Korpe.FirstOrDefaultAsync(k=>k.Id == id);
    }

    public async Task<ICollection<Korpa>> VratiSveKorpe()
    {
        return await _dataContext.Korpe.ToListAsync();
    }
}