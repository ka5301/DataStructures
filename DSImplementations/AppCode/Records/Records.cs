using LinqToExcel;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace AppCode
{
    internal static class Records
    {
        private static readonly string file = ConfigurationManager.AppSettings["path"].ToString() + "Contacts.xlsx";
        public static IQueryable<Person> GetData()
        {
            IQueryable<Person> data = null;
            using (var excel = new ExcelQueryFactory(file))
            {
                var worksheet = excel.Worksheet<Person>("Records");
                data = from record in worksheet
                       select record;
            }
            return data;
        }
      
    }
}
