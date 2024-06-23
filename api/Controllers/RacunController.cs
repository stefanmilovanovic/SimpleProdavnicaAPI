using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/racun")]
public class RacunController:ControllerBase{
    private readonly IRacunRepository _racunRepository;
    private readonly IKorpaRepository _korpaRepository;
    public RacunController(IRacunRepository racunRepository,IKorpaRepository korpaRepository)
    {
        _racunRepository = racunRepository;
        _korpaRepository = korpaRepository;
    }

    [HttpGet("/korpa/{id}")]
    public async Task<IActionResult> VratiRacunKorpe(int id){
        if(!_korpaRepository.KorpaPostoji(id)){
            return BadRequest();
        }
        var racun = await _racunRepository.VratiRacun(id);
        return Ok(racun);
    }

}