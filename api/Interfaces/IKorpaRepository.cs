public interface IKorpaRepository{
    Task<ICollection<Korpa>> VratiSveKorpe();
    Task<Korpa> VratiKorpuPoId(int id);
    bool KorpaPostoji(int id);
    Task<bool> DodajKorpuAsync(KorpaPostDTO korpaPostDTO);
    Task<bool> IzmeniKorpuAsync(KorpaPutDTO korpaPutDTO);
    Task<bool> IzbrisiKorpu(int korpaId);
    Task<bool> Save();
}