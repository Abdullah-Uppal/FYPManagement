using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FYP_Management.Classes {

    class QueriesQueue {
        private List<string> pendingQueries;
        SqlConnection connection;
        public QueriesQueue(SqlConnection con) {
            pendingQueries = new List<string>();
            connection = con;
        }
        public void Enqueue(string query) {
            pendingQueries.Add(query);
        }
        /// <summary>
        /// This will execute all the queries that are in the queue
        /// </summary>
        /// <returns>true if all queries have been successfully executed, otherwise returns false.</returns>
        public bool ExecuteAll() {
            SqlCommand cmd = new SqlCommand("", connection);
            bool pass = true;
            foreach (string query in pendingQueries) {
                cmd.CommandText = query;
                try {
                    cmd.ExecuteNonQuery();
                }
                catch(Exception e) {
                    pass = false;
                }
            }
            return pass;
        }
        public void ClearQueue() {
            this.pendingQueries.Clear();
        }
        public bool IsEmpty() {
            return pendingQueries.ToArray().Length == 0;
        }
    }
}
