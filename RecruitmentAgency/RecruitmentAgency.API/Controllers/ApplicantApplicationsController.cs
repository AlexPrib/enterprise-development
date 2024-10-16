using Microsoft.AspNetCore.Mvc;
using RecruitmentAgency.API.DTO;
using RecruitmentAgency.API.Services;
using RecruitmentAgency.Domain;

namespace RecruitmentAgency.API.Controllers;

/// <summary>
/// Контроллер для управления заявками соискателей.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ApplicantApplicationsController(ApplicantApplicationService service) : ControllerBase
{
    /// <summary>
    /// Получает все заявки соискателей.
    /// </summary>
    /// <returns>Список всех заявок соискателей.</returns>
    /// <response code="200">Заявки успешно получены.</response>
    [HttpGet]
    public ActionResult<IEnumerable<ApplicantApplication>> Get()
    {
        return Ok(service.GetAll());
    }

    /// <summary>
    /// Получает заявку соискателя по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор заявки.</param>
    /// <returns>Заявка соискателя.</returns>
    /// <response code="200">Заявка успешно найдена.</response>
    /// <response code="404">Заявка с указанным идентификатором не найдена.</response>
    [HttpGet("{id}")]
    public ActionResult<ApplicantApplication> Get(int id)
    {
        var applicantApplication = service.GetById(id);
        if (applicantApplication == null)
        {
            return NotFound();
        }
        return Ok(applicantApplication);
    }

    /// <summary>
    /// Создает новую заявку соискателя.
    /// </summary>
    /// <param name="newApplicantApplication">Данные для создания новой заявки.</param>
    /// <returns>Результат операции.</returns>
    /// <response code="200">Заявка успешно создана.</response>
    /// <response code="400">Данные заявки недействительны.</response>
    [HttpPost]
    public ActionResult Post(ApplicantApplicationCreateDTO newApplicantApplication)
    {
        var result = service.Add(newApplicantApplication);
        if (!result)
        {
            return BadRequest("Не удалось создать заявку. Проверьте данные.");
        }

        return Ok();
    }

    /// <summary>
    /// Обновляет информацию о существующей заявке.
    /// </summary>
    /// <param name="id">Идентификатор заявки соискателя.</param>
    /// <param name="updatedApplicantApplication">Обновлённая информация о заявке.</param>
    /// <returns>Результат операции.</returns>
    /// <response code="200">Заявка успешно обновлена.</response>
    /// <response code="404">Заявка с указанным идентификатором не найдена.</response>
    [HttpPut]
    public ActionResult Put(int id, ApplicantApplicationCreateDTO updatedApplicantApplication)
    {
        var result = service.Update(id, updatedApplicantApplication);
        if (!result)
        {
            return NotFound("Заявка не найдена.");
        }
        return Ok();
    }

    /// <summary>
    /// Удаляет заявку соискателя по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор заявки, которую необходимо удалить.</param>
    /// <returns>Результат операции удаления.</returns>
    /// <response code="204">Заявка успешно удалена.</response>
    /// <response code="404">Заявка с указанным идентификатором не найдена.</response>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var result = service.Delete(id);
        if (!result)
        {
            return NotFound("Заявка не найдена.");
        }

        return NoContent();
    }
}

