using Microsoft.AspNetCore.Mvc;
using RecruitmentAgency.API.DTO;
using RecruitmentAgency.API.Services;
using RecruitmentAgency.Domain;

namespace RecruitmentAgency.API.Controllers
{
    /// <summary>
    /// Контроллер для управления соискателями.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantsController(ApplicantsService service) : ControllerBase
    {
        /// <summary>
        /// Получает список всех соискателей.
        /// </summary>
        /// <returns>Список всех соискателей.</returns>
        /// <response code="200">Соискатели успешно получены.</response>
        [HttpGet]
        public ActionResult<IEnumerable<Applicant>> Get()
        {
            return Ok(service.GetAll());
        }

        /// <summary>
        /// Получает информацию о соискателе по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор соискателя.</param>
        /// <returns>Соискатель с указанным идентификатором.</returns>
        /// <response code="200">Соискатель успешно найден.</response>
        /// <response code="404">Соискатель с указанным идентификатором не найден.</response>
        [HttpGet("{id}")]
        public ActionResult<Applicant> Get(int id)
        {
            var applicant = service.GetById(id);
            if (applicant == null)
            {
                return NotFound("Соискатель не найден.");
            }
            return Ok(applicant);
        }

        /// <summary>
        /// Добавляет нового соискателя.
        /// </summary>
        /// <param name="newApplicant">Данные для создания нового соискателя.</param>
        /// <returns>Результат операции.</returns>
        /// <response code="201">Соискатель успешно создан.</response>
        /// <response code="404">Данные соискателя недействительны.</response>
        [HttpPost]
        public ActionResult Post(ApplicantCreateDTO newApplicant)
        {
            var result = service.Add(newApplicant);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }

        /// <summary>
        /// Обновляет информацию о существующем соискателе.
        /// </summary>
        /// <param name="id">Идентификатор соискателя, которого нужно обновить.</param>
        /// <param name="updatedApplicant">Обновлённая информация о соискателе.</param>
        /// <returns>Результат операции.</returns>
        /// <response code="200">Соискатель успешно обновлён.</response>
        /// <response code="404">Соискатель с указанным идентификатором не найден.</response>
        [HttpPut("{id}")]
        public ActionResult Put(int id, ApplicantCreateDTO updatedApplicant)
        {
            var result = service.Update(id, updatedApplicant);
            if (!result)
            {
                return NotFound("Соискатель не найден.");
            }
            return Ok();
        }

        /// <summary>
        /// Удаляет соискателя по указанному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор соискателя, которого нужно удалить.</param>
        /// <returns>Результат операции удаления.</returns>
        /// <response code="204">Соискатель успешно удалён.</response>
        /// <response code="404">Соискатель с указанным идентификатором не найден.</response>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = service.Delete(id);
            if (!result)
            {
                return NotFound("Соискатель не найден.");
            }

            return NoContent();
        }
    }
}
