using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DbProject
{
    public class BaseLogic : IDisposable
    {
        //public TextAppContext db = new TextAppContext();
        public TextAppBackUpContext db = new TextAppBackUpContext(); // back-up database
        public static List<Song> songs = new List<Song>();
        public static string[] words_delimiters = new string[] {",", " ", "?", "\"", "-", "(", ")", ".", "!", "\n"};
        public static List<Group> groups = new List<Group>();
       
        public void Dispose()
        {
            db.Dispose();
        }

        public void saveToDataBase<T>(List<T> ListOfdata)
        {
            if (ListOfdata != null)
                foreach (T element in ListOfdata)
                    if (element != null)
                        db.Add(element);
            db.SaveChanges();
        }

        public void serialize()
        {
            List<Song> songs = db.Songs.ToList();
            List<Word> words = db.Words.ToList();
            List<Position> positions = db.Positions.ToList();
            List<Group> groups = db.Groups.ToList();
            List<ExpressionsVsPosition> expressionsVsPositions = db.ExpressionsVsPositions.ToList();
            List<LinguisticExpression> linguisticExpressions = db.LinguisticExpressions.ToList();
            List<WordsVsGroup> wordsVsGroups = db.WordsVsGroups.ToList();       
            serializeTable(songs);
            serializeTable(words);
            serializeTable(positions);
            serializeTable(groups);
            serializeTable(expressionsVsPositions);
            serializeTable(linguisticExpressions);
            serializeTable(wordsVsGroups);
        }

        private void serializeTable<T>(List<T> table)
        {
            string fileName = @"C:\Projects\AngularProjectTest\SongApplication\TextAppVer2NotOriginal\XML\";
            string typeName = table.GetType().GenericTypeArguments[0].Name + "s.xml";
            using (FileStream fs = new FileStream(fileName + typeName, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>), IgnoreList.GetOverrides());
                serializer.Serialize(fs, table);
            }
        }
        

        public void desSrialize()
        {
            string connectionString = "Server=.\\sqlExpress;DataBase=TextAppBackUp;Trusted_connection=True;Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                bulkCopyMethod("Songs", connection);
                bulkCopyMethod("Words", connection);
                bulkCopyMethod("Positions", connection);
                bulkCopyMethod("Groups", connection);
                bulkCopyMethod("ExpressionsVsPositions", connection);
                bulkCopyMethod("LinguisticExpressions", connection);
                bulkCopyMethod("WordsVsGroups", connection);
                connection.Close();
            }
        }
            private void bulkCopyMethod(string tableName, SqlConnection connection)
            {
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    string fileName = @"C:\Projects\AngularProjectTest\SongApplication\TextAppVer2NotOriginal\XML\";
                    bulkCopy.DestinationTableName = tableName;
                    DataSet dataSet = new DataSet();
                    dataSet.ReadXml(fileName + tableName.ToLower()+".xml");
                    if(dataSet.Tables.Count > 0) 
                    {
                        DataTable dataTable = dataSet.Tables[0];
                        using (DataTableReader dataTableReader = dataTable.CreateDataReader())
                        {
                            bulkCopy.WriteToServer(dataTableReader);
                        }
                    }
                    
                }
            }
    }
}