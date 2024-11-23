using Microsoft.AspNetCore.Mvc;
using RecruitmentAgency.API.DTO;
using RecruitmentAgency.API.Services;
using RecruitmentAgency.Domain.Entity;

namespace RecruitmentAgency.API.Controllers
{
    /// <summary>
    /// Контроллер для выполнения запросов к данным о заявках и работодателях.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController(IQueryService service) : ControllerBase
    {

        /// <summary>
        /// Получает всех соискателей для указанной позиции, отсортированных по полному имени.
        /// </summary>
        /// <param name="positionName">Название позиции.</param>
        /// <returns>Список соискателей.</returns>
        /// <response code="200">Список соискателей успешно возвращён.</response>
        [HttpGet("applicants/position/{positionName}")]
        public ActionResult<IEnumerable<ApplicantDTO>> GetAllApplicantsByPositionOrderedByFullName(string positionName)
        {
            return Ok(service.GetAllApplicantsByPositionOrderedByFullName(positionName));
        }

        /// <summary>
        /// Получает всех соискателей в диапазоне дат подачи заявок.
        /// </summary>
        /// <param name="startDate">Дата начала диапазона.</param>
        /// <param name="endDate">Дата конца диапазона.</param>
        /// <returns>Список соискателей.</returns>
        /// <response code="200">Список соискателей успешно возвращён.</response>
        [HttpGet("applicants/date-range")]
        public ActionResult<IEnumerable<ApplicantDTO>> GetAllApplicantsBySubmissionDateRange(DateTime startDate, DateTime endDate)
        {
            return Ok(service.GetAllApplicantsBySubmissionDateRange(startDate, endDate));
        }

        /// <summary>
        /// Получает соискателей для заявки работодателя по идентификатору заявки.
        /// </summary>
        /// <param name="employerApplicationId">Идентификатор заявки работодателя.</param>
        /// <returns>Список соискателей для заявки работодателя.</returns>
        /// <response code="200">Список соискателей успешно возвращён.</response>
        [HttpGet("applicants/employer-application/{employerApplicationId}")]
        public ActionResult<IEnumerable<ApplicantsForEmployerApplicationDTO>> GetApplicantsForEmployerApplication(int employerApplicationId)
        {;
            return Ok(service.GetApplicantsForEmployerApplication(employerApplicationId));
        }

        /// <summary>
        /// Получает статистику заявок по секциям и позициям.
        /// </summary>
        /// <returns>Список статистики по заявкам.</returns>
        /// <response code="200">Статистика успешно возвращена.</response>
        [HttpGet("applications/statistics")]
        public ActionResult<IEnumerable<ApplicationStatisticsDTO>> GetApplicationCountBySectionAndPositionAll()
        {
            return Ok(service.GetApplicationCountBySectionAndPositionAll());
        }

        /// <summary>
        /// Получает топ работодателей по количеству заявок.
        /// </summary>
        /// <returns>Список топ работодателей.</returns>
        /// <response code="200">Список работодателей успешно возвращён.</response>
        [HttpGet("top-employers")]
        public ActionResult<List<TopEmployerDTO>> GetTopEmployersByApplications()
        {
            return Ok(service.GetTopEmployersByApplications());
        }

        /// <summary>
        /// Получает работодателей с максимальными зарплатами по заявкам.
        /// </summary>
        /// <returns>Список работодателей с максимальными зарплатами.</returns>
        /// <response code="400">Список работодателей отсутствует.</response>
        /// <response code="200">Список работодателей успешно возвращён.</response>
        [HttpGet("employers/max-salary")]
        public ActionResult<List<EmployerDTO>> GetEmployersWithMaxSalaryApplications()
        {
            return Ok(service.GetEmployersWithMaxSalaryApplications());
        }
    }
}
