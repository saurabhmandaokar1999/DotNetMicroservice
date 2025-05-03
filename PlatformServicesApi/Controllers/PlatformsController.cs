using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformServicesApi.Data;
using PlatformServicesApi.Dtos;

namespace PlatformServicesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    { private readonly IPlatformRepo _platformRepo;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo platformRepo, IMapper mapper)
        {
            _platformRepo = platformRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetAllPlatforms()
        {
            var platformItems = _platformRepo.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
        }
        [HttpGet("/{id}")]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatformById(int id)
        {
            var platformItems = _platformRepo.GetPlatformById(id);
            if (platformItems != null)
            {
                return Ok(_mapper.Map<PlatformReadDto>(platformItems));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
