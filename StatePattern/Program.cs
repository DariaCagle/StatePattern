using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car(new NotMoving());
            car.Throttle();
            car.Throttle();
            car.Brake();
            car.Brake();

            Console.Read();
        }
    }
    class Car
    {
        public ICarState State { get; set; }

        public Car(ICarState cs)
        {
            State = cs;
        }

        public void Throttle()
        {
            State.Throttle(this);
        }
        public void Brake()
        {
            State.Brake(this);
        }
    }

    interface ICarState
    {
        void Throttle(Car car);
        void Brake(Car car);
    }

    class Moving : ICarState
    {
        public void Throttle(Car car)
        {
            Console.WriteLine("Moving faster");
        }

        public void Brake(Car car)
        {
            Console.WriteLine("Stopping");
            car.State = new NotMoving();
        }
    }
    class NotMoving : ICarState
    {
        public void Throttle(Car car)
        {
            Console.WriteLine("Starting to move");
            car.State = new Moving();
        }

        public void Brake(Car car)
        {
            Console.WriteLine("Still not moving");
        }
    }

}
