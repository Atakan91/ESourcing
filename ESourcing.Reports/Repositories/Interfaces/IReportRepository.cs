using ESourcing.Reports.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESourcing.Reports.Repositories.Interfaces
{
    public interface IReportRepository
    {
        Task<IEnumerable<Report>> GetReports();
        Task<Report> GetReport(string id);
        Task Create(Report report);
        Task<bool> Update(Report report);
        Task<bool> Delete(string id);
    }
}
