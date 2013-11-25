using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FestivalManager_2.Model.DAL;
using FestivalManager_2.Model;
using System.Collections.ObjectModel;

namespace FestivalManager_2.ViewModel
{
    class ContactOverzichtVM : ObservableObject, IPage
    {

        public string Name
        {
            get { return "Overzicht"; }
        }
    }
}
