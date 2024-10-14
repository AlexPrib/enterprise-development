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
public class ApplicantApplicationsController(ApplicantApplicationService applicantApplicationService) : ControllerBase
{
    private readonly ApplicantApplicationService _applicantApplicationService = applicantApplicationService;

    /// <summary>
    /// Получает все заявки соискателей.
    /// </summary>
    /// <returns>Список всех заявок соискателей.</returns>
    /// <response code="200">Заявки успешно получены.</response>
    [HttpGet]
    public ActionResult<IEnumerable<ApplicantApplication>> Get()
    {
        var applicantApplications = _applicantApplicationService.GetAll();
        return Ok(applicantApplications);
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
        var applicantApplication = _applicantApplicationService.GetById(id);
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
    /// <response code="201">Заявка успешно создана.</response>
    /// <response code="400">Данные заявки недействительны.</response>
    [HttpPost]
    public ActionResult Post(ApplicantApplicationCreateDTO newApplicantApplication)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = _applicantApplicationService.Add(newApplicantApplication);
        if (!result)
        {
            return BadRequest("Не удалось создать заявку. Проверьте данные.");
        }

        return CreatedAtAction(nameof(Get), new { id = newApplicantApplication.ApplicantId }, newApplicantApplication);
    }

    /// <summary>
    /// Обновляет информацию о существующей заявке.
    /// </summary>
    /// <param name="id">Идентификатор заявки, которую необходимо обновить.</param>
    /// <param name="updatedApplicantApplication">Обновлённая информация о заявке.</param>
    /// <returns>Результат операции.</returns>
    /// <response code="204">Заявка успешно обновлена.</response>
    /// <response code="400">ID не совпадают или данные недействительны.</response>
    /// <response code="404">Заявка с указанным идентификатором не найдена.</response>
    [HttpPut("{id}")]
    public ActionResult Put(int id, ApplicantApplicantDTO updatedApplicantApplication)
    {
        if (id != updatedApplicantApplication.Id)
        {
            return BadRequest("ID не совпадают.");
        }

        var result = _applicantApplicationService.Update(updatedApplicantApplication);
        if (!result)
        {
            return NotFound("Заявка не найдена.");
        }

        return NoContent();
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
        var result = _applicantApplicationService.Delete(id);
        if (!result)
        {
            return NotFound("Заявка не найдена.");
        }

        return NoContent();
    }
}

