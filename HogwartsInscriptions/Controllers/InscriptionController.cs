using HogwartsInscriptionsCore.Interfaces;
using HogwartsInscriptionsCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogwartsInscriptions.Controllers
{
    [ApiController]
    public class InscriptionController : ControllerBase
    {
        private readonly ILogger<InscriptionController> _logger;
        private readonly IInscriptions _inscriptions;

        public InscriptionController(ILogger<InscriptionController> logger, IInscriptions inscriptions)
        {
            _inscriptions = inscriptions;
            _logger = logger;
        }

        [HttpGet]
        [Route("api/inscription/get")]
        public IEnumerable<Inscription> Get()
        {
            IEnumerable<Inscription> inscriptions = _inscriptions.GetInscriptions();
            if (inscriptions == null)
                return default;
            else
                return inscriptions;
        }

        [HttpPost]
        [Route("api/inscription/create")]
        public string Create([FromBody] Inscription inscriptionDto)
        {
            if (inscriptionDto == null)
            {
                return ("Error al crear la isncripción, objeto nulo");
            }

            if (!_inscriptions.Create(inscriptionDto))
            {
                return ($"Ocurrió un error al crear la inscripción correspondiente a: {inscriptionDto.Name} {inscriptionDto.LastName}");
            }
            else
            {
                return ("Inscripción realizada con éxito");
            }
        }

        [HttpPost]
        [Route("api/inscription/update")]
        public string Update([FromBody] Inscription inscriptionDto)
        {
            if (inscriptionDto == null)
            {
                return ("Error al crear la isncripción, objeto nulo");
            }

            if (!_inscriptions.Update(inscriptionDto))
            {
                return ($"Ocurrió un error al actualizar la inscripción correspondiente a: {inscriptionDto.Name} {inscriptionDto.LastName}");
            }
            else
            {
                return ("Inscripción actualizada con éxito");
            }
        }

        [HttpGet]
        [Route("api/inscription/search")]
        public Inscription Search(int id)
        {
            var inscription = _inscriptions.GetInscription(id);

            if (inscription == null)
            {
                Inscription inscriptionD = new Inscription();
                return inscriptionD;
            }
            else
            {
                return inscription;
            }
        }

        [HttpPost]
        [Route("api/inscription/delete")]
        public string delete(int id)
        {
            if (!_inscriptions.DeleteInscription(id))
            {
                return ($"Ocurrió un error al eliminar la solicitud de inscripción");
            }
            else
            {
                return ("Inscripción eliminada con éxito");
            }
        }

        [HttpPost]
        [Route("api/inscription/changestate")]
        public string ChangeState(int id, int stateId)
        {
            if (!_inscriptions.ChangeState(id, stateId))
            {
                return ($"Ocurrió un error al cambiar el estado la solicitud de inscripción");
            }
            else
            {
                return ("Inscripción actualizada con éxito");
            }
        }



    }
}
