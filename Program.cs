using System;
using System.Collections.Generic;
using oop.Classes;

namespace oop
{
    public class Singletone {
        public const int ExitNumber = 0;
        public bool OnRun
        {
            get
            {
                return _onRun;
            }
        }
        private bool _onRun = true;

        public static Singletone Instance
        {
            get
            {
                if (_instance == null) _instance = new Singletone();
                return _instance;
            }
        }      
        
        private static Singletone _instance;

        private Singletone()
        {
            
        }

        public void GetInfoAboutDocument()
        {
            Console.WriteLine($"\n\nВведите желаемый тип документа:\n1: MS Word\n2: PDF\n3: MS Excel\n4: Txt\n5: Html\nВыйти: {ExitNumber}");
            int ChosenNumber;

            try
            {
                ChosenNumber = Convert.ToInt32(Console.ReadLine());
                if (ChosenNumber < 1 || ChosenNumber > 5 || ChosenNumber != ExitNumber)
                {
                    throw new IndexOutOfRangeException();
                }
            }
            catch(Exception Error)
            {
                Console.WriteLine(Error.Message);
                return;
            }
            
            Document document = new Document();

            switch (ChosenNumber)
            {
                case 1:
                    document = new MSWordDocument();
                    break;
                case 2:
                    document = new PDFDocument();
                    break;
                case 3:
                    document = new MSExcelDocument();
                    break;
                case 4:
                    document = new TxtDocument();
                    break;
                case 5:
                    document = new HtmlDocument();
                    break;
                case ExitNumber:
                    _onRun = false;
                    return;
            }

            Console.WriteLine(document.GetInfo());
        }
    }

    static public class Program
    {
        static void Main(string[] args)
        {
            while (Singletone.Instance.OnRun)
            {
                Singletone.Instance.GetInfoAboutDocument();
            }
            Console.WriteLine("Работа программы завершена");
        }
    }

}
