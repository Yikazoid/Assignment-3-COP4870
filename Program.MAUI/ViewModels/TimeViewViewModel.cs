using Program.Library.Models;
using Program.Library.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Program.MAUI.ViewModels
{
    public class TimeViewViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Time> Times
        {
            get
            {
                if (string.IsNullOrEmpty(Query))
                {
                    return new ObservableCollection<Time>(TimeService.Current.TimeList);
                }
                return new ObservableCollection<Time>(TimeService.Current.Search(Query));
            }
        }

        public string Query { get; set; }
        public Time SelectedTime { get; set; }

        public void Search()
        {
            NotifyPropertyChanged("Times");
        }

        public void Refresh()
        {
            Query = string.Empty;
            NotifyPropertyChanged(nameof(Query));
            NotifyPropertyChanged("Times");
        }

        public void AddTime(Shell s)
        {
            s.GoToAsync($"//TimeDetail?timeId=0");
        }

        public void EditTime(Shell s)
        {
            var idParam = SelectedTime?.Id ?? 0;
            s.GoToAsync($"//TimeDetail?timeId={idParam}");
        }

        public void Delete()
        {
            if(SelectedTime == null)
            {
                return;
            }
            TimeService.Current.Delete(SelectedTime);
            NotifyPropertyChanged("Times");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
