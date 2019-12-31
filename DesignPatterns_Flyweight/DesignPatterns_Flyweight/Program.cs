using System;
using System.Collections.Generic;

namespace DesignPatterns_Flyweight
{
    class Program
    {
        //original source https://metanit.com/sharp/patterns/4.7.php
        static void Main(string[] args)
        {
            Console.WriteLine("Design Patterns - Flyweight");

            double longitude = 37.61;
            double latitude = 55.74;

            HouseFactory houseFactory = new HouseFactory();
            for (int i = 0; i < 5; i++)
            {
                House panelHouse = new PanelHouse();
                if (panelHouse != null)
                {
                    panelHouse.Build(longitude, latitude);
                }

                longitude += 0.1;
                latitude += 0.1;
            }

            for (int i = 0; i < 5; i++)
            {
                House brickHouse = new BrickHouse();
                if (brickHouse != null)
                {
                    brickHouse.Build(longitude, latitude);
                }

                longitude += 0.1;
                latitude += 0.1;
            }
        }
    }


    abstract class House
    {
        protected int _stages;
        public abstract void Build(double longitude, double latitude);
    }

    class PanelHouse : House
    {
        public PanelHouse()
        {
            _stages = 16;
        }

        public override void Build(double longitude, double latitude)
        {
            Console.WriteLine($"{_stages}-stages panel house is built. Coordinates: Longitude {longitude}, Latitude {latitude}");
        }
    }

    class BrickHouse : House
    {
        public BrickHouse()
        {
            _stages = 5;
        }

        public override void Build(double longitude, double latitude)
        {
            Console.WriteLine($"{_stages}-stage brick house is built. Coordinates: Longitude {longitude}, Latitude {latitude}");
        }
    }

    class HouseFactory
    {
        Dictionary<string, House> houses = new Dictionary<string, House>();

        public HouseFactory()
        {
            houses.Add("Panel", new PanelHouse());
            houses.Add("Brick", new BrickHouse());;
        }

        public House GetHouse(string key)
        {
            if (houses.ContainsKey(key))
            {
                return houses[key];
            }
            else
            {
                return null;
            }
        }
    }
}
