using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string choose;
            Cars car=new Cars();
            CarsDB cardb=new CarsDB();
            do
            {
                Console.WriteLine("Welcome to Car database!!!\nOur data base consists of following attributes: CarMaker, CarModel, CarYear.\n");
                do
                {
                    Console.WriteLine("Choose from the list:\n- Create.\n- Read. \n- Update. \n- Delete.\n- Exit.");
                    choose = Console.ReadLine();
                    Console.Write("\n");
                    choose = choose.ToLower();
                } while (choose != "create" && choose != "read" && choose != "update" && choose != "delete" && choose != "exit");
                switch (choose)
                {
                    case "create":
                        {
                            Console.Write("Enter Car Maker:");
                            car.CarMaker = Convert.ToString(Console.ReadLine());
                            Console.Write("Enter Car Model:");
                            car.CarModel = Convert.ToString(Console.ReadLine());
                            Console.Write("Enter Car year:");
                            car.CarYear = Convert.ToInt32(Console.ReadLine());
                            cardb.Create(car);
                            Console.WriteLine("You inserted the data successfully!!!!");
                            cardb.print(car);
                            break;
                        }
                    case "read":
                        {
                            int choose_;
                            do
                            {
                                Console.Write("----------------------------\n1- Read all data.\n2- Read by Car ID.\nChoose the number form above list:");
                                choose_ = Convert.ToInt32(Console.ReadLine());
                            } while (choose_ != 1 && choose_ != 2);
                            switch (choose_)
                            {
                                case 1:
                                    {
                                        int size = cardb.Count();
                                        Cars[] car1 = new Cars[size];
                                        car1 = cardb.GetAllCars();

                                        Console.WriteLine("CarID   CarMaker     CarModel     CarYear");
                                        for (int j = 0; j < size; j++)
                                        {
                                            Console.Write(" "+ car1[j].CarID + "    ");
                                            Console.Write(car1[j].CarMaker + "    ");
                                            Console.Write(car1[j].CarModel + "    ");
                                            Console.WriteLine(car1[j].CarYear + "    ");
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        int carid, size;
                                        CarsDB cardb_ = new CarsDB();
                                        Cars car_ = new Cars();
                                        size = cardb_.Count();
                                        if (size == 0)
                                        {
                                            Console.WriteLine("No data in the table :(");
                                            break;
                                        }
                                        else
                                        {
                                            Console.Write("Enter the car Id you want to read:");
                                            carid = Convert.ToInt32(Console.ReadLine());

                                            car_ = cardb.GetCarId(carid);
                                            Console.WriteLine("---------------------");
                                            Console.WriteLine("CarID   CarMaker     CarModel     CarYear");

                                            Console.Write(" " + car_.CarID + "        ");
                                            Console.Write(car_.CarMaker + "  ");
                                            Console.Write(car_.CarModel + "   ");
                                            Console.WriteLine(car_.CarYear);
                                        }
                                        break;
                                    }
                            }
                            break;
                        }
                    case "update":
                        {
                            Cars carnew=new Cars();
                            Cars carold=new Cars();
                            Cars carnew1 = new Cars();
                            CarsDB cardb1 = new CarsDB();
                            string choice;

                            int size;
                            size = cardb1.Count();
                            if (size == 0)
                            {
                                Console.WriteLine("No data in the table, please update the first row (CarId = 1)");
                                carnew.CarID = 1;
                            }
                            else
                            {
                                Console.Write("Please enter the car Id you want to update:");
                                carnew.CarID = Convert.ToInt32(Console.ReadLine());
                            }
                            carold = cardb1.GetCarId(carnew.CarID);
                            cardb1.print(carold);

                            Console.WriteLine("Are you sure you want to update the previous data: (Y/N)?");
                            choice = Console.ReadLine();
                            choice = choice.ToLower();

                            if (choice == "n")
                                break;
                            if (choice == "y")
                            {
                                Console.Write("Please enter the updated car Maker:");
                                carnew.CarMaker = Console.ReadLine();
                                Console.Write("Please enter the updated car Model:");
                                carnew.CarModel = Console.ReadLine();
                                Console.Write("Please enter the updated car Year:");
                                carnew.CarYear = Convert.ToInt32(Console.ReadLine());

                                cardb1.UpdateCar(carnew);

                                Console.WriteLine("Updated Successfully!!!!\nThe new data:");
                                carnew1 = cardb1.GetCarId(carnew.CarID);
                                cardb1.print(carnew);
                            }
                            break;
                        }
                    case "delete":
                        {
                            int carid_;
                            string choice;
                            CarsDB cardb1 = new CarsDB();
                            Cars cardelete = new Cars();

                            int size;
                            size = cardb1.Count();
                            if (size == 0)
                            {
                                Console.WriteLine("No data in the table to delete");
                                break;
                            }
                            else
                            {
                                Console.Write("Please enter the car Id you want to Delete:");
                                carid_ = Convert.ToInt32(Console.ReadLine());
                            }

                            Console.Write("\n");

                            cardelete = cardb1.GetCarId(carid_);
                            cardb1.print(cardelete);

                            Console.WriteLine("Are you sure you want to DELETE the previous data: (Y/N)?");
                            choice = Console.ReadLine();
                            choice = choice.ToLower();

                            if (choice == "n")
                                break;
                            if (choice == "y")
                            {
                                cardb1.deleteCar(carid_);
                                Console.WriteLine("Deleted Successfully!!!\nThe new data after the delete:");

                                int size1 = cardb.Count();
                                Cars[] car1 = new Cars[size1];
                                car1 = cardb.GetAllCars();

                                Console.WriteLine("CarID   CarMaker     CarModel     CarYear");
                                for (int j = 0; j < size1; j++)
                                {
                                    Console.Write(" " + car1[j].CarID + "    ");
                                    Console.Write(car1[j].CarMaker + "    ");
                                    Console.Write(car1[j].CarModel + "    ");
                                    Console.WriteLine(car1[j].CarYear + "    ");
                                }
                            }
                            break;
                        }
                    case "exit":
                        {
                            break;
                        }
                }
                Console.WriteLine("---------------------------------\n");
            } while (choose != "exit");

            Console.WriteLine("Done!");
            Console.ReadLine();

        }
    }
}