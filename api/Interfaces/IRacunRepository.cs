public interface IRacunRepository{
    Task<RacunGetDTO> VratiRacun(int korpaID);
}