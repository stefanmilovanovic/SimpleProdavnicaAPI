
using Microsoft.EntityFrameworkCore;

public class ProizvodRepository:IProizvodRepository{
    private readonly DataContext _dataContext;
    public ProizvodRepository(DataContext dataContext)
    {
        this._dataContext = dataContext;
    }

    public bool ProizvodPostoji(int proizvodId)
    {
        return _dataContext.Proizvodi.Any(p=>p.Id==proizvodId);
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