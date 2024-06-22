public interface IProizvodRepository{
    Task<ICollection<Proizvod>> VratiSveProizvode();
    Task<Proizvod> VratiProizvodPoId(int proizvodId);
    bool ProizvodPostoji(int proizvodId);
}