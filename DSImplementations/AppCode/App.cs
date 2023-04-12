using AppLoggerLibrary;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices.ComTypes;
using DSImplementations.AppCode.DataStructures;

namespace AppCode
{
    internal static class App
    {
        internal static void CreateData()
        {
            Console.WriteLine("Entering the data please wait");
            var firstNames = new List<string>() { "Kunal", "Samarth", "Shivang", "Shubhanker", "Abhishek", "Akhil", "Saurabh", "Akash", "Vikash", "Vishal", "Virender", "Amit", "Sumit", "Mohit", "Rohit" };
            var lastNames = new List<string>() { "Agarwal", "Jain", "Saxena", "Sharma", "Rana", "Bhora", "Bansal", "Garg", "Goel", "Jindal", "Ahuja"};
            var states = new List<string>() { "Haryana", "Uttarakhand", "UP", "MP", "Punjab", "Rajasthan", "AP", "Karnataka", "Tamil Nadu", "Goa", "Gujrat" };
            var cities = new List<string>() { "Jhajjar", "Rohtak", "Bhadurgarh", "Guna", "Shivpuri", "Noida", "Amritsar", "Pune", "Haridwar", "Nanital", "Hisar" };
            var path = @"C:\Users\kagarwal\Desktop\codes\Assignments\DSImplementations\DSImplementations\Data\Contacts.xlsx";

            var excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = excel.Workbooks.Open(path);
            _Worksheet ws = (_Worksheet)wb.Sheets[1];
            Microsoft.Office.Interop.Excel.Range cellRange = ws.Range["A1:G1"];
            string[] columns = new[] { "Id", "First Name", "Last Name", "Age", "State", "City", "Contact"};
            cellRange.set_Value(XlRangeValueDataType.xlRangeValueDefault, columns);

            var nameRandom = new Random();
            var stateRandom = new Random();
            var cityRandom = new Random();
            var ageRandom = new Random();
            var contactRandom = new Random();

            for (int i = 2; i < 60002; i++)
            {
                string id = (i - 1).ToString();
                string firstName = firstNames[nameRandom.Next(0, 14)];
                string lastName = lastNames[nameRandom.Next(0, 10)];
                string state = states[stateRandom.Next(0, 10)];
                string city = cities[nameRandom.Next(0, 10)];
                string age = ageRandom.Next(20, 50).ToString();
                string phone = contactRandom.Next(676767, 999999).ToString() + contactRandom.Next(0000, 9999).ToString();
                string[] row = new[] { id, firstName,lastName, age, state, city, phone };
                cellRange = ws.Range[$"A{i}:G{i}"];
                cellRange.set_Value(XlRangeValueDataType.xlRangeValueDefault, row);
            }

            wb.SaveAs(path);
            wb.Close();

            Process.Start(path);

        }

        private static readonly string directory = ConfigurationManager.AppSettings["path"].ToString();
        private static readonly string _logFilePath = directory + "Logs.txt";
        private static readonly Logger _appLogs = new Logger(_logFilePath);

        private static Array<Person> Duplicate(Array<Person> arr)
        {
            var temp = new Array<Person>(arr.Count);
            for(int i=0;i< arr.Count; i++)
            {
                temp[i] = arr[i];
            }
            return temp;
        }
        
        private static void ArrayMain()
        {
            var data = Records.GetData();

            Stopwatch sw = Stopwatch.StartNew();
            
            Console.Write("Binding records in array please wait...");
            Array<Person> array = new Array<Person>(data);
            
            sw.Stop();
            Console.Write("\nTime Taken in binding : " + sw.ElapsedMilliseconds + $" milliseconds\nRecords Fetched : {array.Count} \n\nPress any key to sort according to the age\n\n");
            Console.ReadKey();


            Task bubbleSorted = Task.Run(() => 
            {
                Array<Person> arr = Duplicate(array);
                //Console.WriteLine("Bubble sort Started..");
                Array<Person>.BubbleSort(arr.obj, out TimeSpan time); 
                Console.WriteLine("Bubble sort Completed    : " + time.ToString()); 
            });

            Task selectionSorted = Task.Run(() =>
            {
                Array<Person> arr = Duplicate(array);
                //Console.WriteLine("Selection sort Started..");
                Array<Person>.SelectionSort(arr.obj, out TimeSpan time);
                Console.WriteLine("Selection sort Completed : " + time.ToString());
            });

            Task insertionSorted = Task.Run(() =>
            {
                Array<Person> arr = Duplicate(array);
                //Console.WriteLine("Insertion sort Started..");
                Array<Person>.InsertionSort(arr.obj, out TimeSpan time);
                Console.WriteLine("Insertion sort Completed : " + time.ToString());
            });

            Task mergeSorted = Task.Run(() =>
            {
                Array<Person> arr = Duplicate(array);
                //Console.WriteLine("Merge sort Started..");
                Array<Person>.MergeSort(arr.obj, out TimeSpan time);
                Console.WriteLine("Merge sort Completed     : " + time.ToString());
            });

            Task quickSorted = Task.Run(() =>
            {
                Array<Person> arr = Duplicate(array);
                //Console.WriteLine("Quick sort Started..");
                Array<Person>.QuickSort(arr.obj, out TimeSpan time);
                Console.WriteLine("Quick sort Completed     : " + time.ToString());
            });
            

            bubbleSorted.Wait();
            selectionSorted.Wait();
            insertionSorted.Wait();
            mergeSorted.Wait();
            quickSorted.Wait();

            Console.Write("\n\nDone with array press any key to continue\n\n");
            Console.ReadKey();
            
        }
        private static void LinkedListMain()
        {
            var data = Records.GetData();
            Stopwatch sw = Stopwatch.StartNew();
            Console.Write("Binding records in Linked List please wait...");
            var list = new LinkList<Person>(data);
            sw.Stop();
            Console.Write($"\nTime Taken in binding : " + sw.ElapsedMilliseconds + " milliseconds\n\nPress any key to sort according to the age\n\n");
            Console.ReadKey();


            Task bubbleSorted = Task.Run(() => 
            {
                var list1 = new LinkList<Person>(data);
                //Console.WriteLine("Bubble sort Started.."); 
                list1.BubbleSort(out TimeSpan time); 
                Console.WriteLine("Bubble sort Completed    : " + time.ToString()); 
            });



            Task SelectionSorted = Task.Run(() =>
            {
                var list1 = new LinkList<Person>(data);
                //Console.WriteLine("Selection sort Started.."); 
                list1.SelectionSort(out TimeSpan time); 
                Console.WriteLine("Selection sort Completed : " + time.ToString()); 
            });

            Task InsertionSorted = Task.Run(() =>
            {
                var list1 = new LinkList<Person>(data);
                //Console.WriteLine("Insertion sort Started.."); 
                list1.InsertionSort(out TimeSpan time); 
                Console.WriteLine("Insertion sort Completed : " + time.ToString()); 
            });

            Task MergeSorted = Task.Run(() =>
            {
                var list1 = new LinkList<Person>(data);
                //Console.WriteLine("Merge sort Started.."); 
                list1.MergeSort(out TimeSpan time); 
                Console.WriteLine("Merge sort Completed     : " + time.ToString()); 
            });

            Task QuickSorted = Task.Run(() =>
            {
                var list1 = new LinkList<Person>(data);
                //Console.WriteLine("Quick sort Started.."); 
                list1.QuickSort(out TimeSpan time); 
                Console.WriteLine("Quick sort Completed     : " + time.ToString()); 
            });

            bubbleSorted.Wait();
            SelectionSorted.Wait();
            InsertionSorted.Wait();
            MergeSorted.Wait();
            QuickSorted.Wait();

            Console.Write("\n\nDone with Linked List press any key to continue");
            Console.ReadKey();

        }

        internal static void Start()
        {
            //CreateData();

            ArrayMain();

            LinkedListMain();
        }




        internal static void ShowMessage(string category = "", string message = "", bool hold = false, string stackTrace = "", string timeTaken = "",
        [CallerFilePath] string callerPath = "", [CallerLineNumber] int line = 0, [CallerMemberName] string memberName = "")
        {
            if (category != "Event")
            {
                Console.Write("\n\t" + message);
            }
            if (hold)
            {
                Console.Write("\n\tPress any key to continue..");
                Console.ReadKey();
            }
            try
            {
                if (stackTrace == "") stackTrace = callerPath + "   Line:" + line + "   " + memberName;
                _appLogs.Log(new LogData(category, message, stackTrace,TimeSpan.Parse(timeTaken)));
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
                Console.ReadKey();
            }
        }
        
        internal static void Print(string text)
        {
            Console.Write(text);
        }
        internal static string Input(string info = " >> ", int newLines = 0)
        {
            while (newLines-- > 0) { Console.Write("\n"); }
            Console.Write(info);
            var args = Console.ReadLine();
            return args;
        }
        internal static void ComingSoon(string option = "")
        {
            Console.Clear();
            ShowMessage("Info", $"Options will be coming soon : {option}", true);
        }
        internal static void PrintName()
        {
            Console.Clear();
            Console.Write("\n\n\tWelcome to the Design Car App");
        }

    }
}
