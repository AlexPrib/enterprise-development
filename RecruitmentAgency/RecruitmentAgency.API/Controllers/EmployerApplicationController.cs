using Microsoft.AspNetCore.Mvc;
using RecruitmentAgency.API.DTO;
using RecruitmentAgency.Domain;
using RecruitmentAgency.API.Services;

namespace RecruitmentAgency.API.Controllers
{
    /// <summary>
    /// Контроллер для управления заявками работодателей.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerApplicationController(EmployerApplicationService service) : ControllerBase
    {
        private readonly EmployerApplicationService _service = service;

        /// <summary>
        /// Возвращает список всех заявок работодателей.
        /// </summary>
        /// <returns>Список всех заявок работодателей.</returns>
        /// <response code="200">Список успешно возвращён.</response>
        [HttpGet]
        public ActionResult<IEnumerable<EmployerApplicationDTO>> Get()
        {
            var employerApplications = _service.GetAll()
                .Select(e => new EmployerApplicationDTO
                {
                    Id = e.Id,
                    EmployerId = e.Employer.Id,
                    PositionId = e.Position.Id,
                    SubmissionDate = e.SubmissionDate,
                    Requirements = e.Requirements,
                    OfferedSalary = e.OfferedSalary
                });
            return Ok(employerApplications);
        }

        /// <summary>
        /// Получает информацию о заявке работодателя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор заявки.</param>
        /// <returns>Заявка работодателя с указанным идентификатором.</returns>
        /// <response code="200">Заявка найдена и возвращена успешно.</response>
        /// <response code="404">Заявка с указанным идентификатором не найдена.</response>
        [HttpGet("{id}")]
        public ActionResult<EmployerApplicationDTO> Get(int id)
        {
            var employerApplication = _service.GetById(id);
            if (employerApplication == null)
            {
                return NotFound();
            }

            var employerApplicationDTO = new EmployerApplicationDTO
            {
                Id = employerApplication.Id,
                EmployerId = employerApplication.Employer.Id,
                PositionId = employerApplication.Position.Id,
                SubmissionDate = employerApplication.SubmissionDate,
                Requirements = employerApplication.Requirements,
                OfferedSalary = employerApplication.OfferedSalary
            };

            return Ok(employerApplicationDTO);
        }

        /// <summary>
        /// Добавляет новую заявку работодателя.
        /// </summary>
        /// <param name="newEmployerApplication">Информация о новой заявке.</param>
        /// <returns>Результат операции.</returns>
        /// <response code="201">Заявка успешно добавлена.</response>
        /// <response code="400">Заявка не была добавлена.</response>
        [HttpPost]
        public ActionResult Post(EmployerApplicationCreateDTO newEmployerApplication)
        {
            var result = _service.Add(newEmployerApplication);
            if (!result)
            {
                return BadRequest("Ошибка при добавлении заявки. Проверьте корректность данных.");
            }

            return CreatedAtAction(nameof(Get), new { id = newEmployerApplication.EmployerId }, newEmployerApplication);
        }

        /// <summary>
        /// Обновляет информацию о существующей заявке работодателя.
        /// </summary>
        /// <param name="updatedEmployerApplication">Обновлённая информация о заявке.</param>
        /// <returns>Результат операции.</returns>
        /// <response code="200">Заявка успешно обновлена.</response>
        /// <response code="404">Заявка с указанным идентификатором не найдена.</response>
        [HttpPut]
        public ActionResult Put(EmployerApplicationDTO updatedEmployerApplication)
        {
            var result = _service.Update(updatedEmployerApplication);
            if (!result)
            {
                return NotFound("Заявка с указанным идентификатором не найдена.");
            }
            return Ok();
        }

        /// <summary>
        /// Удаляет заявку работодателя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор заявки.</param>
        /// <returns>Результат операции удаления.</returns>
        /// <response code="200">Заявка успешно удалена.</response>
        /// <response code="404">Заявка с указанным идентификатором не найдена.</response>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            if (!result)
            {
                return NotFound("Заявка с указанным идентификатором не найдена.");
            }
            return Ok();
        }
    }
}

