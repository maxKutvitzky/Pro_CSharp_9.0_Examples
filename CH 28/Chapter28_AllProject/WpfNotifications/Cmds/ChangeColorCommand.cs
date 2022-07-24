using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfNotifications.Models;

namespace WpfNotifications.Cmds
{
    public class ChangeColorCommand : CommandBase
    {
        public override bool CanExecute(object parameter)
            => parameter is Car;
        public override void Execute(object parameter)
        {
            ((Car)parameter).Color = "Pink";
        }
    }
}
