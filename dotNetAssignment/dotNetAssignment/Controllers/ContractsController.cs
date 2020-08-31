using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetAssignment.DataEntities;
using dotNetAssignment.Models;
using dotNetAssignment.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotNetAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : BaseController
    {
        private readonly IContractsService _contractsService;
        public ContractsController(IContractsService contractsService)
        {
            this._contractsService = contractsService;
        }

        [HttpGet("GetContracts")]
        public ActionResult GetContracts()
        {
            var contracts = _contractsService.GetContracts();

            if(contracts != null)
            {
                return Ok(GetResponse(ResponseType.OBJECT, ResponseStatusCode.SUCCESS, contracts));
            }
            else
            {
                return Ok(GetResponse(ResponseType.FAIL, ResponseStatusCode.FAIL, GetError(ErrorCodes.dataNotFound, "No contracts found", "Please create a new insurance contract.")));
            }
        }

        [HttpGet("GetContractsView")]
        public ActionResult GetContractsView()
        {
            var contracts = _contractsService.GetContractsView();

            if (contracts != null)
            {
                return Ok(GetResponse(ResponseType.OBJECT, ResponseStatusCode.SUCCESS, contracts));
            }
            else
            {
                return Ok(GetResponse(ResponseType.FAIL, ResponseStatusCode.FAIL, GetError(ErrorCodes.dataNotFound, "No contracts found", "Please create a new insurance contract.")));
            }
        }

        [HttpPost("AddNewContract")]
        public ActionResult AddNewContract(CustomerDto customerDto)
        {
            if (customerDto != null)
            {
                try
                {
                    _contractsService.InsertContract(customerDto);
                }
                catch (Exception e)
                {
                    return Ok(GetResponse(ResponseType.FAIL, ResponseStatusCode.FAIL, GetError(ErrorCodes.dataNotFound, "Failed", e.Message)));
                }
                return Ok(GetResponse(ResponseType.ACK, ResponseStatusCode.SUCCESS));
            }
            else
            {
                return BadRequest(GetResponse(ResponseType.ERROR, ResponseStatusCode.ERROR, GetError(ErrorCodes.invalidData, "Invalid input", "Please enter proper customer details")));
            }
        }

        [HttpPut("UpdateContract")]
        public ActionResult UpdateContract(Contracts contract)
        {
            if (contract != null)
            {

                try
                {
                    _contractsService.UpdateContract(contract);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return Ok(GetResponse(ResponseType.FAIL, ResponseStatusCode.FAIL, GetError(ErrorCodes.dataNotFound, "Failed", e.Message)));
                }

                return Ok(GetResponse(ResponseType.ACK, ResponseStatusCode.SUCCESS));
            }
            else
            {
                return BadRequest(GetResponse(ResponseType.ERROR, ResponseStatusCode.ERROR, GetError(ErrorCodes.invalidData, "Invalid input", "Please enter proper contract details")));
            }
        }

        [HttpDelete("DeleteContract")]
        public ActionResult DeleteContract(int id)
        {
            if (id > 0)
            {
                try
                {
                    _contractsService.DeleteContract(id);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return Ok(GetResponse(ResponseType.FAIL, ResponseStatusCode.FAIL, GetError(ErrorCodes.dataNotFound, "Failed", "Error occurred while deleting the contract")));
                }

                return Ok(GetResponse(ResponseType.ACK, ResponseStatusCode.SUCCESS));
            }
            else
            {
                return BadRequest(GetResponse(ResponseType.ERROR, ResponseStatusCode.ERROR, GetError(ErrorCodes.invalidData, "Invalid input", "Please enter proper contract id")));
            }
        }

    }
}
