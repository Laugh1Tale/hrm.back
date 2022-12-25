﻿using Microsoft.AspNetCore.Mvc;
using SkillSystem.Application.Services.Duties.Models;
using SkillSystem.Application.Services.Positions;

namespace SkillSystem.WebApi.Controllers;

[Route("api/positions/{positionId}/duties")]
public class PositionDutiesController : BaseController
{
    private readonly IPositionsService positionsService;

    public PositionDutiesController(IPositionsService positionsService)
    {
        this.positionsService = positionsService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DutyShortInfo>>> GetPositionDuties(int positionId)
    {
        var duties = await positionsService.GetPositionDutiesAsync(positionId);
        return Ok(duties);
    }

    [HttpPut("add/{dutyId}")]
    public async Task<ActionResult<IEnumerable<DutyShortInfo>>> AddPositionDuty(int positionId, int dutyId)
    {
        await positionsService.AddPositionDutyAsync(positionId, dutyId);
        return NoContent();
    }

    [HttpDelete("{dutyId}")]
    public async Task<ActionResult<IEnumerable<DutyShortInfo>>> DeletePositionDuty(int positionId, int dutyId)
    {
        await positionsService.DeletePositionDutyAsync(positionId, dutyId);
        return NoContent();
    }
}