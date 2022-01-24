using ESourcing.Reports.Data.Interfaces;
using ESourcing.Reports.Entities;
using ESourcing.Reports.Repositories.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESourcing.Reports.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly IReportContext _context;

        public ReportRepository(IReportContext context)
        {
            _context = context;
        }
        public async Task Create(Report report)
        {
            await _context.Reports.InsertOneAsync(report);
        }

        public async Task<bool> Delete(string id)
        {
            var filter = Builders<Report>.Filter.Eq(p => p.Id, id);
            DeleteResult deleteResult = await _context.Reports.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        public async Task<Report> GetReport(string id)
        {
            return await _context.Reports.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Report>> GetReports()
        {
            return await _context.Reports.Find(p => true).ToListAsync();
        }

        public async Task<bool> Update(Report report)
        {
            var updateResult = await _context.Reports.ReplaceOneAsync(filter: p => p.Id == report.Id, replacement: report);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
