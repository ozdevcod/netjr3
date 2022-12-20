using System;
using System.Collections;
using System.Data;
using Microsoft.Data.SqlClient;

namespace biblioteca.data
{
    public struct ParamData
    {
        public string ParameterName { get; set; }
        public string? ParameterValue { get; set; }
        public SqlDbType ParameterDataType { get; set; }
        public ParamData(string parameterName, SqlDbType parameterDataType, string? parameterValue)
        {
            this.ParameterName = parameterName;
            this.ParameterDataType = parameterDataType;
            this.ParameterValue = parameterValue;
        }
    }

    public class StoredProcedure
    {
        public StoredProcedure()
        {

        }
        public string? StoredProcedureName { get; set; }
        private ArrayList? ParameterList { get; set; }
        public void SetParam(string pName, SqlDbType pDataType, string? pValue)
        {
            if (ParameterList == null)
            {
                ParameterList = new();
            }
            ParamData pData = new(pName, pDataType, pValue);
            ParameterList.Add(pData);
        }

        public ArrayList GetParams()
        {
            if (ParameterList != null)
            {
                return ParameterList;
            }
            else
            {
                return new ArrayList();
            }
        }

        public static bool ExecuteSps(StoredProcedureCollection spCollection, string connectionString)
        {
            try
            {
                using (SqlConnection Connection = new(connectionString))
                {
                    using SqlCommand cmd = new();
                    foreach (StoredProcedure spData in spCollection)
                    {
                        int i = 0;
                        if (Connection.State != ConnectionState.Open)
                            Connection.Open();
                        cmd.Connection = Connection;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = spData.StoredProcedureName;
                        IEnumerator myEnumerator = spData.GetParams().GetEnumerator();
                        while (myEnumerator.MoveNext())
                        {
                            ParamData pData = (ParamData)myEnumerator.Current;
                            cmd.Parameters.Add(pData.ParameterName, pData.ParameterDataType);
                            cmd.Parameters[i].Value = pData.ParameterValue;
                            i = i + 1;
                        }
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                return false;
            }
        }
    }

    public class StoredProcedureCollection : System.Collections.CollectionBase
    {
        public void Add(StoredProcedure value)
        {
            List.Add(value);
        }
    }
}