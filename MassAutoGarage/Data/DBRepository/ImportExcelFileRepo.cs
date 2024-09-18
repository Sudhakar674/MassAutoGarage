using Dapper;
using MassAutoGarage.DBContext;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MassAutoGarage.Data.DBRepository
{
    public class ImportExcelFileRepo
    {
        #region public Variables
        SessionManager sm = new SessionManager();
        #endregion

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        public string SaveExecuteQuery(DataTable dt)
        {
            string res = string.Empty;
            try
            {

                var queryParameters = new DynamicParameters();

                SqlBulkCopy objbulk = new SqlBulkCopy(con);

                objbulk.DestinationTableName = "UMP";
                objbulk.ColumnMappings.Add("LOT_NO", "LOT_NO");
                objbulk.ColumnMappings.Add("COURSE", "COURSE");
                objbulk.ColumnMappings.Add("YEAR", "YEAR");
                objbulk.ColumnMappings.Add("SUBJECT", "SUBJECT");
                objbulk.ColumnMappings.Add("PAPER_NO", "PAPER_NO");

                objbulk.ColumnMappings.Add("PAPER_CODE", "PAPER_CODE");
                objbulk.ColumnMappings.Add("ROLL_NO", "ROLL_NO");
                objbulk.ColumnMappings.Add("ENROL_NO", "ENROL_NO");
                objbulk.ColumnMappings.Add("MARKS", "MARKS");
                objbulk.ColumnMappings.Add("MARKSINWORDS", "MARKSINWORDS");
                objbulk.ColumnMappings.Add("POST_DATE", "POST_DATE");
                objbulk.ColumnMappings.Add("USERNAME", "USERNAME");
                objbulk.ColumnMappings.Add("COLLEGE_CODE", "COLLEGE_CODE");
                objbulk.ColumnMappings.Add("CENTER_CODE", "CENTER_CODE");
                objbulk.ColumnMappings.Add("COPY_SLNO", "COPY_SLNO");
                objbulk.ColumnMappings.Add("STATUS", "STATUS");
                objbulk.ColumnMappings.Add("DATE_RECE", "DATE_RECE");
                objbulk.ColumnMappings.Add("BACK_MARKS", "BACK_MARKS");
                objbulk.ColumnMappings.Add("BACK_MARKSINWORDS", "BACK_MARKSINWORDS");
                objbulk.ColumnMappings.Add("BACK_PAPER", "BACK_PAPER");
                objbulk.ColumnMappings.Add("IMPROVEMENT", "IMPROVEMENT");
                objbulk.ColumnMappings.Add("NO_CHANGE", "NO_CHANGE");
                objbulk.ColumnMappings.Add("NOT_IN_COLLEGE", "NOT_IN_COLLEGE");
                objbulk.ColumnMappings.Add("ABSENT", "ABSENT");
                objbulk.ColumnMappings.Add("ORIGINAL_MARKS", "ORIGINAL_MARKS");
                objbulk.ColumnMappings.Add("NEXT_USER_ID", "NEXT_USER_ID");
                objbulk.ColumnMappings.Add("NEXT_UPDATE_DATE", "NEXT_UPDATE_DATE");
                objbulk.ColumnMappings.Add("PC_NAME", "PC_NAME");
                objbulk.ColumnMappings.Add("C_NC", "C_NC");

                objbulk.ColumnMappings.Add("BPM", "BPM");
                objbulk.ColumnMappings.Add("OMP", "OMP");
                objbulk.ColumnMappings.Add("AWARD_CODE", "AWARD_CODE");
                objbulk.ColumnMappings.Add("FILE_NAME", "FILE_NAME");
                objbulk.ColumnMappings.Add("UPLOAD_DATE", "UPLOAD_DATE");
                objbulk.ColumnMappings.Add("REMARK", "REMARK");
                objbulk.ColumnMappings.Add("PAPER_NAME", "PAPER_NAME");
                objbulk.ColumnMappings.Add("EXAM_TYPE", "EXAM_TYPE");
                objbulk.ColumnMappings.Add("MAX_MARKS", "MAX_MARKS");
                objbulk.ColumnMappings.Add("REMARK1", "REMARK1");
                objbulk.ColumnMappings.Add("REMARK2", "REMARK2");
                objbulk.ColumnMappings.Add("CHK_MARKS", "CHK_MARKS");

                con.Open();
                objbulk.WriteToServer(dt);
                con.Close();
                res = "1";


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        public DataTable GetExcelListByID(string LotNo)
        {
            SqlCommand cmd = new SqlCommand("USP_GetLotNo", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LotNo", LotNo);

            con.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();

            if (dt != null)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }

        public DataTable GetExcelList(string QueryType, string ProcName)
        {
            SqlCommand cmd = new SqlCommand(ProcName, con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@QueryType", QueryType);

            con.Open();
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            con.Close();

            if (dt != null)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }

        public string SaveAwardsheetExecuteQuery(DataTable dt)
        {
            string res = string.Empty;
            try
            {

                var queryParameters = new DynamicParameters();

                SqlBulkCopy objbulk = new SqlBulkCopy(con);

                objbulk.DestinationTableName = "AWARD_SHEET";
                objbulk.ColumnMappings.Add("NCSHeader", "NCSHeader");
                objbulk.ColumnMappings.Add("BAR", "BAR");
                objbulk.ColumnMappings.Add("BAR2", "BAR2");
                objbulk.ColumnMappings.Add("R1", "R1");
                objbulk.ColumnMappings.Add("P1", "P1");
                objbulk.ColumnMappings.Add("M1", "M1");
                objbulk.ColumnMappings.Add("R2", "R2");
                objbulk.ColumnMappings.Add("P2", "P2");
                objbulk.ColumnMappings.Add("M2", "M2");
                objbulk.ColumnMappings.Add("R3", "R3");
                objbulk.ColumnMappings.Add("P3", "P3");
                objbulk.ColumnMappings.Add("M3", "M3");
                objbulk.ColumnMappings.Add("R4", "R4");
                objbulk.ColumnMappings.Add("P4", "P4");
                objbulk.ColumnMappings.Add("M4", "M4");
                objbulk.ColumnMappings.Add("R5", "R5");
                objbulk.ColumnMappings.Add("P5", "P5");
                objbulk.ColumnMappings.Add("M5", "M5");
                objbulk.ColumnMappings.Add("R6", "R6");
                objbulk.ColumnMappings.Add("P6", "P6");
                objbulk.ColumnMappings.Add("M6", "M6");
                objbulk.ColumnMappings.Add("R7", "R7");
                objbulk.ColumnMappings.Add("P7", "P7");
                objbulk.ColumnMappings.Add("M7", "M7");
                objbulk.ColumnMappings.Add("R8", "R8");
                objbulk.ColumnMappings.Add("P8", "P8");
                objbulk.ColumnMappings.Add("M8", "M8");
                objbulk.ColumnMappings.Add("R9", "R9");
                objbulk.ColumnMappings.Add("P9", "P9");

                objbulk.ColumnMappings.Add("M9", "M9");
                objbulk.ColumnMappings.Add("R10", "R10");
                objbulk.ColumnMappings.Add("P10", "P10");
                objbulk.ColumnMappings.Add("M10", "M10");
                objbulk.ColumnMappings.Add("R11", "R11");
                objbulk.ColumnMappings.Add("P11", "P11");
                objbulk.ColumnMappings.Add("M11", "M11");
                objbulk.ColumnMappings.Add("R12", "R12");
                objbulk.ColumnMappings.Add("P12", "P12");
                objbulk.ColumnMappings.Add("M12", "M12");
                objbulk.ColumnMappings.Add("R13", "R13");
                objbulk.ColumnMappings.Add("P13", "P13");

                objbulk.ColumnMappings.Add("M13", "M13");
                objbulk.ColumnMappings.Add("R14", "R14");
                objbulk.ColumnMappings.Add("P14", "P14");
                objbulk.ColumnMappings.Add("M14", "M14");
                objbulk.ColumnMappings.Add("R15", "R15");

                objbulk.ColumnMappings.Add("P15", "P15");
                objbulk.ColumnMappings.Add("M15", "M15");
                objbulk.ColumnMappings.Add("R16", "R16");
                objbulk.ColumnMappings.Add("P16", "P16");
                objbulk.ColumnMappings.Add("M16", "M16");
                objbulk.ColumnMappings.Add("R17", "R17");


                objbulk.ColumnMappings.Add("P17", "P17");
                objbulk.ColumnMappings.Add("M17", "M17");
                objbulk.ColumnMappings.Add("R18", "R18");
                objbulk.ColumnMappings.Add("P18", "P18");
                objbulk.ColumnMappings.Add("M18", "M18");
                objbulk.ColumnMappings.Add("R19", "R19");



                objbulk.ColumnMappings.Add("P19", "P19");
                objbulk.ColumnMappings.Add("M19", "M19");
                objbulk.ColumnMappings.Add("R20", "R20");
                objbulk.ColumnMappings.Add("P20", "P20");
                objbulk.ColumnMappings.Add("M20", "M20");
                objbulk.ColumnMappings.Add("R21", "R21");

                objbulk.ColumnMappings.Add("P21", "P21");
                objbulk.ColumnMappings.Add("M21", "M21");
                objbulk.ColumnMappings.Add("R22", "R22");
                objbulk.ColumnMappings.Add("P22", "P22");
                objbulk.ColumnMappings.Add("M22", "M22");
                objbulk.ColumnMappings.Add("R23", "R23");

                objbulk.ColumnMappings.Add("P23", "P23");
                objbulk.ColumnMappings.Add("M23", "M23");
                objbulk.ColumnMappings.Add("R24", "R24");
                objbulk.ColumnMappings.Add("P24", "P24");
                objbulk.ColumnMappings.Add("M24", "M24");
                objbulk.ColumnMappings.Add("R25", "R25");
                objbulk.ColumnMappings.Add("P25", "P25");
                objbulk.ColumnMappings.Add("M25", "M25");



                con.Open();
                objbulk.WriteToServer(dt);
                con.Close();
                res = "1";


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        public string SaveCopyFlapExecuteQuery(DataTable dt)
        {
            string res = string.Empty;
            try
            {

                var queryParameters = new DynamicParameters();

                SqlBulkCopy objbulk = new SqlBulkCopy(con);

                objbulk.DestinationTableName = "tbl_CopyFlap";
                objbulk.ColumnMappings.Add("SRNO", "SRNO");
                objbulk.ColumnMappings.Add("BARCODE", "BARCODE");
                objbulk.ColumnMappings.Add("ROLLNO", "ROLLNO");
                objbulk.ColumnMappings.Add("Pcode", "Pcode");
                objbulk.ColumnMappings.Add("PAPERCODE", "PAPERCODE");
                objbulk.ColumnMappings.Add("STATUS", "STATUS");




                con.Open();
                objbulk.WriteToServer(dt);
                con.Close();
                res = "1";


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        
    }
}