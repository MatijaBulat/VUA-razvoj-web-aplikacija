using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Repo
    {
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;

        public static IEnumerable<Kupac> GetKupci()
        {
            //DataSet ds = SqlHelper.ExecuteDataset(cs, "GetKupci"); 
            //foreach (DataRow row in ds.Tables[0].Rows)
            //{
            //    yield return GetKupacFromDataRow(row);

            List<Kupac> list = new List<Kupac>();

            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetKupci");
            list.AddRange(from DataRow row in ds.Tables[0].Rows
                          select GetKupacFromDataRow(row));
            return list;
        }

        private static Kupac GetKupacFromDataRow(DataRow row)
        {
            return new Kupac
            {
                IDKupac = (int)row["IDKupac"],
                Ime = row["Ime"].ToString(),
                Prezime = row["Prezime"].ToString(),
                Email = row["Email"].ToString(),
                Telefon = row["Telefon"].ToString(),
                GradID = row["GradID"] != DBNull.Value ? (int)row["GradID"] : 1,
                Grad = GetGrad((int)row["GradID"])
            };
        }

        public static Kupac GetKupac(int IDKupac)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetKupac", IDKupac).Tables[0].Rows[0];
            return GetKupacFromDataRow(row);
        }

        public static Grad GetGrad(int IDGrad)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetGrad", IDGrad).Tables[0].Rows[0];
            return GetGradFromDataRow(row);
        }

        private static Grad GetGradFromDataRow(DataRow row)
        {
            return new Grad
            {
                IDGrad = (int)row["IDGrad"],
                Naziv = row["Naziv"].ToString(),
                DrzavaID = row["DrzavaID"] != DBNull.Value ? (int)row["DrzavaID"] : 1,
                Drzava = GetDrzava((int)row["DrzavaID"])
            };
        }

        public static IEnumerable<Grad> GetGradovi()
        {
            List<Grad> list = new List<Grad>();

            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetGradovi");
            list.AddRange(from DataRow row in ds.Tables[0].Rows
                          select GetGradFromDataRow(row));
            return list;
        }

        public static Drzava GetDrzava(int IDDrzava)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetDrzava", IDDrzava).Tables[0].Rows[0];
            return GetDrzavaFromDataRow(row);
        }

        private static Drzava GetDrzavaFromDataRow(DataRow row)
        {
            return new Drzava
            {
                IDDrzava = (int)row["IDDrzava"],
                Naziv = row["Naziv"].ToString()
            };
        }

        public static IEnumerable<Drzava> GetDrzave()
        {
            List<Drzava> list = new List<Drzava>();

            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetDrzave");
            list.AddRange(from DataRow row in ds.Tables[0].Rows
                          select GetDrzavaFromDataRow(row));
            return list;
        }

        public static IEnumerable<Grad> GetGradoviDrzave(int IDDrzava)
        {
            List<Grad> list = new List<Grad>();

            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetGradoviDrzave", IDDrzava);
            list.AddRange(from DataRow row in ds.Tables[0].Rows
                          select GetGradFromDataRow(row));
            return list;
        }

        public static IEnumerable<Proizvod> GetProizvodi()
        {
            List<Proizvod> list = new List<Proizvod>();

            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetProizvodi");
            list.AddRange(from DataRow row in ds.Tables[0].Rows
                          select GetProizvodFromDataRow(row));
            return list;
        }

        private static Proizvod GetProizvodFromDataRow(DataRow row)
        {
            //int result;
            //var potkategorija = int.TryParse(row["PotkategorijaID"].ToString(), out result) ? GetPotkategorija(result) : GetPotkategorija(0);
            return new Proizvod
            {
                IDProizvod = (int)row["IDProizvod"],
                Naziv = row["Naziv"].ToString(),
                Boja = DBNull.Value.Equals(row["Boja"]) ? "Nedefinirano" : row["Boja"].ToString(),
                BrojProizvoda = row["BrojProizvoda"].ToString(),
                MinimalnaKolicinaNaSkladistu = int.Parse(row["MinimalnaKolicinaNaSkladistu"].ToString()),
                CijenaBezPDV = double.Parse(row["CijenaBezPDV"].ToString()),
                Potkategorija = DBNull.Value.Equals(row["PotkategorijaID"]) ?
                                new Potkategorija { Naziv = "Nedefinirano" } : GetPotkategorija(int.Parse(row["PotkategorijaID"].ToString()))
            };
        }

        public static Proizvod GetProizvod(int IDProizvod)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetProizvod", IDProizvod).Tables[0].Rows[0];
            return GetProizvodFromDataRow(row);
        }

        public static Potkategorija GetPotkategorija(int IDPotkategorija)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetPotkategorija", IDPotkategorija).Tables[0].Rows[0];
            return GetPotkategorijaFromDataRow(row);
        }

        private static Potkategorija GetPotkategorijaFromDataRow(DataRow row)
        {
            return new Potkategorija
            {
                IDPotkategorija = (int)row["IDPotkategorija"],
                Naziv = row["Naziv"].ToString(),
                Kategorija = GetKategorija((int)row["KategorijaID"]),
                KategorijaID = row["KategorijaID"] != DBNull.Value ? (int)row["KategorijaID"] : 1
            };
        }

        public static IEnumerable<Potkategorija> GetPotkategorije()
        {
            List<Potkategorija> list = new List<Potkategorija>();

            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetPotkategorije");
            list.AddRange(from DataRow row in ds.Tables[0].Rows
                          select GetPotkategorijaFromDataRow(row));
            return list;
        }

        public static Kategorija GetKategorija(int IDKategorija)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetKategorija", IDKategorija).Tables[0].Rows[0];
            return GetKategorijaFromDataRow(row);
        }

        private static Kategorija GetKategorijaFromDataRow(DataRow row)
        {
            return new Kategorija
            {
                IDKategorija = (int)row["IDKategorija"],
                Naziv = row["Naziv"].ToString()
            };
        }

        public static IEnumerable<Kategorija> GetKategorije()
        {
            List<Kategorija> list = new List<Kategorija>();

            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetKategorije");
            list.AddRange(from DataRow row in ds.Tables[0].Rows
                          select GetKategorijaFromDataRow(row));
            return list;
        }

        public static Racun GetRacun(int IDRacun)
        {
            DataRow row = SqlHelper.ExecuteDataset(cs, "GetRacun", IDRacun).Tables[0].Rows[0];
            return GetRacunFromDataRow(row);
        }

        private static Racun GetRacunFromDataRow(DataRow row)
        {
            Racun r = new Racun();

            r.IDRacun = (int)row["IDRacun"];
            r.DatumIzdavanja = Convert.ToDateTime(row["DatumIzdavanja"].ToString());
            r.BrojRacuna = row["BrojRacuna"].ToString();
            r.KupacID = (int)row["KupacID"];
            r.KomercijalistID = DBNull.Value.Equals(row["KomercijalistID"]) ? 0 : Convert.ToInt32(row["KomercijalistID"]);
            r.Komercijalist = r.KomercijalistID == 0 ? null : GetKomercijalist((int)row["KomercijalistID"]);
            r.Komentar = DBNull.Value.Equals(row["Komentar"].ToString()) ? "Nema komentara" : row["Komentar"].ToString();
            r.KreditnaKarticaID = DBNull.Value.Equals(row["KreditnaKarticaID"]) ? 0 : Convert.ToInt32(row["KreditnaKarticaID"]);
            r.KreditnaKartica = r.KreditnaKarticaID == 0 ? null : GetKreditnaKartica((int)row["KreditnaKarticaID"]);

            return r;
        }

        public static Komercijalist GetKomercijalist(int IDKomercijalist)
        {
            if (IDKomercijalist != 0)
            {
                DataRow row = SqlHelper.ExecuteDataset(cs, "GetKomercijalist", IDKomercijalist).Tables[0].Rows[0];
                return GetKomercijalistFromDataRow(row);
            }
            else
            {
                return null;
            }
        }

        public static Komercijalist GetKomercijalistFromDataRow(DataRow row)
        {
            return new Komercijalist
            {
                IDKomercijalist = (int)row["IDKomercijalist"],
                Ime = row["Ime"].ToString(),
                Prezime = row["Prezime"].ToString()
            };
        }

        public static KreditnaKartica GetKreditnaKartica(int IDKreditnaKartica)
        {
            if (IDKreditnaKartica == 0 || DBNull.Value.Equals(IDKreditnaKartica))
            {
                return new KreditnaKartica
                {
                    Tip = "Nije plaćeno kreditnom karticom"
                };
            }
            else
            {
                DataRow row = SqlHelper.ExecuteDataset(cs, "GetKreditnaKartica", IDKreditnaKartica).Tables[0].Rows[0];
                return GetKreditnaKarticaFromDataRow(row);
            }
        }

        public static KreditnaKartica GetKreditnaKarticaFromDataRow(DataRow row)
        {
            return new KreditnaKartica
            {
                IDKreditnaKartica = (int)row["IDKreditnaKartica"],
                Tip = row["Tip"].ToString(),
                IstekMjesec = int.Parse(row["IstekMjesec"].ToString()),
                IstekGodina = int.Parse(row["IstekGodina"].ToString())
            };
        }

        public static IEnumerable<Racun> GetRacuniKupca(int IDKupac)
        {
            List<Racun> list = new List<Racun>();

            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetRacuniKupca", IDKupac);
            list.AddRange(from DataRow row in ds.Tables[0].Rows
                          select GetRacunFromDataRow(row));
            return list;
        }

        public static IEnumerable<Stavka> GetStavkeRacuna(int IDRacun)
        {
            List<Stavka> list = new List<Stavka>();

            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetStavkeRacuna", IDRacun);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                list.Add(GetStavkaFromDataRow(row));
            }
            return list;
        }

        public static Stavka GetStavkaFromDataRow(DataRow row)
        {
            return new Stavka
            {
                IDStavka = (int)row["IDStavka"],
                RacunID = (int)row["RacunID"],
                Racun = GetRacun((int)row["RacunID"]),
                Kolicina = int.Parse(row["Kolicina"].ToString()),
                CijenaPoKomadu = double.Parse(row["CijenaPoKomadu"].ToString()),
                ProizvodID = row["ProizvodID"] != DBNull.Value ? (int)row["ProizvodID"] : 1,
                Proizvod = GetProizvod((int)row["ProizvodID"]),
                PopustUPostocima = double.Parse(row["PopustUPostocima"].ToString()),
                UkupnaCijena = double.Parse(row["UkupnaCijena"].ToString())
            };
        }

        public static IEnumerable<string> GetBoje()
        {
            List<string> list = new List<string>();

            DataSet ds = SqlHelper.ExecuteDataset(cs, "GetPiture");
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                if (DBNull.Value.Equals(row["Boja"]))
                {
                    list.Add("Nedefinirano");
                }
                else
                {
                    list.Add(row["Boja"].ToString());
                }
            }
            return list;
        }

        //KupacCRUD
        public static void CreateKupac(Kupac k) => SqlHelper.ExecuteNonQuery(cs, "InsertKupac", k.Ime, k.Prezime, k.Email, k.Telefon, k.GradID);
        public static void UpdateKupac(Kupac k) => SqlHelper.ExecuteNonQuery(cs, "UpdateKupac", k.IDKupac, k.Ime, k.Prezime, k.Email, k.Telefon, k.GradID);
        public static void DeleteKupac(int IDKupac) => SqlHelper.ExecuteNonQuery(cs, "DeleteKupac", IDKupac);

        //ProizvodCRUD
        public static void CreateProizvod(Proizvod p) => SqlHelper.ExecuteNonQuery(cs, "InsertProizvod", p.Naziv, p.BrojProizvoda, p.Boja, p.MinimalnaKolicinaNaSkladistu, p.CijenaBezPDV, p.PotkategorijaID);
        public static void UpdateProizvod(Proizvod p) => SqlHelper.ExecuteNonQuery(cs, "UpdateProizvod", p.IDProizvod, p.Naziv, p.BrojProizvoda, p.Boja, p.MinimalnaKolicinaNaSkladistu, p.CijenaBezPDV, p.PotkategorijaID);
        public static void DeleteProizvod(int IDProizvod) => SqlHelper.ExecuteNonQuery(cs, "DeleteProizvod", IDProizvod);

        //KategorijaCRUD
        public static void CreateKategorija(Kategorija k) => SqlHelper.ExecuteNonQuery(cs, "InsertKategorija", k.Naziv);
        public static void UpdateKategorija(Kategorija k) => SqlHelper.ExecuteNonQuery(cs, "UpdateKategorija", k.IDKategorija, k.Naziv);
        public static void DeleteKategorija(int IDKategorija) => SqlHelper.ExecuteNonQuery(cs, "DeleteKategorija", IDKategorija);

        //PotkategorijaCRUD
        public static void CreatePotategorija(Potkategorija p) => SqlHelper.ExecuteNonQuery(cs, "InsertPotkategorija", p.Naziv, p.KategorijaID);
        public static void UpdatePotkategorija(Potkategorija p) => SqlHelper.ExecuteNonQuery(cs, "UpdatePotkategorija", p.IDPotkategorija, p.Naziv, p.KategorijaID);
        public static void DeletePotkategorija(int IDPotkategorija) => SqlHelper.ExecuteNonQuery(cs, "DeletePotkategorija", IDPotkategorija);
    }
}