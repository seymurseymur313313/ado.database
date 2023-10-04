using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;




namespace WpfApp1
{

    class DataAccess
    {

        SqlConnection? connect = null;
        public string? bookName;
        public string? bookPrice;
        public string? bookPages;

        public string? bookName1;
        public int bookPrice1;
        public int bookPages1;


        public DataAccess()
        {


            string connectionString = @"Data Source=STHQ0124-06;Initial Catalog=Books;User ID=admin;Password=admin;Connect Timeout=30;Encrypt=False;";
            connect = new SqlConnection(connectionString);

        }


        public void insertDatabase()
        {

            connect.Open();
            string insertData = $"INSERT INTO book ( name, pages ,price) VALUES ('{bookName}' ,'{bookPages}' ,'{bookPrice}')";
            using SqlCommand cmd = new SqlCommand(insertData, connect);
            cmd.ExecuteNonQuery();


        }

        public void ShowDatabase()
        {
            SqlDataReader reader = null;
            try
            {
                connect.Open();
                using SqlCommand command = new SqlCommand("SELECT * FROM book", connect);
                reader = command.ExecuteReader();
                while (reader.Read())
                {

                    //bookName1+=(string?)reader["name"];
                    //bookPrice1+=(int)reader["price"];
                    //bookPages1+=(int)reader["pages"];
                    bookName1 += ("Name: "+(string)reader["name"]+ " " +"Price: "+ (int)reader["price"]+ " " +"Pages: " +(int)reader["pages"]+"                     ");
                  
               
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                reader.Close();
                connect.Close();
            }
        }


    }


    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataAccess access = new DataAccess();
            access = new DataAccess();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataAccess access = new DataAccess();
            access = new DataAccess();
            access.bookName = bkName.Text;
            access.bookPrice = bkPrice.Text;
            access.bookPages = bkPages.Text;
            access.insertDatabase();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataAccess access1 = new DataAccess();
            access1 = new DataAccess();
       
            access1.ShowDatabase();
            books.Text += access1.bookName1;
        }
    }


}
