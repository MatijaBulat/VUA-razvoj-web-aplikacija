using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVC
{
    public partial class KupacEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var kupac = (Kupac)Session["kupac"];
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Account/Login");
            }
            else if (HttpContext.Current.User.Identity.IsAuthenticated && Session["kupac"] == null)
            {
                Response.Redirect("/Home/Index");
            }
            else
            {
                if (!IsPostBack)
                {

                    ShowData(kupac);
                }
            }
        }

        private void ShowData(Kupac kupac)
        {
            PopulateDdlDrzave();
            PopulateDdlGradovi();

            tbIme.Text = kupac.Ime;
            tbPrezime.Text = kupac.Prezime;
            tbEmail.Text = kupac.Email;
            tbTelefon.Text = kupac.Telefon;
            ddlDrzave.SelectedValue = kupac.Grad.DrzavaID.ToString();
            PopulateDdlGradovi();
            ddlGradovi.SelectedValue = kupac.GradID.ToString();
        }

        private void PopulateDdlDrzave()
        {
            foreach (var drzava in Repo.GetDrzave())
            {
                ddlDrzave.Items.Add(new ListItem(drzava.Naziv, drzava.IDDrzava.ToString()));
            }
        }

        private void PopulateDdlGradovi()
        {
            ddlGradovi.Items.Clear();

            foreach (var grad in Repo.GetGradoviDrzave(int.Parse(ddlDrzave.SelectedValue)))
            {
                ddlGradovi.Items.Add(new ListItem(grad.Naziv, grad.IDGrad.ToString()));
            }
        }

        protected void ddlDrzave_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDdlGradovi();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ModelState.IsValid)
            {
                var k = (Kupac)Session["kupac"];
                Kupac kupac = new Kupac
                {
                    IDKupac = k.IDKupac,
                    Ime = tbIme.Text,
                    Prezime = tbPrezime.Text,
                    Email = tbEmail.Text,
                    Telefon = tbTelefon.Text,
                    GradID = int.Parse(ddlGradovi.SelectedValue)
                };

                Repo.UpdateKupac(kupac);
                Response.Redirect("Kupac/Index");
                Session.Clear();
            }
            ThrowError();
        }
        private void ThrowError()
        {
            lbError.Visible = true;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Kupac/Index");
            Session.Clear();
        }
    }
}