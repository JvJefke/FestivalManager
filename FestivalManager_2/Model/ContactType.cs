﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FestivalManager_2.Model
{
    class ContactType
    {
        public int ID { get; set; }
        public string Naam { get; set; }

        internal static ContactType GetContactTypeFromID(int p)
        {
            throw new NotImplementedException();
        }
    }
}
