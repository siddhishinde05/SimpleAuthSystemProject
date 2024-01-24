namespace Simple_Auth_System_Project.CommonUtility
{
    public class SqlQueries
    {
        public static IConfiguration _configuration = new ConfigurationBuilder().AddXmlFile(path:"SqlQueries.xml", optional: true, reloadOnChange: true).Build();  
        public static string AddInformation { get { return _configuration[key: "AddInformation"]; } }       
        public static string ReadAllInformation { get { return _configuration[key: "ReadAllInformation"]; } }
        public static string UpdateAllInformationById { get { return _configuration[key: "UpdateAllInformationById"]; } }
        public static string DeleteInformationById { get { return _configuration[key: "DeleteInformationById"]; } }
        public static string GetDeleteAllInformation { get { return _configuration[key: "GetDeleteAllInformation"]; } }      
        //public static string ReadInformationById { get { return _configuration[key: "ReadInformationById"]; } }



    }
}
