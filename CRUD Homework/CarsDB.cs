using System;
using System.Data.SqlClient;

namespace CRUD_Homework
{
    internal class CarsDB
    {
        public void Create(Cars car)
        {
            string sql;
            SqlConnection conn = new SqlConnection("server =Administrator ; database = Car; user id = reader ; password = pass123");
            conn.Open();
            sql = "insert into Cars (CarMaker,CarModel,CarYear) Values ('" + car.CarMaker + "', '" + car.CarModel + "'," + car.CarYear + ")";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public Cars[] GetAllCars()
        {
            string sql;
            int i = 0, size;
            CarsDB cardb = new CarsDB();
            size = cardb.Count();
            Cars[] car1 = new Cars[size];

            SqlConnection conn = new SqlConnection("server = Administrator ;database = Car; user id = reader; password = pass123");
            conn.Open();
            sql = "select * from Cars";
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            //for (int j = 0; j < size; j++) //Question here how to solve the error: " object reference not set to an instance of an object." with out this initializing loop
            //  car1[j] = new Cars();

            while (reader.Read())
            {
                car1[i] = new Cars(); //you have to initialize each variable of the array before using it, then you can use it.

                car1[i].CarID = Convert.ToInt32(reader[0]);
                car1[i].CarMaker = reader.GetString(1);
                car1[i].CarModel = reader.GetString(2);
                car1[i].CarYear = reader.GetInt32(3);
                i++;
            }

            reader.Close();
            conn.Close();
            return car1;
        }

        public Cars GetCarId(int carid)
        {
            string sql;
            Cars car = new Cars();

            SqlConnection conn = new SqlConnection("server = administrator ;database = Car; user id = reader; password = pass123");
            conn.Open();
            sql = "select * from Cars where CarID = " + carid;

            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                car.CarID = reader.GetInt32(0);
                car.CarMaker = reader.GetString(1);
                car.CarModel = reader.GetString(2);
                car.CarYear = reader.GetInt32(3);
            }

            reader.Close();
            conn.Close();
            return car;
        }
        public void UpdateCar(Cars car2)
        {
            SqlConnection conn = new SqlConnection("server =Administrator ; database = Car; user id =reader ; password= pass123");
            conn.Open();
            string sql = "update Cars set CarMaker = '" + car2.CarMaker + "',CarModel = '" + car2.CarModel + "',CarYear = " + car2.CarYear + " where CarID = " + car2.CarID;
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public void deleteCar(int carid_)
        {
            SqlConnection conn = new SqlConnection("server =Administrator ; database = Car; user id =reader ; password= pass123");
            conn.Open();
            string sql = "delete from Cars where CarID = " + carid_;
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public int Count()
        {
            int j = 0;
            string sql;
            SqlConnection conn = new SqlConnection("server = Administrator; database= Car; user id =reader; password = pass123");
            conn.Open();
            sql = "select count (CarID) from Cars";
            SqlCommand cmd = new SqlCommand(sql, conn);
            j = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return j;
        }
        public void print(Cars car)
        {
            Console.WriteLine("CarID   CarMaker     CarModel     CarYear");
            Console.Write(" " + car.CarID + "       ");
            Console.Write(car.CarMaker + "      ");
            Console.Write(car.CarModel + "     ");
            Console.WriteLine(car.CarYear);
        }
    }
}
