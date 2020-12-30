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
    public class HallService
    {
        public static List<Hall> GetHalls()
        {
            ISession session = SessionManager.GetSession();
            List<Hall> halls = new List<Hall>();


            if (session == null)
                return null;

            var hallsData = session.Execute("select * from \"Hall\"");


            foreach (var hallData in hallsData)
            {
                Hall hall = new Hall();
                hall.HallId = hallData["HallId"] != null ? hallData["HallId"].ToString() : string.Empty;
                hall.Name = hallData["Name"] != null ? hallData["Name"].ToString() : string.Empty;
                hall.NumberOfSeats = hallData["NumberOfSeats"] != null ? hallData["NumberOfSeats"].ToString() : string.Empty;
                hall.Type = hallData["Type"] != null ? hallData["Type"].ToString() : string.Empty;
                halls.Add(hall);
            }
            return halls;
        }
        public static Hall GetHallById(string HallId)
        {
            ISession session = SessionManager.GetSession();
            Hall hall = new Hall();

            if (session == null)
                return null;

            var hallData = session.Execute("select * from \"Hall\" where \"HallId\" = '" + HallId + "'").FirstOrDefault();

                hall.HallId = hallData["HallId"] != null ? hallData["HallId"].ToString() : string.Empty;
                hall.Name = hallData["Name"] != null ? hallData["Name"].ToString() : string.Empty;
                hall.NumberOfSeats = hallData["NumberOfSeats"] != null ? hallData["NumberOfSeats"].ToString() : string.Empty;
                hall.Type = hallData["Type"] != null ? hallData["Type"].ToString() : string.Empty;

            return hall;
           
        }
        public static void AddHall(Hall hall)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            hall.HallId = Guid.NewGuid().ToString();

            RowSet hallData = session.Execute("insert into \"Hall\" (\"HallId\",\"Name\", \"NumberOfSeats\", \"Type\")  values ('" + hall.HallId + "', '" + hall.Name + "', '" + hall.NumberOfSeats + "', '" + hall.Type + "')");

        }
        public static void EditHall(Hall hall)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet hallData = session.Execute("update \"Hall\" set \"Name\" = '" + hall.Name + "', \"NumberOfSeats\" = '" + hall.NumberOfSeats + "',\"Type\" = '" + hall.Type + "' where \"HallId\" = '" + hall.HallId + "'");
        }
        public static void DeleteHall(string hallID)
        {
            ISession session = SessionManager.GetSession();

            if (session == null)
                return;

            RowSet hallData = session.Execute("delete from \"Hall\" where \"HallId\" = '" + hallID + "'");

        }
    }
}
