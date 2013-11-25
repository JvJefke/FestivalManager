using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FestivalManager_2.Model;
using System.Data.Common;
using System.Collections.ObjectModel;

namespace FestivalManager_2.Model.DAL
{
    class ContactRepository
    {
        public static ObservableCollection<Contact> getContacts()
        {
            ObservableCollection<Contact> lContacts = new ObservableCollection<Contact>();

            string sql = "SELECT * FROM Contact";
            DbDataReader reader = Database.GetData(sql);

            while(reader.Read())
                lContacts.Add(MaakContact(reader));

            return lContacts;
        }

        private static Contact MaakContact(DbDataReader rij)
        {
            Contact nieuw = new Contact();
            nieuw.ID = Convert.ToInt32(rij["ContactID"].ToString());
            nieuw.Naam = rij["Naam"].ToString().Trim();
            nieuw.Voornaam = rij["Voornaam"].ToString().Trim();
            nieuw.Tel = rij["Tel"].ToString().Trim();
            nieuw.Email = rij["Email"].ToString().Trim();
            nieuw.Postcode = rij["Postcode"].ToString();
            nieuw.Gemeente = rij["Gemeente"].ToString().Trim();
            nieuw.Straat_Nr = rij["Straat_Nr"].ToString().Trim();
            nieuw.Image = rij["Image"].ToString().Trim();
            nieuw.Functie = FunctieRepository.GetFunctieFromID(Convert.ToInt32(rij["FunctieID"]));
            nieuw.Organisatie = OrganisatieRepository.GetOrganisatieFromID(Convert.ToInt32(rij["OrganisatieID"]));
            nieuw.Type = ContactTypeRepository.GetContactTypeFromID(Convert.ToInt32(rij["ContactTypeID"]));

            return nieuw;
        }

        public static ObservableCollection<Contact> FilterContacts(ObservableCollection<Contact> lContacts, Functie f, Organisatie o)
        {

            if ((o == null || o.ID == 0) && (f == null || f.ID == 0))
                return lContacts;

            ObservableCollection<Contact> lCon = lContacts;

            if (o != null)
                if (o.ID != 0)
                {
                    ObservableCollection<Contact> temp = new ObservableCollection<Contact>();
                    foreach (Contact c in lCon)
                    {
                        if (c.Organisatie.ID == o.ID)
                            temp.Add(c);
                    }
                    lCon = temp;
                }

            if (f != null)
                if (f.ID != 0)
                {
                    ObservableCollection<Contact> temp = new ObservableCollection<Contact>();
                    foreach (Contact c in lCon)
                    {
                        if (c.Functie.ID == f.ID)
                            temp.Add(c);
                    }
                    lCon = temp;
                }

            return lCon;
        }

    }
}
