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
}