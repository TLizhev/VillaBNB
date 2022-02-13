using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VillaBNB.Data;

namespace VillaBNB.Services.Statistics
{
    public class StatisticsService : IStatisticsService
    {

        private readonly ApplicationDbContext db;

        public StatisticsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public StatisticsServiceModel Total()
        {
            var totalVillas = this.db.Villas.Count();
            var totalBookings = this.db.Bookings.Count();

            return new StatisticsServiceModel
            {
                VillasCount = totalVillas,
                BookingsCount = totalBookings
            };
        }
    }
}
