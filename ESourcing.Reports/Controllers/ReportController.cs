using ESourcing.Reports.Entities;
using ESourcing.Reports.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ESourcing.Reports.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        #region Variables

        private readonly IReportRepository _reportRepository;
        private readonly ILogger<ReportController> _logger;

        #endregion

        #region Contructor

        public ReportController(IReportRepository reportRepository, ILogger<ReportController> logger)
        {
            _reportRepository = reportRepository;
            _logger = logger;
        }

        #endregion

        #region Crud_Actions

        [HttpGet]
        [ProducesResponseType(typeof(Report), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Report>>> GetReports()
        {
            var reports = await _reportRepository.GetReports();
            return Ok(reports);
        }

        [HttpGet("{id:length(24)}", Name = "GetReport")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Report), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Report>> GetReport(string id)
        {
            var report = await _reportRepository.GetReport(id);

            if (report == null)
            {
                _logger.LogError($"{id} sahip bir report bulunamadı.");
                return NotFound();
            }
            return Ok(report);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Report), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<Report>> CretaeReport([FromBody] Report report)
        {
            await _reportRepository.Create(report);
            return CreatedAtRoute("GetReport", new { id = report.Id }, report);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Report), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> UpdateReport([FromBody] Report report)
        {
            return Ok(await _reportRepository.Update(report));

        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType(typeof(Report), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> DeleteReportById(string id)
        {
            return Ok(await _reportRepository.Delete(id));
        }

        #endregion
    }
}
