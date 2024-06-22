
using Microsoft.EntityFrameworkCore;

public class KorpaRepository : IKorpaRepository
{
    private readonly DataContext _dataContext;
    public KorpaRepository(DataContext dataContext)
    {
        this._dataContext = dataContext;
    }
    public bool KorpaPostoji(int id)
    {
        return _dataContext.Korpe.Any(k=>k.Id == id);
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