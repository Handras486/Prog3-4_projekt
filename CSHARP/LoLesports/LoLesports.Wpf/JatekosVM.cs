using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLesports.Wpf
{
    class JatekosVM : ObservableObject
    {
        private string felhasznalonev;
        private string vezeteknev;
        private string keresztnev;
        private Nullable<int> eletkor;
        private string pozicio;
        private string nemzetiseg;
        private string csapatnev;

        public string Felhasznalonev
        {
            get { return felhasznalonev; }
            set { Set(ref felhasznalonev, value); }
        }

        public string Vezeteknev
        {
            get { return vezeteknev; }
            set { Set(ref vezeteknev, value); }
        }
        public string Keresztnev
        {
            get { return keresztnev; }
            set { Set(ref keresztnev, value); }
        }

        public Nullable<int> Eletkor
        {
            get { return eletkor; }
            set { Set(ref eletkor, value); }
        }
        public string Pozicio
        {
            get { return pozicio; }
            set { Set(ref pozicio, value); }
        }

        public string Nemzetiseg
        {
            get { return nemzetiseg; }
            set { Set(ref nemzetiseg, value); }
        }

        public string Csapatnev
        {
            get { return csapatnev; }
            set { Set(ref csapatnev, value); }
        }

        public void CopyFrom(JatekosVM other)
        {
            if (other == null) return;
            this.Felhasznalonev = other.Felhasznalonev;
            this.Vezeteknev = other.Vezeteknev;
            this.Keresztnev = other.Keresztnev;
            this.Eletkor = other.Eletkor;
            this.Pozicio = other.Pozicio;
            this.Nemzetiseg = other.Nemzetiseg;
            this.Csapatnev = other.Csapatnev;

    }

    }
}
