using ESourcing.Reports.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESourcing.Reports.Data.Interfaces
{
    public interface IReportContext
    {
        IMongoCollection<Report> Reports { get; }
    }
}
