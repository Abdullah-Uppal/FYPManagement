using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FYP_Management.Classes {
    public class Validator {
        /// <summary>
        /// Checks if all of the passed strings are nonempty
        /// </summary>
        /// <param name="vs">List of all string parameters</param>
        /// <returns>Returns true if all values are nonempty otherwise retursn false</returns>
        public static bool All(params string[] vs) {
            return vs.All(r => r.Trim() != "");
        }
        /// <summary>
        /// Returns true if passed string contains all the digits
        /// </summary>
        /// <param name="n">Numeric string</param>
        /// <returns>true if all are digits</returns>
        public static bool AreDigits(string n) {
            return n.All((char c) => c>='0' && c<='9');
        }
        /// <summary>
        /// Returns true if passed string contains all letters.
        /// It will consider space as a valid character.
        /// </summary>
        /// <param name="s">string to be checked</param>
        /// <returns>true if all are letters</returns>
        public static bool AreLetters(string s) {
            return s.All((char c) => {
                return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c==' ';
            });
        }
        public static bool ValidateEmail(string Email) {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(Email);
            if (match.Success)
                return true;
            return false;
        }
        public static bool ValidateRegistrationNumber(string reg) {
            string[] arr = reg.Split('-').ToArray();
            if (arr.Length==3) {
                if (!AreDigits(arr[0]) || !AreDigits(arr[2])) {
                    return false;
                }
                else if (!AreLetters(arr[1])) {
                    return false;
                }
                else {
                    return true;
                }
            }
            return false;
        }
        public static bool IsDecimal(string number) {
            return number.Split('.')
                .All(r => {
                    return AreDigits(r);
                });
        }
        public static int Exists(string table, string column, string equalto) {
            var connection = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand($"SELECT COUNT({column}) FROM {table} WHERE {column}='{equalto}'",
                connection);
            return int.Parse(cmd.ExecuteScalar().ToString());
        }
    }
}
