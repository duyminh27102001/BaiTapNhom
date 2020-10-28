using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WingtipToys.Logic;

namespace WingtipToys
{
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["ProductId"];
            int productId;
            if(!string.IsNullOrEmpty(rawId)&& int.TryParse(rawId,out productId))
            {
                using(ShoppingCartActions userShoppingCart=new ShoppingCartActions())
                {
                    userShoppingCart.AddToCart(Convert.ToInt32(rawId));
                }
            }
            else
            {
                Debug.Fail("Erro");
                throw new Exception("NOooooo");
            }
            Response.Redirect("ShoppingCart.aspx");
        }
    }
}