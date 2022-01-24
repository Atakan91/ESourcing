using ESourcing.Reports.Data.Interfaces;
using ESourcing.Reports.Entities;
using ESourcing.Reports.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESourcing.Reports.Data
{
    public class ReportContext : IReportContext
    {
        public ReportContext(IReportDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            Reports = database.GetCollection<Report>(settings.CollectionName);
        }
        public IMongoCollection<Report> Reports { get; }
    }
}
