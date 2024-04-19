using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;
using PersonData.Models;

namespace PersonData
{
   public class SqlAddressRepository : IAddressRepository
   {
      private readonly string connectionString;

      public SqlAddressRepository(string connectionString)
      {
         this.connectionString = connectionString;
      }

      public void SaveAddress(int personId, AddressType addressType, string line1, string line2, string city, string stateCode, string zipCode)
      {
         // Verify parameters.
         if (line1 == null)
            throw new ArgumentNullException(nameof(line1));

         if (city == null)
            throw new ArgumentNullException(nameof(city));

         if (stateCode == null)
            throw new ArgumentNullException(nameof(stateCode));

         if (stateCode.Length != 2)
            throw new ArgumentException("State code must be two characters.", nameof(stateCode));

         if (zipCode == null)
            throw new ArgumentNullException(nameof(zipCode));

         if (zipCode.Length != 5)
            throw new ArgumentException("Zip code must be five characters.", nameof(stateCode));

         // Save address to the database.
         using (var transaction = new TransactionScope())
         {
            using (var connection = new SqlConnection(connectionString))
            {
               using (var command = new SqlCommand("Person.SavePersonAddress", connection))
               {
                  command.CommandType = CommandType.StoredProcedure;

                  command.Parameters.AddWithValue("PersonId", personId);
                  command.Parameters.AddWithValue("AddressTypeId", addressType);
                  command.Parameters.AddWithValue("Line1", line1);
                  command.Parameters.AddWithValue("Line2", (object)line2 ?? DBNull.Value);
                  command.Parameters.AddWithValue("City", city);
                  command.Parameters.AddWithValue("StateCode", stateCode);
                  command.Parameters.AddWithValue("ZipCode", zipCode);

                  connection.Open();

                  command.ExecuteNonQuery();

                  transaction.Complete();
               }
            }
         }
      }

      public IReadOnlyList<Address> RetrieveAdresses(int personId)
      {
         using (var connection = new SqlConnection(connectionString))
         {
            using (var command = new SqlCommand("Person.RetrieveAddressesForPerson", connection))
            {
               command.CommandType = CommandType.StoredProcedure;

               command.Parameters.AddWithValue("PersonId", personId);

               connection.Open();

               using (var reader = command.ExecuteReader())
                  return TranslateAddresses(reader);
            }
         }
      }

      private IReadOnlyList<Address> TranslateAddresses(SqlDataReader reader)
      {
         var addresses = new List<Address>();

         var personIdOrdinal = reader.GetOrdinal("PersonId");
         var addressTypeIdOrdinal = reader.GetOrdinal("AddressTypeId");
         var line1Ordinal = reader.GetOrdinal("Line1");
         var line2Ordinal = reader.GetOrdinal("Line2");
         var cityOrdinal = reader.GetOrdinal("City");
         var stateCodeOrdinal = reader.GetOrdinal("StateCode");
         var zipCodeOrdinal = reader.GetOrdinal("ZipCode");

         while (reader.Read())
         {
            addresses.Add(new Address(
               reader.GetInt32(personIdOrdinal),
               (AddressType)reader.GetByte(addressTypeIdOrdinal),
               reader.GetString(line1Ordinal),
               reader.IsDBNull(line2Ordinal) ? null : reader.GetString(line2Ordinal),
               reader.GetString(cityOrdinal),
               reader.GetString(stateCodeOrdinal),
               reader.GetString(zipCodeOrdinal)));
         }

         return addresses;
      }
   }
}
