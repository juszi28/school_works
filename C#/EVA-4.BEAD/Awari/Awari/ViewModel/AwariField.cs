using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace Awari.ViewModel
{
    public class AwariField : ViewModelBase
    {
        private bool isEnabled;
        private string text;

        public bool IsEnabled
        {
            get { return isEnabled; }
            set
            {
                if(isEnabled != value)
                {
                    isEnabled = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Text
        {
            get { return text; }
            set
            {
                if(text != value)
                {
                    text = value;
                    OnPropertyChanged();
                }    
            }
        }

        public int Size { get; set; }
        public int Number { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public SolidColorBrush Color { get; set; }
        public DelegateCommand StepCommand { get; set; }
    }
}
