using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FestivalManager_2.Model.DAL;
using FestivalManager_2.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Windows.Controls;
using FestivalManager_2.View;

namespace FestivalManager_2.ViewModel
{
    class ContactpersonenVM : ObservableObject
    {
        public ContactpersonenVM()
        {
            _allContacts = ContactRepository.getContacts();
            _contacts = _allContacts;
            FillFuncties();
            FillOrganisaties();           
        }

        private void FillOrganisaties()
        {
            _organisaties = OrganisatieRepository.GetOrganisaties();
            _organisaties.Insert(0, new Organisatie() { ID = 0, Naam = "-- Alle organisaties--" });
             
        }

        private void FillFuncties()
        {
            _functies = FunctieRepository.GetFuncties();
            _functies.Insert(0, new Functie() { ID = 0, Naam = "-- Alle functies--" });
        }
        private ObservableCollection<Contact> _allContacts;

        private ObservableCollection<Contact> _contacts;
        public ObservableCollection<Contact> Contacts
        {
            get
            {
                return _contacts;
            }
            set{
                _contacts = value;
                OnPropertyChanged("Contacts");
            }
        }

        private ObservableCollection<Functie> _functies;

        public ObservableCollection<Functie> Functies
        {
            get
            {
                return _functies;
            }
            set
            {
                _functies = value;
            }
        }
        private ObservableCollection<Organisatie> _organisaties;

        public ObservableCollection<Organisatie> Organisaties
        {
            get
            {
                return _organisaties;
            }
            set
            {
                _organisaties = value;
            }
        }

        private Functie _currentFunctie;
        public Functie CurrentFunctie
        {
            get
            {
                return _currentFunctie;
            }
            set
            {
                _currentFunctie = value;
                FilterContacts();
                OnPropertyChanged("CurrentFunctie");
            }
        }

        private Organisatie _currentOrganisatie;
        public Organisatie CurrentOrganisatie
        {
            get
            {
                return _currentOrganisatie;
            }
            set
            {
                _currentOrganisatie = value;
                FilterContacts();
                OnPropertyChanged("CurrentOrganisatie");
            }
        }

        public string Name
        {
            get { return "Overzicht"; }
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
                FilterContacts();
            }
        }

        private void FilterContacts()
        {
            string s = this.Search;

            if (s == null || s == "")
            {
                this.Contacts = ContactRepository.FilterContacts(this._allContacts, this.CurrentFunctie, this.CurrentOrganisatie);
                return;
            }   

            ObservableCollection<Contact> lContacts = new ObservableCollection<Contact>();
            foreach (Contact c in this._allContacts)
            {
                string voornaamNaam = c.Voornaam + " " + c.Naam;
                if (voornaamNaam.ToLower().Contains(s.ToLower()))
                    lContacts.Add(c);
            }

            this.Contacts = lContacts;
            this.Contacts = ContactRepository.FilterContacts(this.Contacts, this.CurrentFunctie, this.CurrentOrganisatie);
        }
    }
}
