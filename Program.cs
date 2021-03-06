using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _20200140018_Tugas2_A
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pg = new Program();
            pg.CreateTabel();
        }

        public void CreateTabel()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=DESKTOP-4U0SN21\\ABIDAKBAR;DATABASE=DB_Mall;Integrated Security = TRUE");
                con.Open();


                //membuuat Table
                SqlCommand cm = new SqlCommand("create table Penyewa (Kode_Penyewa char(5) not null primary key, Nama_Penyewa varchar(50) not null unique, Alamat_Penyewa varchar(255), No_KTP_Penyewa char(10), No_Telp_Penyewa char(12), Jenis_Kelamin char(1))"+
                                               "create table Bangunan (Kode_Bangunan char(5) not null primary key, Nama_Bangunan varchar(20) not null unique, Lokasi_Bangunan varchar(20), Harga_Bangunan_Per_Tahun int not null unique, Harga_Bangunan_Per_Bulan int not null unique)" +
                                               "create table Transaksi (Kode_Transaksi char(5) not null primary key, Kode_Penyewa char(5) FOREIGN KEY REFERENCES Penyewa (Kode_Penyewa), Nama_Penyewa varchar(50) FOREIGN KEY REFERENCES Penyewa (Nama_Penyewa), Kode_Bangunan char(5) FOREIGN KEY REFERENCES Bangunan (Kode_Bangunan), Nama_Bangunan varchar(20) FOREIGN KEY REFERENCES Bangunan (Nama_Bangunan), Harga_Bangunan_Per_Tahun int FOREIGN KEY REFERENCES Bangunan (Harga_Bangunan_Per_Tahun), Harga_Bangunan_Per_Bulan int FOREIGN KEY REFERENCES Bangunan (Harga_Bangunan_Per_Bulan))", con);
                cm.ExecuteNonQuery();

                Console.WriteLine("Tabel sukses dibuat!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Oops, Sepertinya ada yang salah. " + e);
                Console.ReadKey();
            }
            finally
            {
                con.Close();
            }

        }
    }
}

