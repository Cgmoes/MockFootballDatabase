using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Transactions;
using Data.Models;
using System.Data;

namespace GameZone_Sports_Network
{
    public class RankTeamsProcedureCall
    {
        private readonly string connectionString;

        public RankTeamsProcedureCall(string connectionString) 
        {
            this.connectionString = connectionString;
        }

        public void GetMargin(int week) 
        {
            if (week == null) throw new ArgumentNullException(nameof(week));

            using (var transaction = new TransactionScope()) 
            {
                
            }
        }
    }
}
