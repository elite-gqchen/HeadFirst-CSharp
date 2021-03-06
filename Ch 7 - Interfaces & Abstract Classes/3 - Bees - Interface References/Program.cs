﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeesInterfaceReference
{
    static class Program
    {
        static void Main(string[] args)
        {
            StingPatrol biff = new StingPatrol(72);
            NectarCollector bertha = new NectarCollector(45);

            // Defender can reference biff since they implement the same interface
            // Defender itself cannot be initialized since it is only an interface, but it can point to the 'biff' object
            IStingPatrol defender = biff;
            INectarCollector cutiePie = bertha;

            // Biff's object remains since the defender still references it
            biff = null;

            // Assigning an object straight to an interface reference variable
            INectarCollector gatherer = new NectarStinger(90);

            // In the following, the array can include several different class types as they all inherit from 'Worker'.
            // Bee 0 & bee 2 will be assigned the job as they both inherit the INectarCollector
            Worker[] bees = new Worker[3];
            bees[0] = new NectarCollector(40);
            bees[1] = new StingPatrol(60);
            bees[2] = new NectarStinger(85);
            for (int i = 0; i < bees.Length; i++)
            {
                if (bees[i] is INectarCollector)
                {
                    bees[i].DoThisJob("Nectar Collector", 3);
                }
            }
        }
    }
}
