using Microsoft.AspNetCore.Mvc;
using RecruitmentAgency.API.DTO;
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
        private readonly EmployerService _service = service;

        /// <summary>
        /// Возвращает список всех работодателей.
        /// </summary>
        /// <returns>Список всех работодателей.</returns>
        /// <response code="200">Список успешно возвращён.</response>
        [HttpGet]
        public ActionResult<IEnumerable<EmployerDTO>> Get()
        {
            var employers = _service.GetAll()
                .Select(e => new EmployerDTO
                {
                    Id = e.Id,
                    CompanyName = e.CompanyName,
                    ContactPersonName = e.ContactPersonName,
                    CompanyNumber = e.CompanyNumber
                });

            return Ok(employers);
        }

        /// <summary>
        /// Получает информацию о работодателе по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор работодателя.</param>
        /// <returns>Работодатель с указанным идентификатором.</returns>
        /// <response code="200">Работодатель найден и возвращён успешно.</response>
        /// <response code="404">Работодатель с указанным идентификатором не найден.</response>
        [HttpGet("{id}")]
        public ActionResult<EmployerDTO> Get(int id)
        {
            var employer = _service.GetById(id);
            if (employer == null)
            {
                return NotFound();
            }

            var employerDTO = new EmployerDTO
            {
                Id = employer.Id,
                CompanyName = employer.CompanyName,
                ContactPersonName = employer.ContactPersonName,
                CompanyNumber = employer.CompanyNumber
            };

            return Ok(employerDTO);
        }

        /// <summary>
        /// Добавляет нового работодателя.
        /// </summary>
        /// <param name="newEmployer">Информация о новом работодателе.</param>
        /// <returns>Результат операции.</returns>
        /// <response code="201">Работодатель успешно добавлен.</response>
        /// <response code="400">Работодатель не был добавлен.</response>
        [HttpPost]
        public ActionResult Post(EmployerCreateDTO newEmployer)
        {
            var result = _service.Add(newEmployer);
            if (!result)
            {
                return BadRequest("Ошибка при добавлении работодателя. Проверьте корректность данных.");
            }

            return CreatedAtAction(nameof(Get), new { id = newEmployer.CompanyName }, newEmployer);
        }

        /// <summary>
        /// Обновляет информацию о существующем работодателе.
        /// </summary>
        /// <param name="updatedEmployer">Обновлённая информация о работодателе.</param>
        /// <returns>Результат операции.</returns>
        /// <response code="200">Работодатель успешно обновлён.</response>
        /// <response code="404">Работодатель с указанным идентификатором не найден.</response>
        [HttpPut]
        public ActionResult Put(EmployerDTO updatedEmployer)
        {
            var result = _service.Update(updatedEmployer);
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
            var result = _service.Delete(id);
            if (!result)
            {
                return NotFound("Работодатель с указанным идентификатором не найден.");
            }
            return Ok();
        }
    }
}

