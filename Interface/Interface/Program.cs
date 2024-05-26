using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    public class Program
    {
        static void Main(string[] args)
        {
            Keyboard keyboard = new Keyboard();
            GameController controller = new GameController();
            List<IComputerController>controllers= new List<IComputerController> ();
            controllers.Add(controller);
            controllers.Add(keyboard);

            BatteryPoweredGameController batteryPoweredGameController = new BatteryPoweredGameController ();
            controllers.Add(batteryPoweredGameController);
            foreach (var item in  controllers)
            {
                item.CurrentKeyPressed();

                if(item is GameController gc)
                {
                    //Aliasing for this block
                    //item.Connect();
                    gc.Connect();
                }
                if(item is IBatteryPowered pow)
                {
                    pow.BatteryLevel += 20;
                }
            }
            using(Keyboard keyboard1 = new Keyboard())
            {


                //Since we have implemented IDispose interface, after this block is used, it will automatically dispose the object/image
            }
            BatteryPoweredGameController batteryController = new BatteryPoweredGameController();
            BatteryPoweredKeyboard batteryKeyboard = new BatteryPoweredKeyboard();
            List<IBatteryPowered> powered = new List<IBatteryPowered> ();
            powered.Add(batteryController);
            powered.Add(batteryKeyboard);


            Console.ReadLine();
        }
    }
    public interface IComputerController:IDisposable
    {
        void CurrentKeyPressed();
        void Connect();
    }
    public interface IBatteryPowered
    {
        int BatteryLevel { get; set; }
    }
    public class BatteryPoweredKeyboard : Keyboard,IBatteryPowered
    {
        public int BatteryLevel { get; set; }

    }
    public class BatteryPoweredGameController: GameController, IBatteryPowered
    {
        public int BatteryLevel { get; set; }
    }
    public class Keyboard: IComputerController,IDisposable
    {
        public void CurrentKeyPressed()
        {

        }
        public void Connect()
        {

        }

        public void Dispose()
        {
        }
    }
    public class GameController: IComputerController
    {
        public void Connect()
        {

        }
        public void CurrentKeyPressed()
        {

        }

        public void Dispose()
        {
        }
    }
}
