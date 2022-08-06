﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfNotifications.Models;

namespace WpfNotifications.Cmds
{
    public class AddCarCommand : CommandBase
    {
        public override bool CanExecute(object parameter)
            => parameter is ObservableCollection<Car>;
        public override void Execute(object parameter)
        {
            if (parameter is not ObservableCollection<Car> cars)
            {
                return;
            }
            var maxCount = cars.Max(x => x.Id);
            cars.Add(new Car
            {
                Id = ++maxCount,
                Color = "Yellow",
                Make = "VW",
                PetName = "Birdie"
            });
        }
    }
}