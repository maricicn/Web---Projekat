using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Web___Projekat
{
    public class AutoMehanicar
    {
        SqlConnection conn = new SqlConnection();
        string webConfig = ConfigurationManager.ConnectionStrings["AutoMehanicar"].ConnectionString;
        SqlCommand comm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet();

        public int Provera_Korisnika(string email, string lozinka)
        {
            conn.ConnectionString = webConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Vlasnik_Email";

            comm.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, email));
            comm.Parameters.Add(new SqlParameter("@loz", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, lozinka));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }

            return rezultat;
        }
        public int Unos_Usluga(string naziv, int cena, DateTime datum_p, DateTime datum_z)
        {
            conn.ConnectionString = webConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Usluga_Insert";

            comm.Parameters.Add(new SqlParameter("@naziv", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, naziv));
            comm.Parameters.Add(new SqlParameter("@cena", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, cena));
            comm.Parameters.Add(new SqlParameter("@datum_pocetka", SqlDbType.DateTime, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, datum_p));
            comm.Parameters.Add(new SqlParameter("@datum_zavrsetka", SqlDbType.DateTime, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, datum_z));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));
            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }

            return rezultat;
        }
        public int Unos_Zaposlenog(string ime, string prezime, string jmbg, int plata, string usluga_id)
        {
            conn.ConnectionString = webConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Zaposleni_Insert";

            comm.Parameters.Add(new SqlParameter("@ime", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ime));
            comm.Parameters.Add(new SqlParameter("@prezime", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, prezime));
            comm.Parameters.Add(new SqlParameter("@jmbg", SqlDbType.NVarChar, 13, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, jmbg));
            comm.Parameters.Add(new SqlParameter("@plata", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, plata));
            comm.Parameters.Add(new SqlParameter("@usluga_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, usluga_id));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }

            return rezultat;
        }
        public int Unos_Vlasnika(string ime, string prezime, string email, string lozinka, string jmbg)
        {
            conn.ConnectionString = webConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Vlasnik_Insert";

            comm.Parameters.Add(new SqlParameter("@ime", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ime));
            comm.Parameters.Add(new SqlParameter("@prezime", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, prezime));
            comm.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, email));
            comm.Parameters.Add(new SqlParameter("@loz", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, lozinka));
            comm.Parameters.Add(new SqlParameter("@jmbg", SqlDbType.NVarChar, 13, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, jmbg));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }

            return rezultat;
        }
        public int Unos_Automobila(string marka, string registracija, string usluga_id)
        {
            conn.ConnectionString = webConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Auto_Insert";

            comm.Parameters.Add(new SqlParameter("@marka", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, marka));
            comm.Parameters.Add(new SqlParameter("@registracija", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, registracija));
            comm.Parameters.Add(new SqlParameter("@usluga_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, usluga_id));
            comm.Parameters.Add(new SqlParameter("@vlasnik_id", SqlDbType.Int) { Value = DBNull.Value });
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }

            return rezultat;
        }
        public int Obrisi_Uslugu(string id)
        {
            conn.ConnectionString = webConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "UslugaDelete";

            comm.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }

            return rezultat;
        }
        public int Obrisi_Zaposlenog(string id)
        {
            conn.ConnectionString = webConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "ZaposleniDelete";

            comm.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }

            return rezultat;
        }
        public int Obrisi_Vlasnika(string email)
        {
            conn.ConnectionString = webConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Vlasnik_Delete";

            comm.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, email));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }

            return rezultat;
        }
        public int Obrisi_Automobil(string id)
        {
            conn.ConnectionString = webConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "AutoDelete";

            comm.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }

            return rezultat;
        }
        public DataSet Vlasnik_Info(string email)
        {
            conn.ConnectionString = webConfig;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Vlasnik_Info";
            comm.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, email));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            da.SelectCommand = comm;
            da.Fill(ds);

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return (ds);
        }
        public DataSet Usluga_Info(string id)
        {
            conn.ConnectionString = webConfig;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Usluga_Info";
            comm.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            da.SelectCommand = comm;
            da.Fill(ds);

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return (ds);
        }

        public DataSet Auto_Info(string id)
        {
            conn.ConnectionString = webConfig;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Auto_Info";
            comm.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            da.SelectCommand = comm;
            da.Fill(ds);

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return (ds);
        }
        public DataSet Zaposleni_Info(string id)
        {
            conn.ConnectionString = webConfig;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Zaposleni_Info";
            comm.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, id));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            da.SelectCommand = comm;
            da.Fill(ds);

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return (ds);
        }
        public int Izmeni_Usluga(string usluga_id, string naziv, int cena, DateTime datum_p, DateTime datum_z)
        {
            conn.ConnectionString = webConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Usluga_Update";
            comm.Parameters.Add(new SqlParameter("@usluga_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, usluga_id));
            comm.Parameters.Add(new SqlParameter("@naziv", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, naziv));
            comm.Parameters.Add(new SqlParameter("@cena", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, cena));
            comm.Parameters.Add(new SqlParameter("@datum_pocetka", SqlDbType.DateTime, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, datum_p));
            comm.Parameters.Add(new SqlParameter("@datum_zavrsetka", SqlDbType.DateTime, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, datum_z));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }

            return rezultat;
        }
        public int Izmeni_Vlasnik(string ime, string prezime, string email, string lozinka, string jmbg)
        {
            conn.ConnectionString = webConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Vlasnik_Update";
            comm.Parameters.Add(new SqlParameter("@ime", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ime));
            comm.Parameters.Add(new SqlParameter("@prezime", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, prezime));
            comm.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, email));
            comm.Parameters.Add(new SqlParameter("@loz", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, lozinka));
            comm.Parameters.Add(new SqlParameter("@jmbg", SqlDbType.NVarChar, 13, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, jmbg));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }

            return rezultat;
        }
        public int Izmeni_Zaposlenog(string zaposleni_id, string ime, string prezime, string jmbg, int plata, string usluga_id)
        {
            conn.ConnectionString = webConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Zaposleni_Update";
            comm.Parameters.Add(new SqlParameter("@zaposleni_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, zaposleni_id));
            comm.Parameters.Add(new SqlParameter("@ime", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, ime));
            comm.Parameters.Add(new SqlParameter("@prezime", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, prezime));
            comm.Parameters.Add(new SqlParameter("@jmbg", SqlDbType.NVarChar, 13, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, jmbg));
            comm.Parameters.Add(new SqlParameter("@plata", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, plata));
            comm.Parameters.Add(new SqlParameter("@usluga_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, usluga_id));
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }

            return rezultat;
        }
        public int Izmeni_Automobil(string auto_id, string marka, string registracija, string usluga_id)
        {
            conn.ConnectionString = webConfig;
            int rezultat;

            comm.Connection = conn;
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = "Auto_Update";

            comm.Parameters.Add(new SqlParameter("@auto_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, auto_id));
            comm.Parameters.Add(new SqlParameter("@marka", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, marka));
            comm.Parameters.Add(new SqlParameter("@registracija", SqlDbType.NVarChar, 50, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, registracija));
            comm.Parameters.Add(new SqlParameter("@usluga_id", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Current, usluga_id));
            comm.Parameters.Add(new SqlParameter("@vlasnik_id", SqlDbType.Int) { Value = DBNull.Value });
            comm.Parameters.Add(new SqlParameter("@RETURN_VALUE", SqlDbType.Int, 4, ParameterDirection.ReturnValue, true, 0, 0, "", DataRowVersion.Current, null));

            conn.Open();
            comm.ExecuteNonQuery();
            conn.Close();

            int Ret;
            Ret = (int)comm.Parameters["@RETURN_VALUE"].Value;
            if (Ret == 0)
            {
                rezultat = 0;
            }
            else
            {
                rezultat = 1;
            }

            return rezultat;
        }

    }
}