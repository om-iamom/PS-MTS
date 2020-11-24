using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PS.MedicalTrackingSystem.API.Business.Repositories;
using PS.MedicalTrackingSystem.API.Domain.Entities;

namespace PS.MedicalTrackingSystem.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineBusiness _medicineBusiness;
        private readonly ILogger<MedicineController> _logger;

        public MedicineController(IMedicineBusiness medicineBusiness, ILogger<MedicineController> logger)
        {
            _medicineBusiness = medicineBusiness ?? throw new ArgumentNullException(nameof(medicineBusiness));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Medicine>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Medicine>>> GetAllMedicines()
        {
            var medicines = await _medicineBusiness.GetAllMedicines();
            return Ok(medicines);
        }

        
        [HttpGet("{id:length(24)}", Name = "GetMedicine")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Medicine>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Medicine>> GetMedicineDetails(string id)
        {
            var medicine = await _medicineBusiness.GetMedicineDetails(id);
            if (medicine == null)
            {
                _logger.LogError($"{id} not found");
                return NotFound();
            }
            return Ok(medicine);
        }

        [Route("[action]/{name}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Medicine>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Medicine>> GetMedicineByName(string name)
        {
            var medicine = await _medicineBusiness.GetMedicineByName(name);
            if (medicine == null)
            {
                _logger.LogError($"No product found with name: {name} ");
                return NotFound();
            }
            return Ok(medicine);
        }

        [HttpPost]
        public async Task<ActionResult<Medicine>> CreateProduct([FromBody] Medicine medicine)
        {
            await _medicineBusiness.Create(medicine);
            return CreatedAtRoute("GetMedicine", new { id = medicine.Id }, medicine);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateProduct([FromBody] Medicine medicine)
        {
            var isUpdateSuccessfull = await _medicineBusiness.Update(medicine);

            return Ok(isUpdateSuccessfull);
        }


    }
}
