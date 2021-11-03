﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain;
using DataAccess.EFCore.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.Generic;
using API.Exceptions;
using API.DTO;

namespace API.Controllers
{
    [ApiController]
    [Route("api/zttn")]
    public class ZttnController : ControllerBase
    {
        private readonly ILogger<Zttn> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ZttnController(ILogger<Zttn> logger,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("get-all/{includeDeleted?}")]
        public async Task<IActionResult> GetAll(bool includeDeleted = false)
        {
            try
            {
                var zttns = await _unitOfWork.ZTTNs.GetAll(includeDeleted);
                var result = _mapper.Map<IEnumerable<ZttnDTO>>(zttns);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, e.Message, null);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new InternalServerErrorException(e.Message));
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }

        [HttpGet("get-by-f-id/{fId:int}")]
        public async Task<ActionResult<ZttnDTO>> GetZttnByFId(int fId)
        {
            try
            {
                var result = await _unitOfWork.ZTTNs.GetByFId(fId);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_mapper.Map<ZttnDTO>(result));
                }
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, e.Message, null);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new InternalServerErrorException(e.Message));
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<ZttnDTO>> CreateZttn(ZttnDTO zttn)
        {
            try
            {
                if (zttn == null)
                {
                    return BadRequest();
                }
                else
                {
                    var map = _mapper.Map<Zttn>(zttn);

                    var addedZttn = await _unitOfWork.ZTTNs.Add(map);
                    await _unitOfWork.SaveAsync();

                    var mapAdded = _mapper.Map<ZttnDTO>(addedZttn);
                    return CreatedAtAction(nameof(GetZttnByFId), new { fId = mapAdded.F_ID }, mapAdded);
                }
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, e.Message, null);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new InternalServerErrorException(e.Message));
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult> UpdateZttn(ZttnDTO updated)
        {
            try
            {
                var mappedZttn = _mapper.Map<Zttn>(updated);
                _unitOfWork.ZTTNs.Update(mappedZttn);
                await _unitOfWork.SaveAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, e.Message, null);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new InternalServerErrorException(e.Message));
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }

        [HttpDelete("delete/{fId:int}")]
        public async Task<ActionResult> DeleteZttn(int fId)
        {
            try
            {
                var entity = await _unitOfWork.ZTTNs.GetByFId(fId);
                if (entity != null && entity.F_ID != 0)
                {
                    _unitOfWork.ZTTNs.Remove(entity);
                    await _unitOfWork.STTNs.RemoveBySysn((int)entity.SYSN);
                    await _unitOfWork.SaveAsync();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                _logger.LogWarning(e, e.Message, null);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new InternalServerErrorException(e.Message));
            }
            finally
            {
                _unitOfWork.Dispose();
            }
        }
    }
}
