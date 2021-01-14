using BookingTicket.Entities;
using BookingTicket.Entities.Entities;
using Cassandra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingTicket.Service
{
    public class ProjectionService
    {
        public static List<Projection> GetProjections()
        {
            ISession session = SessionManager.GetSession();
            List<Projection> projections = new List<Projection>();


            if (session == null)
                return null;

            var projectionsData = session.Execute("select * from \"Projection\"");


            foreach (var projectionData in projectionsData)
            {
                Projection projection = new Projection();
                projection.ProjectionId = projectionData["ProjectionId"] != null ? projectionData["ProjectionId"].ToString() : string.Empty;
                projection.MovieId = projectionData["MovieId"] != null ? projectionData["MovieId"].ToString() : string.Empty;
                projection.HallId = projectionData["HallId"] != null ? projectionData["HallId"].ToString() : string.Empty;
                projection.Time = projectionData["Time"] != null ? projectionData["Time"].ToString() : string.Empty;
                projections.Add(projection);
            }
            return projections;
        }
        public static List<Projection> GetProjectionsByMovieId(string movieID)
        {
            ISession session = SessionManager.GetSession();
            List<Projection> projections = new List<Projection>();


            if (session == null)
                return null;

            var projectionsData = session.Execute("select * from \"Projection\" where \"MovieId\" = '"+movieID+ "' ALLOW FILTERING");


            foreach (var projectionData in projectionsData)
            {
                Projection projection = new Projection();
                projection.ProjectionId = projectionData["ProjectionId"] != null ? projectionData["ProjectionId"].ToString() : string.Empty;
                projection.MovieId = projectionData["MovieId"] != null ? projectionData["MovieId"].ToString() : string.Empty;
                projection.HallId = projectionData["HallId"] != null ? projectionData["HallId"].ToString() : string.Empty;
                projection.Time = projectionData["Time"] != null ? projectionData["Time"].ToString() : string.Empty;
                projections.Add(projection);
            }
            return projections;
        }
        public static void AddProjection(Projection projection)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            projection.ProjectionId = Guid.NewGuid().ToString();

            RowSet projectionData = session.Execute("insert into \"Projection\" (\"ProjectionId\",\"MovieId\", \"HallId\", \"Time\")  values ('" + projection.ProjectionId + "', '" + projection.MovieId + "', '" + projection.HallId + "', '" + projection.Time + "')");

        }

    }
  
}
