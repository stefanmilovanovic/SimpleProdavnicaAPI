public interface IKorpaRepository{
    Task<ICollection<Korpa>> VratiSveKorpe();
    Task<Korpa> VratiKorpuPoId(int id);
    bool KorpaPostoji(int id);
}