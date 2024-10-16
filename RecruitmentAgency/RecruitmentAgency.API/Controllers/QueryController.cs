using Microsoft.AspNetCore.Mvc;
using RecruitmentAgency.API.DTO;
using RecruitmentAgency.API.Services;
using RecruitmentAgency.Domain;

namespace RecruitmentAgency.API.Controllers
{
    /// <summary>
    /// Контроллер для выполнения запросов к данным о заявках и работодателях.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController(QueryService queryService) : ControllerBase
    {
        private readonly QueryService _queryService = queryService;

        /// <summary>
        /// Получает всех соискателей для указанной позиции, отсортированных по полному имени.
        /// </summary>
        /// <param name="positionName">Название позиции.</param>
        /// <returns>Список соискателей.</returns>
        /// <response code="200">Список соискателей успешно возвращён.</response>
        [HttpGet("applicants/position/{positionName}")]
        public ActionResult<List<Applicant>> GetAllApplicantsByPosition(string positionName)
        {
            var applicants = _queryService.GetAllApplicantsByPositionOrderedByFullName(positionName);
            return Ok(applicants);
        }

        /// <summary>
        /// Получает всех соискателей в диапазоне дат подачи заявок.
        /// </summary>
        /// <param name="startDate">Дата начала диапазона.</param>
        /// <param name="endDate">Дата конца диапазона.</param>
        /// <returns>Список соискателей.</returns>
        /// <response code="200">Список соискателей успешно возвращён.</response>
        [HttpGet("applicants/date-range")]
        public ActionResult<List<Applicant>> GetAllApplicantsBySubmissionDateRange(DateTime startDate, DateTime endDate)
        {
            var applicants = _queryService.GetAllApplicantsBySubmissionDateRange(startDate, endDate);
            return Ok(applicants);
        }

        /// <summary>
        /// Получает соискателей для заявки работодателя по идентификатору заявки.
        /// </summary>
        /// <param name="employerApplicationId">Идентификатор заявки работодателя.</param>
        /// <returns>Список соискателей для заявки работодателя.</returns>
        /// <response code="200">Список соискателей успешно возвращён.</response>
        [HttpGet("applicants/employer-application/{employerApplicationId}")]
        public ActionResult<List<ApplicantsForEmployerApplicationDTO>> GetApplicantsForEmployerApplication(int employerApplicationId)
        {
            var applicants = _queryService.GetApplicantsForEmployerApplication(employerApplicationId);
            return Ok(applicants);
        }

        /// <summary>
        /// Получает статистику заявок по секциям и позициям.
        /// </summary>
        /// <returns>Список статистики по заявкам.</returns>
        /// <response code="200">Статистика успешно возвращена.</response>
        [HttpGet("applications/statistics")]
        public ActionResult<List<ApplicationStatisticsDTO>> GetApplicationCountBySectionAndPositionAll()
        {
            var statistics = _queryService.GetApplicationCountBySectionAndPositionAll();
            return Ok(statistics);
        }

        /// <summary>
        /// Получает топ работодателей по количеству заявок.
        /// </summary>
        /// <returns>Список топ работодателей.</returns>
        /// <response code="200">Список работодателей успешно возвращён.</response>
        [HttpGet("top-employers")]
        public ActionResult<List<TopEmployerDTO>> GetTopEmployersByApplications()
        {
            var topEmployers = _queryService.GetTopEmployersByApplications();
            return Ok(topEmployers);
        }

        /// <summary>
        /// Получает работодателей с максимальными зарплатами по заявкам.
        /// </summary>
        /// <returns>Список работодателей с максимальными зарплатами.</returns>
        /// <response code="400">Список работодателей отсутствует.</response>
        /// <response code="200">Список работодателей успешно возвращён.</response>
        [HttpGet("employers/max-salary")]
        public ActionResult<List<Employer>> GetEmployersWithMaxSalaryApplications()
        {
            var employers = _queryService.GetEmployersWithMaxSalaryApplications();
            if (employers == null)
            {
                return BadRequest("Нет работодателей");
            }
            return Ok(employers);
        }
    }
}
