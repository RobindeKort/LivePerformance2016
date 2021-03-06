﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace LivePerformance2016.CSharp.Data
{
    public partial class Database : IData
    {
        private static string dataUser = "dbi310273";
        private static string dataPass = "VadY179x3V";
        private static string dataSrc = "//fhictora01.fhict.local:1521/fhictora";
        //private static string dataUser = "LP16";
        //private static string dataPass = "LP16";
        //private static string dataSrc = "//localhost:1521/xe";
        private static readonly string ConnectionString = "User Id=" + dataUser + ";Password=" + dataPass + ";Data Source=" + dataSrc + ";";

        // Connectie voor de database
        public static OracleConnection Connection
        {
            get
            {
                OracleConnection connection = new OracleConnection(ConnectionString);
                connection.Open();
                return connection;
            }
        }
    }
}
