using System;
using System.Collections.Generic;

namespace Lab7
{
    public interface WriterIF
    {
        void View();
        void Edit();
    }

    public interface EditorIF
    {
        void Save();
        Novel_ItemIF Retrieve();
        void Delete();
    }

    public class Editor
    {

        private EditorIF novel_obj;

        public Editor(EditorIF itm)
        {
            novel_obj = itm;
        }

        public EditorIF GetNovel()
        {
            return novel_obj;
        }
    }

    public class Writer
    {

        private WriterIF novel_obj;

        public Writer(WriterIF itm)
        {
            novel_obj = itm;
        }

        public WriterIF GetNovel()
        {
            return novel_obj;
        }
    }

    public class Administrator
    {

        private NovelIF novel_obj;

        public Administrator(NovelIF itm)
        {
            novel_obj = itm;
        }

        public NovelIF GetNovel()
        {
            return novel_obj;
        }
    }

    public interface NovelIF : WriterIF, EditorIF
    {
        string GetTitle();

        void Add(Object item);
    }


    public interface Novel_ItemIF : NovelIF { }


    public class Novel : NovelIF
    {
        private List<Novel_ItemIF> items = new List<Novel_ItemIF>();
        private string novel_title;

        public Novel(string title)
        {
            novel_title = title;
        }

        public string GetTitle()
        {
            return novel_title;
        }

        public void Add(object itm)
        {
            items.Add((Novel_ItemIF)itm);
        }

        public void Save()
        {
            Console.WriteLine("Saving " + novel_title + "...");
            Console.WriteLine(novel_title + " Saved Successfully!");
        }

        public Novel_ItemIF Retrieve()
        {
            Console.WriteLine("Retrieving " + novel_title + "...");
            return null;
        }

        public void Delete()
        {
            Console.WriteLine("Deleting " + novel_title + "...");
            Console.WriteLine(novel_title + " Deleted Successfully!");
        }

        public void View()
        {
            foreach (Novel_ItemIF element in items)
            {
                if (element is Character)
                {
                    Character ch = (Character)element;
                    Console.Write(ch.GetContent());
                }
                element.View();
            }
        }

        public void Edit()
        {
            Console.WriteLine("Editing " + novel_title + "...");
        }

    }

    public interface Page_ItemIF : Novel_ItemIF { }


    public class Page : Novel_ItemIF
    {
        private List<Page_ItemIF> items = new List<Page_ItemIF>();

        private string title;

        public string GetTitle()
        {
            return title;
        }

        public void Add(Object itm)
        {
            items.Add((Page_ItemIF)itm);
        }

        public void Save()
        {
            Console.WriteLine("Saving Page...");
            Console.WriteLine("Page Saved Successfully!");
        }

        public Novel_ItemIF Retrieve()
        {
            Console.WriteLine("Retrieving Page...");
            return null;
        }

        public void Delete()
        {
            Console.WriteLine("Deleting Page...");
            Console.WriteLine("Page Deleted Successfully!");
        }

        public void View()
        {
            foreach (Novel_ItemIF element in items)
            {
                if (element is Character)
                {
                    Character ch = (Character)element;
                    Console.Write(ch.GetContent());
                }
                element.View();
            }
        }

        public void Edit()
        {
            Console.WriteLine("Editing Page...");
        }
    }

    public abstract class Composite_Page_Item : Page_ItemIF
    {
        private string title;

        public string GetTitle()
        {
            return title;
        }

        public abstract void Add(Object item);
        public abstract void Save();
        public abstract Novel_ItemIF Retrieve();
        public abstract void Delete();
        public abstract void View();
        public abstract void Edit();
    }

    public interface Column_ItemIF { }

    public interface Frame_ItemIF { }


    public class Frame : Composite_Page_Item, Column_ItemIF
    {
        private List<Frame_ItemIF> items = new List<Frame_ItemIF>();

        public override void Add(Object itm)
        {
            items.Add((Frame_ItemIF)itm);
        }

        public override void Save()
        {
            Console.WriteLine("Saving Frame...");
            Console.WriteLine("Frame Saved Successfully!");
        }

        public override Novel_ItemIF Retrieve()
        {
            Console.WriteLine("Retrieving Frame...");
            return null;
        }

        public override void Delete()
        {
            Console.WriteLine("Deleting Frame...");
            Console.WriteLine("Frame Deleted Successfully");
        }

        public override void View()
        {
            foreach (Novel_ItemIF element in items)
            {
                if (element is Character)
                {
                    Character ch = (Character)element;
                    Console.Write(ch.GetContent());
                }
                element.View();
            }
        }

        public override void Edit()
        {
            Console.WriteLine("Editing Frame...");
        }
    }

    public class Column : Composite_Page_Item, Frame_ItemIF
    {

        private List<Column_ItemIF> items = new List<Column_ItemIF>();

        public override void Add(Object itm)
        {
            items.Add((Column_ItemIF)itm);
        }

        public override void Save()
        {
            Console.WriteLine("Saving Column...");
            Console.WriteLine("Column Saved Successfully!");
        }

        public override Novel_ItemIF Retrieve()
        {
            Console.WriteLine("Retrieving Column...");
            return null;
        }

        public override void Delete()
        {
            Console.WriteLine("Deleting Column...");
            Console.WriteLine("Column Deleted Successfully!");
        }

        public override void View()
        {
            foreach (Novel_ItemIF element in items)
            {
                if (element is Character)
                {
                    Character ch = (Character)element;
                    Console.Write(ch.GetContent());
                }
                element.View();
            }
        }

        public override void Edit()
        {
            Console.WriteLine("Editing Column...");
        }
    }

    public abstract class Column_Frame_Item : Page_ItemIF
    {
        private string title;

        public string GetTitle()
        {
            return title;
        }

        public abstract void Add(Object item);
        public abstract void Save();
        public abstract Novel_ItemIF Retrieve();
        public abstract void Delete();
        public abstract void View();
        public abstract void Edit();
    }

    public class LineOfText : Column_Frame_Item, Column_ItemIF
    {
        private List<LineOfText_ItemIF> items = new List<LineOfText_ItemIF>();

        public override void Add(Object itm)
        {
            items.Add((LineOfText_ItemIF)itm);
        }

        public override void Save()
        {
            Console.WriteLine("Saving LineOfText...");
            Console.WriteLine("LineOfText Saved Successfully!");
        }

        public override Novel_ItemIF Retrieve()
        {
            Console.WriteLine("Retrieving LineOfText...");
            return null;
        }

        public override void Delete()
        {
            Console.WriteLine("Deleting LineOfText...");
            Console.WriteLine("LineOfText Deleted Successfully!");
        }

        public override void View()
        {
            foreach (Novel_ItemIF element in items)
            {
                if (element is Character)
                {
                    Character ch = (Character)element;
                    Console.Write(ch.GetContent());
                }
            }
        }

        public override void Edit()
        {
            Console.WriteLine("Editing LineOfText...");
        }
    }

    public class Image : Column_Frame_Item, Frame_ItemIF, Column_ItemIF, LineOfText_ItemIF
    {
        public override void Add(Object itm)
        {
            return;
        }

        public override void Save()
        {
            Console.WriteLine("Saving Image...");
            Console.WriteLine("Image Saved Successfully!");
        }

        public override Novel_ItemIF Retrieve()
        {
            Console.WriteLine("Retrieving Image...");
            return null;
        }

        public override void Delete()
        {
            Console.WriteLine("Deleting Image...");
            Console.WriteLine("Image Deleted Successfully");
        }

        public override void View()
        {
            Console.WriteLine("Viewing Image...");
        }

        public override void Edit()
        {
            Console.WriteLine("Editing Image...");
        }
    }

    public interface LineOfText_ItemIF { }

    public class Character : Column_Frame_Item, LineOfText_ItemIF
    {
        private char c;

        public Character(char ch)
        {
            c = ch;
        }

        public char GetContent()
        {
            return c;
        }

        public void SetContent(char ch)
        {
            c = ch;
        }
        public override void Add(Object itm)
        {
            return;
        }

        public override void Save()
        {
            Console.WriteLine("Saving Character...");
            Console.WriteLine("Character Saved Successfully!");
        }

        public override Novel_ItemIF Retrieve()
        {
            Console.WriteLine("Retrieving Character...");
            return null;
        }

        public override void Delete()
        {
            Console.WriteLine("Deleting Character...");
            Console.WriteLine("Character Deleted Successfully!");
        }

        public override void View()
        {
            Console.WriteLine("Viewing Character...");
        }

        public override void Edit()
        {
            Console.WriteLine("Editing Character...");
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            Novel novel = new Novel("The Old Man and the Sea"); // create novel object
            Novel_ItemIF page = new Page(); // create one page in novel object

            Composite_Page_Item column = new Column();
            Composite_Page_Item frame = new Frame();
            Column_Frame_Item lineOfText = new LineOfText();

            novel.Add(page); // add page to novel
            page.Add(column); // add column to page
            page.Add(frame); // add frame to page
            column.Add(lineOfText); // and line of text to column

            // add chars to line of text
            lineOfText.Add(new Character('S'));
            lineOfText.Add(new Character('W'));
            lineOfText.Add(new Character('E'));
            lineOfText.Add(new Character('N'));
            lineOfText.Add(new Character('G'));

            Composite_Page_Item frame_column = new Column();
            Column_Frame_Item frame_LineOfText = new LineOfText();

            frame.Add(frame_column); // add column to frame
            frame_column.Add(frame_LineOfText); // add line of text to frame

            // add chars to line of text
            frame_LineOfText.Add(new Character('4'));
            frame_LineOfText.Add(new Character('2'));
            frame_LineOfText.Add(new Character('1'));

            Writer Ernest_Hemingway = new Writer(novel); // create writer object
            Ernest_Hemingway.GetNovel().View();
        }
    }
}