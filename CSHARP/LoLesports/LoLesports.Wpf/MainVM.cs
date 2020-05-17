using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using LoLesports.Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LoLesports.Wpf
{
    class MainVM : ViewModelBase
    {
		private MainLogic logic;
		private JatekosVM selectedJatekos;
		private ObservableCollection<JatekosVM> allJatekosok;

		public ObservableCollection<JatekosVM> AllJatekosok
		{
			get { return allJatekosok; }
			set { Set(ref allJatekosok, value); }
		}

		public JatekosVM SelectedJatekos
		{
			get { return selectedJatekos; }
			set { Set(ref selectedJatekos, value); }
		}

		public ICommand AddCmd { get; private set; }
		public ICommand DelCmd { get; private set; }
		public ICommand ModCmd { get; private set; }
		public ICommand LoadCmd { get; private set; }

		public Func<JatekosVM, bool> EditorFunc { get; set; }

		public MainVM()
		{
			logic = new MainLogic();

			DelCmd = new RelayCommand(() => logic.ApiDelJatekos(selectedJatekos));
			AddCmd = new RelayCommand(() => logic.EditJatekos(null, EditorFunc));
			ModCmd = new RelayCommand(() => logic.EditJatekos(selectedJatekos, EditorFunc));
			LoadCmd = new RelayCommand(() =>
				AllJatekosok = new ObservableCollection<JatekosVM>(logic.ApiGetJatekosok()));
		}
	}
}
