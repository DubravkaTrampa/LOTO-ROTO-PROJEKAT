using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LotoRotoProjekat
{
    public partial class MasterStrana : System.Web.UI.MasterPage
    {
        public ContentPlaceHolder placeHolderDropdown; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["tip_korisnika"]!= null)
            {
                if(Session["tip_korisnika"].ToString() == "admin")
                {
                    placeholderAdminDropdown.Visible = true;
                }
            }
            //Id racuna admina i fonda se cuvaju u sesiji, posto imamo samo po jedan racun za oba
            //pa nije potrebna logika trazenja po nekakvim kriterijumima / upitima
            Session["admin_racun_id"] = 4;
            Session["humanitarni_fond_racun_id"] = 3;

        }
    }
}