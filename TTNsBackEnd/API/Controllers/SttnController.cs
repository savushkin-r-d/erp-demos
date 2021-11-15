using Microsoft.AspNetCore.Mvc;
using Domain;
using DataAccess.EFCore.Interfaces;
using AutoMapper;
using API.Exceptions;
using API.DTO;

namespace API.Controllers
{
    [ApiController]
    [Route("api/sttn")]
    public class SttnController : ControllerBase
    {
        private readonly ILogger<Sttn> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SttnController(ILogger<Sttn> logger,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("get-all/{includeDeleted?}")]
        public async Task<ActionResult<IEnumerable<SttnDTO>>> GetAll(bool includeDeleted = false)
        {
            try
            {
                var sttns = await _unitOfWork.STTNs.GetAll(includeDeleted);
                var result = _mapper.Map<IEnumerable<SttnDTO>>(sttns);
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

        [HttpGet("get-by-f-id/{fId:long}")]
        public async Task<ActionResult<SttnDTO>> GetSttnByFId(long fId)
        {
            try
            {
                var result = await _unitOfWork.STTNs.GetByFId(fId);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_mapper.Map<SttnDTO>(result));
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

        [HttpGet("get-by-sysn/{sysn:int}/{includeDeleted?}")]
        public async Task<ActionResult<IEnumerable<SttnDTO>>> GetSttnBySysn(int sysn,
            bool includeDeleted = false)
        {
            try
            {
                var result = await _unitOfWork.STTNs.GetBySysn(sysn, includeDeleted);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(_mapper.Map<IEnumerable<SttnDTO>>(result));
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
        public async Task<ActionResult<SttnDTO>> CreateSttn(SttnDTO sttn)
        {
            try
            {
                if (sttn == null)
                {
                    return BadRequest();
                }
                else
                {
                    var map = _mapper.Map<Sttn>(sttn);

                    var addedSttn = await _unitOfWork.STTNs.Add(map);
                    await _unitOfWork.SaveAsync();

                    var mapAdded = _mapper.Map<SttnDTO>(addedSttn);
                    return CreatedAtAction(nameof(GetSttnByFId), new { fId = mapAdded.F_ID }, mapAdded);
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
        public async Task<ActionResult> UpdateSttn(SttnDTO updated)
        {
            try
            {
                var mappedSttn = _mapper.Map<Sttn>(updated);
                _unitOfWork.STTNs.Update(mappedSttn);
                await _unitOfWork.SaveAsync();

                var refreshedEntity = await _unitOfWork.STTNs.GetByFId(updated.F_ID);
                var refreshedEntityDTO = _mapper.Map<SttnDTO>(refreshedEntity);
                return Ok(refreshedEntityDTO);
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

        [HttpDelete("delete/{fId:long}")]
        public async Task<ActionResult> DeleteSttn(long fId)
        {
            try
            {
                var entity = await _unitOfWork.STTNs.GetByFId(fId);
                if (entity != null)
                {
                    _unitOfWork.STTNs.Remove(entity);
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