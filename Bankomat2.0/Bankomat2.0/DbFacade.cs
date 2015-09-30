using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bankomat2._0
{
    public class DbFacade
    {
        private static DbFacade instance = null;
        private const string connectionString = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = Banks; Integrated Security = SSPI";

        // lol
        public DbFacade()
        {

        }

        public static DbFacade GetInstance()
        {
            if (instance == null)
            {
                instance = new DbFacade();
            }

            return instance;
        }

        public List<List<object>> CustomerData()
        {
            List<List<object>> results = new List<List<object>>();


            // Customers
            List<object> customers = new List<object>();

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connectionString;
            myConnection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandText = $"SELECT Ssn, FirstName, LastName FROM Customer";

            var result = myCommand.ExecuteReader();

            using (result)
            {
                while (result.Read())
                {
                    string ssn = (string)result["Ssn"];
                    string fname = (string)result["FirstName"];
                    string lname = (string)result["LastName"];

                    Customer c = new Customer(ssn, fname, lname);
                    customers.Add(c);
                }
            }

            myConnection.Close();

            // Accounts
            List<object> accounts = new List<object>();

            SqlConnection conn2 = new SqlConnection();
            conn2.ConnectionString = connectionString;
            conn2.Open();
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = conn2;
            cmd2.CommandText = $"SELECT AccountNumber, Holder FROM Account";

            var result2 = cmd2.ExecuteReader();

            using (result2)
            {
                while (result2.Read())
                {
                    string number = result2["AccountNumber"].ToString();
                    string holderSsn = (string)result2["Holder"];
                    Customer c = null;

                    foreach (Customer customer in customers)
                    {
                        if (customer.Ssn == holderSsn)
                        {
                            c = customer;
                        }
                    }

                    Account a = new Account(number, c);
                    accounts.Add(a);
                }
            }

            conn2.Close();


            // PaymentCards
            List<object> paymentCards = new List<object>();

            SqlConnection conn3 = new SqlConnection();
            conn3.ConnectionString = connectionString;
            conn3.Open();
            SqlCommand cmd3 = new SqlCommand();
            cmd3.Connection = conn3;
            cmd3.CommandText = $"SELECT Pin, CardNumber, Holder, PrimaryAccount FROM PaymentCard";

            var result3 = cmd3.ExecuteReader();

            using (result3)
            {
                while (result3.Read())
                {
                    string cardNumber = (string)result3["CardNumber"];
                    int pin = (int)result3["Pin"];
                    string holderSsn = (string)result3["Holder"];
                    string account = result3["PrimaryAccount"].ToString();
                    Customer c = null;
                    Account a = null;

                    foreach (Customer customer in customers)
                    {
                        if (customer.Ssn == holderSsn)
                        {
                            c = customer;
                        }
                    }

                    foreach (Account acc in accounts)
                    {
                        if (acc.Number == cardNumber)
                        {
                            a = acc;
                        }
                    }

                    PaymentCard pc = new PaymentCard(pin, cardNumber, c, a);
                    paymentCards.Add(pc);
                }
            }

            conn3.Close();

            // Adds the dictionarys to the list
            results.Add(customers);
            results.Add(accounts);
            results.Add(paymentCards);

            return results;
        }

        public void RegisterAuth(int pin, bool outcome, int clientId, string cardNumber, string bic)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connectionString;

            myConnection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.CommandText = $"sp_RegisterAuthentification";

            myCommand.Parameters.Add("@Pin", SqlDbType.Int);
            myCommand.Parameters.Add("@Outcome", SqlDbType.Bit);
            myCommand.Parameters.Add("@Client", SqlDbType.Int);
            myCommand.Parameters.Add("@PaymentCard", SqlDbType.VarChar);
            myCommand.Parameters.Add("@Bank", SqlDbType.VarChar);

            myCommand.Parameters["@Pin"].Value = pin;
            myCommand.Parameters["@Outcome"].Value = outcome;
            myCommand.Parameters["@Client"].Value = clientId;
            myCommand.Parameters["@PaymentCard"].Value = cardNumber;
            myCommand.Parameters["@Bank"].Value = bic;

            myCommand.ExecuteNonQuery();
        }

        public void RegisterBalanceAccess(string account, int clientId, string cardNumber, string bic)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connectionString;

            myConnection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.CommandText = $"sp_RegisterBalanceAccess";

            myCommand.Parameters.Add("@Account", SqlDbType.Int);
            myCommand.Parameters.Add("@Client", SqlDbType.Int);
            myCommand.Parameters.Add("@PaymentCard", SqlDbType.VarChar);
            myCommand.Parameters.Add("@Bank", SqlDbType.VarChar);

            myCommand.Parameters["@Account"].Value = Convert.ToInt32(account);
            myCommand.Parameters["@Client"].Value = clientId;
            myCommand.Parameters["@PaymentCard"].Value = cardNumber;
            myCommand.Parameters["@Bank"].Value = bic;

            myCommand.ExecuteNonQuery();
        }

        public void RegisterTransactionAccess(string transaction, int clientId, string cardNumber, string bic)
        {
            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connectionString;

            myConnection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.CommandText = $"sp_RegisterTransactionAccess";

            myCommand.Parameters.Add("@Transaction", SqlDbType.Int);
            myCommand.Parameters.Add("@Client", SqlDbType.Int);
            myCommand.Parameters.Add("@PaymentCard", SqlDbType.VarChar);
            myCommand.Parameters.Add("@Bank", SqlDbType.VarChar);

            myCommand.Parameters["@Transaction"].Value = Convert.ToInt32(transaction);
            myCommand.Parameters["@Client"].Value = clientId;
            myCommand.Parameters["@PaymentCard"].Value = cardNumber;
            myCommand.Parameters["@Bank"].Value = bic;

            myCommand.ExecuteNonQuery();
        }

        public List<Transaction> Transactions(string account)
        {
            List<Transaction> results = new List<Transaction>();

            //SqlConnection myConnection = new SqlConnection();
            //myConnection.ConnectionString = connectionString;

            //myConnection.Open();
            //SqlCommand myCommand = new SqlCommand();
            //myCommand.Connection = myConnection;
            //myCommand.CommandType = CommandType.StoredProcedure;

            //myCommand.CommandText = $"sp_GetTransactions";

            //// params
            //myCommand.Parameters.Add("@Account", SqlDbType.Int);
            //myCommand.Parameters["@Account"].Value = Convert.ToInt32(account);

            //// Output
            //myCommand.Parameters.Add("@Amount", SqlDbType.Decimal);
            //myCommand.Parameters["@Amount"].Direction = ParameterDirection.Output;
            //myCommand.Parameters.Add("@TransactionTime", SqlDbType.DateTime);
            //myCommand.Parameters["@TransactionTime"].Direction = ParameterDirection.Output;

            //var result = myCommand.ExecuteReader();

            //using (result)
            //{
            //    while (result.Read())
            //    {
            //        decimal amount = Decimal.Parse(result["Amount"].ToString());
            //        DateTime time = DateTime.Parse(result["TransactionTime"].ToString());

            //        Transaction t = new Transaction(amount, time);
            //        results.Add(t);
            //    }
            //}

            return results;


            //List<Transaction> results = new List<Transaction>();

            //SqlConnection myConnection = new SqlConnection();
            //myConnection.ConnectionString = connectionString;
            //myConnection.Open();
            //SqlCommand myCommand = new SqlCommand();
            //myCommand.Connection = myConnection;
            //myCommand.CommandText = $"SELECT Amount, TransactionTime FROM AccountTransaction WHERE Account = {accountNumber}";

            //var result = myCommand.ExecuteReader();

            //using (result)
            //{
            //    while (result.Read())
            //    {
            //        decimal amount = Decimal.Parse(result["Amount"].ToString());
            //        DateTime time = DateTime.Parse(result["TransactionTime"].ToString());

            //        Transaction t = new Transaction(amount, time);
            //        results.Add(t);
            //    }
            //}

            //return results;
        }

        public DateTime MakeTransaction(string account, decimal amount, bool outcome, int client, string cardNumber, string bank)
        {
            DateTime dt = new DateTime();

            SqlConnection myConnection = new SqlConnection();
            myConnection.ConnectionString = connectionString;

            myConnection.Open();
            SqlCommand myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.StoredProcedure;

            myCommand.CommandText = $"sp_MakeTransaction";

            myCommand.Parameters.Add("@Account", SqlDbType.Int);
            myCommand.Parameters.Add("@Amount", SqlDbType.Decimal);
            myCommand.Parameters.Add("@Outcome", SqlDbType.Bit);
            myCommand.Parameters.Add("@Client", SqlDbType.Int);
            myCommand.Parameters.Add("@PaymentCard", SqlDbType.VarChar);
            myCommand.Parameters.Add("@Bank", SqlDbType.VarChar);

            myCommand.Parameters["@Account"].Value = account;
            myCommand.Parameters["@Amount"].Value = amount;
            myCommand.Parameters["@Outcome"].Value = outcome;
            myCommand.Parameters["@Client"].Value = client;
            myCommand.Parameters["@PaymentCard"].Value = cardNumber;
            myCommand.Parameters["@Bank"].Value = bank;


            myCommand.Parameters.Add("@Time", SqlDbType.DateTime);
            myCommand.Parameters["@Time"].Direction = ParameterDirection.Output;

            myCommand.ExecuteNonQuery();

            dt = DateTime.Parse(myCommand.Parameters["@Time"].Value.ToString());


            return dt;
        }
    }
}