using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace MyApiBook.Models
{
    public class Repository
    {
        // string connectionString = "server=localhost;user=root;password=123456;database=mybook;";
        string connectionString = null;
        public Repository(string conn)
        {
            connectionString = conn;
        }

        //  public List<Contact> Get(int id)
        //   {
        //   List<Contact> contacts = new List<Contact>();
        // using (var connection = new MySqlConnection(connectionString))
        // {
        //   contacts = connection.Query<Contact>("SELECT * FROM contacts WHERE UserId = @id", new { id }).ToList();
        //  }
        //  return contacts;
        //  }


        public List<VuewContact> ViewContact(int id)
        {
            List<VuewContact> cont;

            using (var connection = new MySqlConnection(connectionString))
            {
                // cont = connection.Query<VuewContact>("CREATE VIEW ViewContact as SELECT t1.fist_Name as Fist_Name, t2.Name as sex from contacts t1 inner join sexes t2 on t1.SexId = t2.id ").ToList();
                cont = connection.Query<VuewContact>("SELECT t1.id, t1.fist_Name as Fist_Name, t1.last_Name as Last_Name, t1.mobile_Phone as Mobile_phone, t2.Name as sex FROM contacts t1 INNER JOIN sexes t2 on t1.SexId = t2.id WHERE t1.UserId = @id ORDER BY t1.Id DESC", new { id }).ToList();
            }
            return cont;
        }

        public Contact ShowContact(int id)
        {
            if (id > 0)
            {
                Contact contact = new Contact();
                using (var connection = new MySqlConnection(connectionString))
                {
                    contact = connection.Query<Contact>("SELECT * FROM contacts WHERE Id =@id", new { id }).FirstOrDefault();
                }
                return contact;
            }
            else return null;
        }


        public void EditContact(Contact contact)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var sqlQuery = "Update contacts set fist_Name=@fist_Name, last_Name=@last_Name, mobile_Phone=@mobile_Phone, sexId=@sexId WHERE Id =@id";
                connection.Execute(sqlQuery, contact);
            }
        }

        public Contact CreateContact(Contact contact)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO contacts (Fist_Name, Last_Name, Mobile_Phone, SexId, UserId, Date_Create ) VALUES( @Fist_Name, @Last_Name, @Mobile_Phone, @sexId, @userId, NOW());";
                //после выполнение срабатывает тригер добавить запись в таблицу Logs
                connection.Query<int>(sqlQuery, contact).FirstOrDefault();
            }
            return contact;
        }

        public void DeleteContact(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM contacts WHERE Id = @id";
                connection.Execute(sqlQuery, new { id });
            }
        }

        //Модель Пол
        public List<Sex> SexList()
        {
            List<Sex> sex;

            using (var connection = new MySqlConnection(connectionString))
            {
                //хранимая процедура sexall
                sex = connection.Query<Sex>("CALL sexall").ToList();
            }
            return sex;
        }

        public List<ViewLog> LogList(GetLog getlog)
        // public DateTime LogList()
        {
            List<ViewLog> viewlog;

            DateTime n_date_begin = DateTime.Parse(getlog.Data_begin);

            DateTime n_date_end = DateTime.Parse(getlog.Data_end);
           

           

            using (var connection = new MySqlConnection(connectionString))
            {
                viewlog = connection.Query<ViewLog>("SELECT Name, login, FullDesc, date FROM viewlogs WHERE date>=@n_date_begin and date<=@n_date_end", new { n_date_begin, n_date_end }).ToList();
                // viewlog = connection.Query<ViewLog>("CALL showlogs(2021-01-01, 2021-03-01)", new { n_date_begin, n_date_end }).ToList() ;

            }
            return viewlog;
        }

        //phone
        public List<ViewPhone> PhoneList(int id)
        {
            List<ViewPhone> phone;

            using (var connection = new MySqlConnection(connectionString))
            {

                phone = connection.Query<ViewPhone>("SELECT * FROM viewphone WHERE ContactId=@id", new { id }).ToList();
            }
            return phone;
        }

        public Phone CreatePhone(Phone phone)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO phones (Num, ContactId, Phone_typeId ) VALUES( @Num, @contactId, @Phone_typeId);";
                //после выполнение срабатывает тригер добавить запись в таблицу Logs
                connection.Query<int>(sqlQuery, phone).FirstOrDefault();
            }
            return phone;
        }


    
        //phonetype
        public List<Phonetype> ListType()
        {
            List<Phonetype> type;
            using (var connection = new MySqlConnection(connectionString))
            {
               
                //после выполнение срабатывает тригер добавить запись в таблицу Logs
               type =   connection.Query<Phonetype>("SELECT * FROM phone_types").ToList();
            }
            return type;
        }

        public void DelPhone(int id)
        {

            using (var connection = new MySqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM phones WHERE Id = @id";
                connection.Execute(sqlQuery, new { id });
            }
        }

        public void EditPhone(Phone phone)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                var sqlQuery = "Update phones set Num=@Num, ContactId=@ContactId, Phone_typeId = @Phone_typeId WHERE Id =@id";
                connection.Execute(sqlQuery, phone);
            }
        }

    }
}
