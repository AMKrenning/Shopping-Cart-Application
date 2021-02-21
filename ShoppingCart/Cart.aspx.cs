using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ex04Cart
{
    public partial class Cart : System.Web.UI.Page
    {
        List<CartItem> cart;

        protected void Page_Load(object sender, EventArgs e)
        {
            cart = (List<CartItem>)Session["Cart"];

            if (!IsPostBack)
            {
                foreach (CartItem c in cart)
                {
                    lstCart.Items.Add(c.Display());
                }
            }
        }

        protected void btnEmpty_Click(object sender, EventArgs e)
        {
            cart.Clear();
            lstCart.Items.Clear();
        }

        protected void btnRemove_Click(object sender, EventArgs e)
        {
            if (cart.Count > 0)
            {
                if (lstCart.SelectedIndex > -1)
                {
                    cart.RemoveAt(lstCart.SelectedIndex);
                    lstCart.Items.RemoveAt(lstCart.SelectedIndex);
                }
                else
                {
                    lblMessage.Text = "Please select item to remove.";
                }
            }
        }
    }
}