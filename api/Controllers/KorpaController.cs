using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/korpa")]
public class KorpaController : ControllerBase
{
    private readonly IKorpaRepository _korpaRepository;
    public KorpaController(IKorpaRepository korpaRepository)
    {
        this._korpaRepository = korpaRepository;
    }
    [HttpGet]
    public async Task<IActionResult> VratiSveKorpe()
    {
        var korpe = await _korpaRepository.VratiSveKorpe();
        var korpeDTO = korpe.Select(k => k.KorpaUGetDTO());
        return Ok(korpeDTO);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> VratiKorpuPoID(int id)
    {
        if (!_korpaRepository.KorpaPostoji(id))
        {
            return NotFound();
        }
        var korpa = await _korpaRepository.VratiKorpuPoId(id);
        var korpaDto = korpa.KorpaUGetDTO();
        return Ok(korpaDto);
    }
    [HttpPost]
    public async Task<IActionResult> DodajKorpu([FromBody] KorpaPostDTO korpaPostDTO)
    {
        if (korpaPostDTO == null)
        {
            return BadRequest();
        }
        var sacuvano = await _korpaRepository.DodajKorpuAsync(korpaPostDTO);
        if (!sacuvano)
        {
            ModelState.AddModelError("", "Greska");
            return StatusCode(500, ModelState);
        }
        return Ok();
    }
    [HttpPut]
    public async Task<IActionResult> IzmeniKorpu([FromBody] KorpaPutDTO korpaPutDTO)
    {
        if (!_korpaRepository.KorpaPostoji(korpaPutDTO.Id))
        {
            return NotFound();
        }

        var korpaIzmenjena = await _korpaRepository.IzmeniKorpuAsync(korpaPutDTO);
        if (!korpaIzmenjena)
        {
            return StatusCode(500, ModelState);
        }
        return Ok("Uspeh!");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> ObrisiKorpu(int id){
        if(!_korpaRepository.KorpaPostoji(id)){
            return NotFound();
        }
        var obrisano =await _korpaRepository.IzbrisiKorpu(id);
        if(!obrisano){
            return StatusCode(500,"");
        }
        return Ok("Uspeh!");
    }
}