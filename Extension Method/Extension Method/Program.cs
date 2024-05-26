using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension_Method
{
    //extension method should be static and inside a static class
    internal class Program
    {
        static void Main(string[] args)
        {
            "Hello world".PrintToConsole();
            HotelRoomModel roomModel = new HotelRoomModel();
            roomModel.TurnOnAc().SetTemperature(30).OpenShades();
            Console.WriteLine(roomModel.AreShadesOpen);
            roomModel.CloseShade();
            Console.ReadLine();
        }
    }

    public class HotelRoomModel
    {
        public int Temp { get; set; }
        public bool IsACRunning { get; set; }
        public bool AreShadesOpen { get; set; }

    }
    public static class ExtenstionClass
    {
        public static void  PrintToConsole(this string Message)
        {
            Console.WriteLine(Message);
        }
        public static HotelRoomModel TurnOnAc(this HotelRoomModel room)
        {
            room.IsACRunning=true;
            return room;
        }

        public static HotelRoomModel SetTemperature(this HotelRoomModel room, int temperature)
        {
            room.Temp = temperature;
            return room;
        }
        public static HotelRoomModel OpenShades(this HotelRoomModel room)
        {
            room.AreShadesOpen=true;
            return room;
        }
        public static HotelRoomModel CloseShade(this HotelRoomModel room)
        {
            room.AreShadesOpen = false;
            return room;
        }

    }
}
