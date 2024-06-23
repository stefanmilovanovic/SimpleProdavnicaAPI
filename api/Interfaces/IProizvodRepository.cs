public interface IProizvodRepository{
    Task<ICollection<Proizvod>> VratiSveProizvode();
    Task<Proizvod> VratiProizvodPoId(int proizvodId);
    bool ProizvodPostoji(int proizvodId);
    Task<bool> DodajProizvod(ProizvodPostDTO proizvodPostDTO);
    Task<bool> IzmeniProizvod(ProizvodPutDTO proizvodPutDTO);
    Task<bool> ObrisiProizvod(int proizvodId);
    Task<bool> Save();
}