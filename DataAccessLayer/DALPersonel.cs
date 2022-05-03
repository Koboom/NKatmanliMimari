using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class DALPersonel
    {
        public static List<EntityPersonel> Personellistesi()
        {
            List<EntityPersonel> degerler = new List<EntityPersonel>();
            SqlCommand komut1 = new SqlCommand("Select * from TBLBILGI", Baglanti.bgl);

            if(komut1.Connection.State!=ConnectionState.Open)
            {
                komut1.Connection.Open();
            }
            SqlDataReader dr = komut1.ExecuteReader();
            while(dr.Read())
            {
                EntityPersonel ent = new EntityPersonel();
                ent.Id = int.Parse(dr["ID"].ToString());
                ent.Ad = dr["AD"].ToString();
                ent.Soyad = dr["SOYAD"].ToString();
                ent.Gorev = dr["GOREV"].ToString();
                ent.Sehir = dr["SEHIR"].ToString();
                ent.Maas = short.Parse(dr["MAAS"].ToString());
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;            
        }

        public static int PersonelEkle(EntityPersonel p)//PersonelEkle ismini biz verdik
                    //EntityLayer içindeki EntityPersonel içinden çağırmak için bu komutu yazıyoruz.p yi biz verdik.
        {
            SqlCommand komut2 = new SqlCommand("insert into TBLBILGI (AD,SOYAD,GOREV,SEHIR,MAAS) values (@p1,@p2,@p3,@p4,@p5)", Baglanti.bgl);
                // ganz normal SQL komutları
            if (komut2.Connection.State != ConnectionState.Open)// doğruluğunu kanıtlayan LL komutları için yazdık
            {
                komut2.Connection.Open();
            }
            komut2.Parameters.AddWithValue("@p1", p.Ad);// entitiPersonel den Ad çağırıyoruz.
            komut2.Parameters.AddWithValue("@p2", p.Soyad);
            komut2.Parameters.AddWithValue("@p3", p.Gorev);
            komut2.Parameters.AddWithValue("@p4", p.Sehir);
            komut2.Parameters.AddWithValue("@p5", p.Maas);
            return komut2.ExecuteNonQuery();//kapatma işleminde return yapıyoruz.
        }

    }
}
