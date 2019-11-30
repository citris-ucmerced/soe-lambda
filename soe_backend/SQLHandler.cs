using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

public static class SQL
{
    public static class Format
    {
        /* CSV-like result output format */
        public const string DELIMITER = ",",
            NEW_LINE = "\n";

        /* How explicit/verbose telemetry receipts are (-1 == no restriction) */
        public const int MAX_CHARS_RETURED = -1;
        public const string VOIDED_CHARS = "\n\r\t";

        public const string DATETIME = "yyyy-MM-dd HH:mm:ss.fff";

        public const string SQL_FILES = "*.sql", SQL_FILE_TYPE = ".sql";
    }
    /* Common conditions */
    public const string COLUMNS = "columns",
        COLUMN = "column",
        VALUE = "value",
        ALL = "*",
        COUNT = "COUNT(*)";

    /* TABLE NAMES */
    public const string TABLE = "table";

    public const string CONDITION = "condition";

    public const string EQUALS = " = ";

    /* MS SQL has been shown to perform best when inserting groups of 25 values at a time. See https://www.red-gate.com/simple-talk/sql/performance/comparing-multiple-rows-insert-vs-single-row-insert-with-three-data-load-methods/ */
    public const int INSERT_BATCH_SIZE = 25;

    public static string IsEqual(string left, string right)
    {
        return left + EQUALS + right;
    }
}
public static class SQLHandler
{
    public static string ExecuteQuery(string query)
    {
        string connectionString = "Data Source=soeformdb.chlp0malcesh.us-west-1.rds.amazonaws.com;Initial Catalog=soeform;User id=" + System.Environment.GetEnvironmentVariable("db_username") + ";" + "Password=" + System.Environment.GetEnvironmentVariable("db_password") + ";";
        try
        {
            /* Defines connection parameters and query logic */
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    /* Connects to database and executes query */
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        /* Holds row results as they are read */
                        List<string> results = new List<string>();
                        while (reader.Read())
                        {

                            /* Dumps values into Object array */
                            Object[] fields = new Object[reader.FieldCount];
                            reader.GetValues(fields);

                            /* Adds row result as delimiter-seperated values */
                            results.Add(
                                String.Join(
                                    SQL.Format.DELIMITER,
                                    fields.Where(x => x != null)
                                    .Select(x => x.ToString())
                                    .ToArray()
                                )
                            );
                        }

                        /* Closes the database connection */
                        reader.Close();
                        connection.Close();

                        /* Returns formatted results from query */
                        return String.Join(
                            SQL.Format.NEW_LINE,
                            results.ToArray()
                        );
                    }
                }
            }
        }
        catch (Exception ex)
        {
            return String.Format(
                "Error({0}): {1}\n",
                Receiptize(query),
                Receiptize(ex.ToString())
            );
        }
    }
    public static string Receiptize(string text)
    {
        string output = "";
        foreach (char curr_char in text)
        {
            if (SQL.Format.MAX_CHARS_RETURED > 0 && output.Length == SQL.Format.MAX_CHARS_RETURED) return output + " ..."; /* Immediately returns when output is too long */
            else if (SQL.Format.VOIDED_CHARS.Contains(curr_char)) continue; /* Skips character if in illegal set */
            else if (output != "" && curr_char == ' ' && output.Last() == ' ') continue; /* Skips whitespace longer than length one */
            else output += curr_char; /* Appends valid character from original string */
        }
        return output;
    }
}