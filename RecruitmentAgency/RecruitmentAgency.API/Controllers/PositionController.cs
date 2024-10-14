using Microsoft.AspNetCore.Mvc;
using RecruitmentAgency.API.DTO;
using RecruitmentAgency.API.Services;

namespace RecruitmentAgency.API.Controllers
{
    /// <summary>
    /// Контроллер для управления позициями (должностями).
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PositionController(PositionService service) : ControllerBase
    {
        private readonly PositionService _service = service;

        /// <summary>
        /// Возвращает список всех позиций.
        /// </summary>
        /// <returns>Список всех позиций.</returns>
        /// <response code="200">Список успешно возвращён.</response>
        [HttpGet]
        public ActionResult<IEnumerable<PositionDTO>> Get()
        {
            var positions = _service.GetAll()
                .Select(p => new PositionDTO
                {
                    Id = p.Id,
                    Section = p.Section,
                    PositionName = p.PositionName
                });

            return Ok(positions);
        }

        /// <summary>
        /// Получает информацию о позиции по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор позиции.</param>
        /// <returns>Позиция с указанным идентификатором.</returns>
        /// <response code="200">Позиция найдена и возвращена успешно.</response>
        /// <response code="404">Позиция с указанным идентификатором не найдена.</response>
        [HttpGet("{id}")]
        public ActionResult<PositionDTO> Get(int id)
        {
            var position = _service.GetById(id);
            if (position == null)
            {
                return NotFound();
            }

            var positionDTO = new PositionDTO
            {
                Id = position.Id,
                Section = position.Section,
                PositionName = position.PositionName
            };

            return Ok(positionDTO);
        }

        /// <summary>
        /// Добавляет новую позицию.
        /// </summary>
        /// <param name="newPosition">Информация о новой позиции.</param>
        /// <returns>Результат операции.</returns>
        /// <response code="201">Позиция успешно добавлена.</response>
        /// <response code="400">Позиция не была добавлена.</response>
        [HttpPost]
        public ActionResult Post(PositionCreateDTO newPosition)
        {
            var result = _service.Add(newPosition);
            if (!result)
            {
                return BadRequest("Ошибка при добавлении позиции. Проверьте корректность данных.");
            }

            return CreatedAtAction(nameof(Get), new { id = newPosition.PositionName }, newPosition);
        }

        /// <summary>
        /// Обновляет информацию о существующей позиции.
        /// </summary>
        /// <param name="updatedPosition">Обновлённая информация о позиции.</param>
        /// <returns>Результат операции.</returns>
        /// <response code="200">Позиция успешно обновлена.</response>
        /// <response code="404">Позиция с указанным идентификатором не найдена.</response>
        [HttpPut]
        public ActionResult Put(PositionDTO updatedPosition)
        {
            var result = _service.Update(updatedPosition);
            if (!result)
            {
                return NotFound("Позиция с указанным идентификатором не найдена.");
            }
            return Ok();
        }

        /// <summary>
        /// Удаляет позицию по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор позиции.</param>
        /// <returns>Результат операции удаления.</returns>
        /// <response code="200">Позиция успешно удалена.</response>
        /// <response code="404">Позиция с указанным идентификатором не найдена.</response>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _service.Delete(id);
            if (!result)
            {
                return NotFound("Позиция с указанным идентификатором не найдена.");
            }
            return Ok();
        }
    }
}
