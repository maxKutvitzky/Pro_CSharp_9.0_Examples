﻿using System;
// Don't forget to import the CarLibrary namespace!
using CarLibrary;

Console.WriteLine("***** C# CarLibrary Client App *****");
// Make a sports car.
SportsCar viper = new SportsCar("Viper", 240, 40);
viper.TurboBoost();
// Make a minivan.
MiniVan mv = new MiniVan();
mv.TurboBoost();
Console.WriteLine("Done. Press any key to terminate");
var internalClassInstance = new MyInternalClass();
Console.ReadLine();
