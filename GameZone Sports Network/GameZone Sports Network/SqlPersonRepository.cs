using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;
using PersonData.Models;

namespace PersonData
{
   public class SqlPersonRepository : IPersonRepository
   {
      private readonly string connectionString;

      public SqlPersonRepository(string connectionString)
      {
         this.connectionString = connectionString;
      }

      public Person CreatePerson(string firstName, string lastName, string email)
      {
         // Verify parameters.
         if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("The parameter cannot be null or empty.", nameof(firstName));

         if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("The parameter cannot be null or empty.", nameof(lastName));

         if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("The parameter cannot be null or empty.", nameof(email));

         // Save to database.
         using (var transaction = new TransactionScope())
         {
            using (var connection = new SqlConnection(connectionString))
            {
               using (var command = new SqlCommand("Person.CreatePerson", connection))
               {
                  command.CommandType = CommandType.StoredProcedure;

                  command.Parameters.AddWithValue("FirstName", firstName);
                  command.Parameters.AddWithValue("LastName", lastName);
                  command.Parameters.AddWithValue("Email", email);

                  var p = command.Parameters.Add("PersonId", SqlDbType.Int);
                  p.Direction = ParameterDirection.Output;

                  connection.Open();

                  command.ExecuteNonQuery();

                  transaction.Complete();

                  var personId = (int)command.Parameters["PersonId"].Value;

                  return new Person(personId, firstName, lastName, email);
               }
            }
         }
      }

      public Person FetchPerson(int personId)
      {
         using (var connection = new SqlConnection(connectionString))
         {
            using (var command = new SqlCommand("Person.FetchPerson", connection))
            {
               command.CommandType = CommandType.StoredProcedure;

               command.Parameters.AddWithValue("PersonId", personId);

               connection.Open();

               using (var reader = command.ExecuteReader())
               {
                  var person = TranslatePerson(reader);

                  if (person == null)
                     throw new RecordNotFoundException(personId.ToString());

                  return person;
               }
            }
         }
      }

      public Person GetPerson(string email)
      {
         using (var connection = new SqlConnection(connectionString))
         {
            using (var command = new SqlCommand("Person.GetPersonByEmail", connection))
            {
               command.CommandType = CommandType.StoredProcedure;

               command.Parameters.AddWithValue("Email", email);

               connection.Open();

               using (var reader = command.ExecuteReader())
                  return TranslatePerson(reader);
            }
         }
      }

      public IReadOnlyList<Person> RetrievePersons()
      {
         using (var connection = new SqlConnection(connectionString))
         {
            using (var command = new SqlCommand("Person.RetrievePersons", connection))
            {
               command.CommandType = CommandType.StoredProcedure;

               connection.Open();

               using (var reader = command.ExecuteReader())
                  return TranslatePersons(reader);
            }
         }
      }

      private Person TranslatePerson(SqlDataReader reader)
      {
         var personIdOrdinal = reader.GetOrdinal("PersonId");
         var firstNameOrdinal = reader.GetOrdinal("FirstName");
         var lastNameOrdinal = reader.GetOrdinal("LastName");
         var emailOrdinal = reader.GetOrdinal("Email");

         if (!reader.Read())
            return null;

         return new Person(
            reader.GetInt32(personIdOrdinal),
            reader.GetString(firstNameOrdinal),
            reader.GetString(lastNameOrdinal),
            reader.GetString(emailOrdinal));
      }

      private IReadOnlyList<Person> TranslatePersons(SqlDataReader reader)
      {
         var persons = new List<Person>();

         var personIdOrdinal = reader.GetOrdinal("PersonId");
         var firstNameOrdinal = reader.GetOrdinal("FirstName");
         var lastNameOrdinal = reader.GetOrdinal("LastName");
         var emailOrdinal = reader.GetOrdinal("Email");

         while (reader.Read())
         {
            persons.Add(new Person(
               reader.GetInt32(personIdOrdinal),
               reader.GetString(firstNameOrdinal),
               reader.GetString(lastNameOrdinal),
               reader.GetString(emailOrdinal)));
         }

         return persons;
      }
   }
}
