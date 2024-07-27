using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesignPattern.FacadePattern;

namespace DesignPattern.FacadePattern
{
    public class Thermostat
    {
        public void SetTemperature(int temperature)
        {
            System.Console.WriteLine($"Setting temperature to {temperature}");
        }
    }
    public class Lights
    {
        public void TurnOn()
        {
            Console.WriteLine("Lights are On");
        }
        public void TurnOff()
        {
            Console.WriteLine("Lights are Off");
        }
    }
    public class CoffeeMaker
    {
        public void brewCoffee()
        {
            Console.WriteLine("Brewing Coffee.");
        }
    }

    public class SmartHomeFacade
    {
        private Thermostat thermostat;
        private Lights lights;
        private CoffeeMaker coffeeMaker;
        public SmartHomeFacade(Thermostat thermostat, Lights lights, CoffeeMaker coffeeMaker)
        {
            this.thermostat = thermostat;

            this.coffeeMaker = coffeeMaker;
            this.lights = lights;
        }
        public void WakeUp()
        {
            System.Console.WriteLine("Waking Up");
            thermostat.SetTemperature(22);
            lights.TurnOn();
            coffeeMaker.brewCoffee();
        }
        public void LeaveHouse()
        {
            System.Console.WriteLine("Leaving Home");
            thermostat.SetTemperature(18);
            lights.TurnOff();
        }
    }
    public class FacadeImplemenation
    {
        public void Main()
        {
            Thermostat thermostat = new Thermostat();
            Lights lights = new Lights();
            CoffeeMaker coffeeMaker = new CoffeeMaker();

            SmartHomeFacade smartHomeFacade = new SmartHomeFacade(thermostat, lights, coffeeMaker);

            smartHomeFacade.WakeUp();
            smartHomeFacade.LeaveHouse();
        }
    }
}