using Arena.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Arena.Presentation.Api.Controllers
{
    [ApiController, Route("[controller]")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            try
            {
                return Ok(_teamService.List());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
