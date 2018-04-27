using System;
using System.Data;
using System.Data.SQLite;

namespace DBHandler
{
    public class DbHandler
    {
        //Could also be put inside a config file (check readme for more information)
        static SQLiteConnection _Conn = new SQLiteConnection("Data Source="+ Environment.CurrentDirectory+ "/Database/TestDB.db;New=False");

        public static void insertReservation(Reservation reserv)
        {
            string command = "Insert into Reservations values (?,?,?,?,?,?)";

            if(reserv.ReservationGuid == "")
            {
                reserv.ReservationGuid = Guid.NewGuid().ToString();
            }

            insertRow(command, reserv);
        }

        public static Reservation getReservation(string guid)
        {
            string query = "select * from Reservations where Reservations.ReservationGuid = '" + guid + "'";

            DataTable dt = selectQuery(query);

            return new Reservation
            {
                ReservationGuid = guid,
                Type = (LivingType)Enum.Parse(typeof(LivingType), dt.Rows[0]["Type"].ToString()),
                PersonalNumber = dt.Rows[0]["PersonalNumber"].ToString(),
                DateMade = DateTime.Parse(dt.Rows[0]["DateMade"].ToString()),
                EndDate = DateTime.Parse(dt.Rows[0]["EndDate"].ToString())
            };
        }

        private static void insertRow(string command, Reservation reserv)
        {
            try
            {
                SQLiteCommand cmd = new SQLiteCommand(command);
                _Conn.Open();
                cmd.Parameters.Add(reserv.ReservationGuid);
                cmd.Parameters.Add(nameof(reserv.Type));
                cmd.Parameters.Add(reserv.PersonalNumber);
                cmd.Parameters.Add(reserv.DateMade.ToShortDateString());
                cmd.Parameters.Add(reserv.Cost);
                cmd.Parameters.Add(reserv.EndDate.ToShortDateString());

                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException ex)
            {
                //Insert logging here
            }

            _Conn.Close();         
        }
        private static DataTable selectQuery(string query)
        {
            SQLiteDataAdapter ad;
            DataTable dt = new DataTable();

            try
            {
                SQLiteCommand cmd;
                _Conn.Open();
                cmd = _Conn.CreateCommand();
                cmd.CommandText = query;
                ad = new SQLiteDataAdapter(cmd);
                ad.Fill(dt);
            }
            catch (SQLiteException ex)
            {
                //Insert logging here
            }

            _Conn.Close();
            return dt;
        }
    }
}
