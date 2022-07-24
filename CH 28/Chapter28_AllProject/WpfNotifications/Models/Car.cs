using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace WpfNotifications.Models
{
    public partial class Car : BaseEntity, INotifyPropertyChanged
    {
        //Omitted for brevity
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _isChanged;
        public bool IsChanged
        {
            get => _isChanged;
            set
            {
                if (value == _isChanged) return;
                _isChanged = value;
                OnPropertyChanged();
            }
        }
        private int _id;
        public int Id
        {
            get => _id;
            set
            {
                if (value == _id) return;
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _make;
        [Required]
        [StringLength(50)]
        public string Make
        {
            get => _make;
            set
            {
                if(value == _make) return;
                _make = value;
                OnPropertyChanged();
            }
        }
        private string _color;
        [Required]
        [StringLength(50)]
        public string Color
        {
            get => _color;
            set
            {
                if (value == _color) return;
                _color = value;
                OnPropertyChanged();
            }
        }
        private string _petName;
        [Required]
        [StringLength(50)]
        public string PetName
        {
            get => _petName;
            set
            {
                if (value == _petName) return;
                _petName = value;
                OnPropertyChanged();
            }
        }
        protected virtual void OnPropertyChanged(
            [CallerMemberName] string propertyName = "")
        {
            if (propertyName != nameof(IsChanged))
            {
                IsChanged = true;
            }
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(String.Empty));
        }
    }
}
