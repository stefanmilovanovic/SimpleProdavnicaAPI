using Microsoft.AspNetCore.Mvc;

[Route("api/proizvod")]
[ApiController]
public class ProizvodController:ControllerBase{
    private readonly IProizvodRepository _proizvodRepository;
    public ProizvodController(IProizvodRepository proizvodRepository)
    {
        _proizvodRepository = proizvodRepository;
    }
    [HttpGet]
    public async Task<IActionResult> VratiSveProizvode(){
        var proizvodi = await _proizvodRepository.VratiSveProizvode();
        var proizvodiDTO = proizvodi.Select(p=>p.ProizvodUGetDTO());
        return Ok(proizvodiDTO);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> VratiProizvodPoId(int id){

        if(!_proizvodRepository.ProizvodPostoji(id)){
            return NotFound();
        }

        var proizvod = await _proizvodRepository.VratiProizvodPoId(id);
        var proizvodDTO = proizvod.ProizvodUGetDTO();
        return Ok(proizvodDTO);
    }
    [HttpPost]
    public async Task<IActionResult> DodajProizvod([FromBody] ProizvodPostDTO proizvodPostDTO){
        if(proizvodPostDTO == null){
            return BadRequest();
        }
        var dodato = await _proizvodRepository.DodajProizvod(proizvodPostDTO);
        
        if(!dodato){
            ModelState.AddModelError("","Greska");
            return StatusCode(500,ModelState);
        }
        return Ok("Uspeh!");
    }
    [HttpPut]
    public async Task<IActionResult> IzmeniProizvod(ProizvodPutDTO proizvodPutDTO){
        if(!_proizvodRepository.ProizvodPostoji(proizvodPutDTO.Id)){
            return NotFound();
        }
        var izmenaUspesna = await _proizvodRepository.IzmeniProizvod(proizvodPutDTO);
        if(!izmenaUspesna){
            ModelState.AddModelError("","Greska");
            return StatusCode(500,ModelState);
        }
        return Ok("Uspeh!");
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> ObrisiProizvod(int id){
        if(!_proizvodRepository.ProizvodPostoji(id)){
            return NotFound();
        }
        var obrisano = await _proizvodRepository.ObrisiProizvod(id);
        if(!obrisano){
            ModelState.AddModelError("","Greska");
            return StatusCode(500,ModelState);
        }
        return Ok("Uspeh!");
    }
}