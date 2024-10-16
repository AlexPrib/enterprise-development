using Microsoft.AspNetCore.Mvc;
using RecruitmentAgency.API.DTO;
using RecruitmentAgency.Domain;
using RecruitmentAgency.API.Services;

namespace RecruitmentAgency.API.Controllers
{
    /// <summary>
    /// Контроллер для управления работодателями.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController(EmployerService service) : ControllerBase
    {
        /// <summary>
        /// Возвращает список всех работодателей.
        /// </summary>
        /// <returns>Список всех работодателей.</returns>
        /// <response code="200">Список успешно возвращён.</response>
        [HttpGet]
        public ActionResult<IEnumerable<Employer>> Get()
        {
            return Ok(service.GetAll());
        }

        /// <summary>
        /// Получает информацию о работодателе по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор работодателя.</param>
        /// <returns>Работодатель с указанным идентификатором.</returns>
        /// <response code="200">Работодатель найден и возвращён успешно.</response>
        /// <response code="404">Работодатель с указанным идентификатором не найден.</response>
        [HttpGet("{id}")]
        public ActionResult<Employer> Get(int id)
        {
            var employer = service.GetById(id);
            if (employer == null)
            {
                return NotFound();
            }
            return Ok(employer);
        }

        /// <summary>
        /// Добавляет нового работодателя.
        /// </summary>
        /// <param name="newEmployer">Информация о новом работодателе.</param>
        /// <returns>Результат операции.</returns>
        /// <response code="200">Работодатель успешно добавлен.</response>
        /// <response code="400">Работодатель не был добавлен.</response>
        [HttpPost]
        public ActionResult Post(EmployerCreateDTO newEmployer)
        {
            var result = service.Add(newEmployer);
            if (!result)
            {
                return BadRequest("Ошибка при добавлении работодателя. Проверьте корректность данных.");
            }
            return Ok();
        }

        /// <summary>
        /// Обновляет информацию о существующем работодателе.
        /// </summary>
        /// /// <param name="id">Идентификатор работодателя</param>
        /// <param name="updatedEmployer">Обновлённая информация о работодателе.</param>
        /// <returns>Результат операции.</returns>
        /// <response code="200">Работодатель успешно обновлён.</response>
        /// <response code="404">Работодатель с указанным идентификатором не найден.</response>
        [HttpPut]
        public ActionResult Put(int id, EmployerCreateDTO updatedEmployer)
        {
            var result = service.Update(id, updatedEmployer);
            if (!result)
            {
                return NotFound("Работодатель с указанным идентификатором не найден.");
            }
            return Ok();
        }

        /// <summary>
        /// Удаляет работодателя по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор работодателя.</param>
        /// <returns>Результат операции удаления.</returns>
        /// <response code="200">Работодатель успешно удалён.</response>
        /// <response code="404">Работодатель с указанным идентификатором не найден.</response>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = service.Delete(id);
            if (!result)
            {
                return NotFound("Работодатель с указанным идентификатором не найден.");
            }
            return Ok();
        }
    }
}

