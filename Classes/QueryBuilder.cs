using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYP_Management.Classes {
    public class QueryBuilder {
        private string __query;

        public QueryBuilder Select(string columns="*") {
            __query += "SELECT " + columns;
            return this;
        }
        public QueryBuilder Select(params string[] columns) {
            __query += "SELECT " + String.Join(", ", columns);
            return this;
        }

        public QueryBuilder From(params string[] tables) {
            __query += " FROM " + String.Join(", ", tables);
            return this;
        }
        public QueryBuilder Join(string table2) {
            __query += " JOIN " + table2;
            return this;
        }
        public QueryBuilder On(string condition) {
            __query += " ON " + condition;
            return this;
        }

        public QueryBuilder Where(string condition) {
            __query += " WHERE " + condition;
            return this;
        }
        public QueryBuilder OrderBy(String column, String order="ASC") {
            __query += " ORDER BY " + column + " " + order;
            return this;
        }
        public QueryBuilder GroupBy(params string[] columns) {
            __query += " GROUP BY " + String.Join(", ", columns);
            return this;
        }
        public QueryBuilder Having(string condition) {
            __query += " HAVING " + condition;
            return this;
        }
        public QueryBuilder InsertInto(string table, params string[] columns) {
            __query += "INSERT INTO (" + String.Join(", ", columns) +")";
            return this;
        }
        public QueryBuilder Values(params string[] vs) {
            __query += " VALUES (" + String.Join(", ", vs) + ")";
            return this;
        }
        /// <returns>Returns the built query</returns>
        public override string ToString() {
            return __query;
        }
    }
}
