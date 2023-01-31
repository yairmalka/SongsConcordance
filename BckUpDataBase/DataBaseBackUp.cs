namespace DbProject
{
    public class DataBaseBackUp
    {
        public static void Main(string[] args)
        {
            BaseLogic bl = new BaseLogic();
            //bl.serialize();
            //now load the textBackUp script file (DONE)
            //create db architecture (DONE)
            //Scaffold-DbContext -Connection  "Server=.\sqlExpress;DataBase=TextAppBackUp;Trusted_connection=True;Encrypt=False" -Provider Microsoft.EntityFrameworkCore.SqlServer -force
            // change in baselogic class the context to the backup database
            bl.desSrialize();
            //6) scaffold again the original db and update Song class to enable null values [XmlElement(IsNullable = true)] attr in Album and Genre
        }



    }
}
