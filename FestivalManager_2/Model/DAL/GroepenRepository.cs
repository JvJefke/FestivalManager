﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalManager_2.Model.DAL
{
    class GroepenRepository
    {
        public static ObservableCollection<Groep> GetGroepen()
        {
            ObservableCollection<Groep> lGroepen = new ObservableCollection<Groep>();
            string sql = "SELECT * FROM groep";

            DbDataReader reader = Database.GetData(sql);

            while (reader.Read())
            {
                lGroepen.Add(MaakFunctie(reader));
            }

            return lGroepen;
        }

        private static Groep MaakFunctie(DbDataReader reader)
        {
            Groep g = new Groep();

            g.ID = Convert.ToInt32(reader["GroepID"]);
            g.Naam = reader["Naam"].ToString();
            g.Beschrijving = reader["Beschrijving"].ToString();
            g.Image = reader["Image"].ToString();
            g.Facebook = reader["Facebook"].ToString();
            g.Twitter = reader["Twitter"].ToString();

            return g;
        }
    }
}
