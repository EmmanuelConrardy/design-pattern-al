﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var teacher = new Teacher("Me"); // subject
            teacher.Attach(new StudentSleeping("Raph")); // observer
            teacher.Attach(new StudentAwake("Leo"));

            //Act
            teacher.Teach(); //Notify

            Console.ReadLine();
        }
    }
}
