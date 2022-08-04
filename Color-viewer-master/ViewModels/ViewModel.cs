using Color_viewer.Helpers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Media;

namespace Color_viewer.ViewModels
{
    public class ViewModel : OnPropChanged
    {
        byte alpha, red, green, blue;
        public byte Alpha
        {
            get { return alpha; }
            set
            {
                alpha = value;
                OnPropertyChanged("Alpha");
            }
        }
        public byte Red
        {
            get { return red; }
            set
            {
                red = value;
                OnPropertyChanged("Red");
            }
        }
        public byte Green
        {
            get { return green; }
            set
            {
                green = value;
                OnPropertyChanged("Green");
            }
        }
        public byte Blue
        {
            get { return blue; }
            set
            {
                blue = value;
                OnPropertyChanged("Blue");
            }
        }

        private Brush myBrush;
        public Brush MyBrush
        {
            get { return myBrush; }
            set
            {
                myBrush = value;
                OnPropertyChanged("MyBrush");
            }
        }

        private Brush selectedBrush;
        public Brush SelectedBrush
        {
            get { return selectedBrush; }
            set
            {
                selectedBrush = value;
                OnPropertyChanged("SelectedBrush");
            }
        }


        public ObservableCollection<Brush> myBrushList { get; set; } = new ObservableCollection<Brush>();

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      if (myBrush != null)
                          myBrushList.Add(myBrush);
                  }));
            }
        }

        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ?? (deleteCommand = new RelayCommand(obj =>
                {
                    if (obj != null)
                    {
                        Brush br = (Brush)obj;
                        myBrushList.Remove(br);
                    }
                }));
            }
        }

        private void ViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Alpha" || e.PropertyName == "Red" || e.PropertyName == "Green" || e.PropertyName == "Blue")
            {
                MyBrush = new SolidColorBrush(Color.FromArgb(Alpha, Red, Green, Blue));
            }
        }

        public ViewModel()
        {
            PropertyChanged += ViewModelPropertyChanged;
        }
    }
}
