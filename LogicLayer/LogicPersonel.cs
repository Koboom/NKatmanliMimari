using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using EntityLayer;

namespace LogicLayer
{
    public class LogicPersonel
    {
        public static List<EntityPersonel> LLPersonelListesi() //LLPersonelListesi diye nesne türetiyoruz.
        {
            return DALPersonel.Personellistesi();// bu listeyi diğer katmandan çağırıyoruz.
        }

        public static int LLPersonelEkle(EntityPersonel p)//
        {
            if(p.Ad!="" && p.Soyad!=""&& p.Maas>=3500 &&p.Ad.Length>=3)//eğer p.Ad farklıysa boşluktan.
                                //p.Soyad farklıysa yani kısaca bu şartların doğruluğu sağlanıyorsa
            {
                return DALPersonel.PersonelEkle(p);//Dalpersoneldeki Personel ekle medodunu döndür bunun içine de p den 
                                //gelen değerleri ekle.
            }
            else
            {
                return -1;//sağlamıyorsa hiç birşey yapma. 
            }
        }
    }
}
