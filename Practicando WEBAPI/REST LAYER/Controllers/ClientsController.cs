using Microsoft.AspNetCore.Mvc;
using Practicando_WEBAPI.Models;
using Practicando_WEBAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Practicando_WEBAPI.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Practicando_WEBAPI.Controllers
{
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private IClientService _clientService;
        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ClientModel>> GetClients()
        {
            try
            {
                return Ok(_clientService.GetClients());
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }

        }
        [HttpGet("{clientId:int}", Name="GetClient")]
        public ActionResult<ClientModel> GetClient(int clientId)
        {
            try
            {
                return Ok(_clientService.GetClient(clientId));
            }
            catch(NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
        [HttpPost]
        public ActionResult<ClientModel> CreateClient([FromBody] ClientModel clientModel)
        {
            try
            {
               
                var url = HttpContext.Request.Host;
                var createdClient = _clientService.CreateClient(clientModel);
                return CreatedAtRoute("GetClient",new { clientId=createdClient.Id},createdClient);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
       
       [HttpDelete("{clientId:int}")]
       public ActionResult<bool> DeleteClient(int clientId)
        {
            try
            {
                return Ok(_clientService.DeleteClient(clientId));
            }
            catch (NotFoundException ex)
            {

                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
        [HttpPut("{clientId:int}")]
        public ActionResult<ClientModel> UpdateClient(int clientId, [FromBody] ClientModel clientModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    foreach (var pair in ModelState)
                    {
                        if (pair.Key == nameof(clientModel.Name) && pair.Value.Errors.Count > 0)
                        {
                            return BadRequest(pair.Value.Errors);
                        }
                    }
                }
                return _clientService.UpdateClient(clientId, clientModel);
            }

            catch (NotFoundException ex)
            {

                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, $"Something happend: {ex.Message}");
            }
        }
       
    }
}
