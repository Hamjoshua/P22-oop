using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace oop.Classes
{
    public class Document
    {
        protected virtual string _fileExtension { get; } = "";
        protected virtual string _fileType { get; } = "";

        public string Author, Name, Path, Theme;
        public List<string> Tags;

        public Document()
        {
            Author = "author";
            Name = "name";
            Path = "path";
            Theme = "theme";
            Tags = new List<string>() { "Tag1", "Tag2", "Tag3"};
        }

        public virtual string GetInfo()
        {
            string TagsInString = "";
            foreach(string Tag in Tags)
            {
                TagsInString += Tag + "; ";
            }
            string result = $"Автор: {Author}\nИмя файла: {Name}\nПуть к файлу: {Path}\nТематика: {Theme}\nРасширение файла: {_fileExtension}\n" +
                $"Тип файла: {_fileType}\nТэги: {TagsInString}\n";
            return result;
        }
    }

    public class MSWordDocument : Document
    {
        protected override string _fileExtension  { get; } = ".docx|.doc";
        protected override string _fileType  { get; } = "Документ Microsoft Word";

        private int Year;
        
        public MSWordDocument() : base()
        {
            Year = 2001;
        }

        public override string GetInfo()
        {
            string Result = base.GetInfo();
            Result += $"Год издания Word: {Year}";
            return Result;
        }
        
    }

    public class PDFDocument : Document
    {
        protected override string _fileExtension  { get; } = ".pdf";
        protected override string _fileType  { get; } = "Документ PDF";

        private bool ReadOnly;
        
        public PDFDocument() : base()
        {
            ReadOnly = false;
        }

        public override string GetInfo()
        {
            string Result = base.GetInfo();
            Result += $"Только для чтения: {ReadOnly}";
            return Result;
        }
    }

    public class MSExcelDocument : Document
    {
        protected override string _fileExtension  { get; } = ".xls|.xlsx";
        protected override string _fileType  { get; } = "Таблица Excel";

        private int CountSheet;
        
        public MSExcelDocument() : base()
        {
            CountSheet = 4;
        }

        public override string GetInfo()
        {
            string Result = base.GetInfo();
            Result += $"Количество листов: {CountSheet}";
            return Result;
        }
    }

    public class TxtDocument : Document
    {
        protected override string _fileExtension  { get; } = ".txt";
        protected override string _fileType  { get; } = "Текстовый файл";

        private string CodeTable;
        
        public TxtDocument() : base()
        {
            CodeTable = "UTF-8";
        }

        public override string GetInfo()
        {
            string Result = base.GetInfo();
            Result += $"Кодировка: {CodeTable}";
            return Result;
        }
        
    }
    public class HtmlDocument : Document
    {
        protected override string _fileExtension  { get; } = ".html";
        protected override string _fileType  { get; } = "Файл разметки";

        private bool WithCss;
        
        public HtmlDocument() : base()
        {
            WithCss = true;
        }

        public override string GetInfo()
        {
            string Result = base.GetInfo();
            Result += $"Есть ли CSS: {WithCss}";
            return Result;
        }
    }
}
