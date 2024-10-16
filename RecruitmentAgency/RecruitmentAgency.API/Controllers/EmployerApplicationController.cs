using Microsoft.AspNetCore.Mvc;
using RecruitmentAgency.API.DTO;
using RecruitmentAgency.API.Services;
using RecruitmentAgency.Domain;

namespace RecruitmentAgency.API.Controllers
{
    /// <summary>
    /// Контроллер для управления заявками работодателей.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerApplicationController(EmployerApplicationService service) : ControllerBase
    {
        /// <summary>
        /// Возвращает список всех заявок работодателей.
        /// </summary>
        /// <returns>Список всех заявок работодателей.</returns>
        /// <response code="200">Список успешно возвращён.</response>
        [HttpGet]
        public ActionResult<IEnumerable<EmployerApplication>> Get()
        {
            return Ok(service.GetAll());
        }

        /// <summary>
        /// Получает информацию о заявке работодателя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор заявки.</param>
        /// <returns>Заявка работодателя с указанным идентификатором.</returns>
        /// <response code="200">Заявка найдена и возвращена успешно.</response>
        /// <response code="404">Заявка с указанным идентификатором не найдена.</response>
        [HttpGet("{id}")]
        public ActionResult<EmployerApplication> Get(int id)
        {
            var employerApplication = service.GetById(id);
            if (employerApplication == null)
            {
                return NotFound();
            }
            return Ok(employerApplication);
        }

        /// <summary>
        /// Добавляет новую заявку работодателя.
        /// </summary>
        /// <param name="newEmployerApplication">Информация о новой заявке.</param>
        /// <returns>Результат операции.</returns>
        /// <response code="200">Заявка успешно добавлена.</response>
        /// <response code="400">Заявка не была добавлена.</response>
        [HttpPost]
        public ActionResult Post(EmployerApplicationCreateDTO newEmployerApplication)
        {
            var result = service.Add(newEmployerApplication);
            if (!result)
            {
                return BadRequest("Ошибка при добавлении заявки. Проверьте корректность данных.");
            }

            return Ok();
        }

        /// <summary>
        /// Обновляет информацию о существующей заявке работодателя.
        /// </summary>
        /// <param name="id">Идентификатор заявки работодателя</param>
        /// <param name="updatedEmployerApplication">Обновлённая информация о заявке.</param>
        /// <returns>Результат операции.</returns>
        /// <response code="200">Заявка успешно обновлена.</response>
        /// <response code="404">Заявка с указанным идентификатором не найдена.</response>
        [HttpPut]
        public ActionResult Put(int id, EmployerApplicationCreateDTO updatedEmployerApplication)
        {
            var result = service.Update(id, updatedEmployerApplication);
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
        /// <response code="204">Заявка успешно удалена.</response>
        /// <response code="404">Заявка с указанным идентификатором не найдена.</response>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = service.Delete(id);
            if (!result)
            {
                return NotFound("Заявка с указанным идентификатором не найдена.");
            }
            return NoContent();
        }
    }
}

