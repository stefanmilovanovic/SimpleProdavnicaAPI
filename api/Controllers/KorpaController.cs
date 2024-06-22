using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/korpa")]
public class KorpaController:ControllerBase{
    private readonly IKorpaRepository _korpaRepository;
    public KorpaController(IKorpaRepository korpaRepository)
    {
        this._korpaRepository = korpaRepository;
    }
    [HttpGet]
    public async Task<IActionResult> VratiSveKorpe(){
        var korpe = await _korpaRepository.VratiSveKorpe();
        var korpeDTO = korpe.Select(k=>k.KorpaUGetDTO());
        return Ok(korpeDTO);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> VratiKorpuPoID(int id){
        if(!_korpaRepository.KorpaPostoji(id)){
            return NotFound();
        }
        var korpa = await _korpaRepository.VratiKorpuPoId(id);
        var korpaDto = korpa.KorpaUGetDTO();
        return Ok(korpa);
    }
}