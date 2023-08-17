using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Homework
{
    internal class Cars
    {
        public int CarID;
        public string CarMaker;
        public string CarModel;
        public int CarYear;

        public Cars() //First constructor
        {
            Console.WriteLine("This is the First constructor for this class.");
        }

        public Cars(int carID, string carMaker, string carModel, int carYear)//Second constructor
        {
            this.CarID = carID;
            this.CarMaker = carMaker;
            this.CarModel = carModel;
            this.CarYear = carYear;
            Console.WriteLine("This is the Second constructor for this class.");

        }
    }


}
