using FestivalManager_2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FestivalManager_2.Model.DAL;

namespace FestivalManager_2.ViewModel
{
    class Line_UpGroepenVM : ObservableObject, IPage
    {
        public Line_UpGroepenVM()
        {
            _alleGroepen = GroepenRepository.GetGroepen();
            _groepen = _alleGroepen;
        }

        public string Name
        {
            get { return "Groepen"; }  //unieke naam
        }

        private ObservableCollection<Groep> _alleGroepen;

        private ObservableCollection<Groep> _groepen;
        public ObservableCollection<Groep> Groepen
        {
            get
            {
                return _groepen;
            }
            set
            {
                _groepen = value;
                OnPropertyChanged("Groepen");
            }
        }

        private string _search;
        public string Search
        {
            get
            {
                return _search;
            }
            set
            {
                _search = value;
                UpdateGroepen(this.Search);
            }
        }

        private void UpdateGroepen(string p)
        {
            if (p == null || p == "")
                this.Groepen = this._alleGroepen;

            ObservableCollection<Groep> lGroepen = new ObservableCollection<Groep>();
            foreach(Groep g in this._alleGroepen)
            {
                if (g.Naam.ToLower().Contains(p.ToLower()))
                    lGroepen.Add(g);
            }
            this.Groepen = lGroepen;
        }
    }
}
