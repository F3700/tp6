// See https://aka.ms/new-console-template for more information
using System.CodeDom.Compiler;
using System.Diagnostics;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;
    public SayaTubeVideo(string title)
    {

        //Debug.Assert(title != null, "Title tidak boleh null");
        //Debug.Assert(title.Length <= 100, "Title tidak boleh lebih dari 100 karakter");
        if (title == null)
        {
            throw new ArgumentException("Title tidak boleh null!");
        }

        if (title.Length > 100)
        {
            throw new ArgumentException("Title tidak boleh lebih dari 100 karakter");
        }
        
        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }
    public void IncreasePlayCount(int tambahan)
    {
        //Debug.Assert(tambahan > 10000000, "Input penambahan play count maksimal 10.000.000");
        //Debug.Assert(tambahan < 1, "Input penambahan play count minimal 1");

        if (tambahan > 10000000)
        {
            throw new ArgumentException("PlayCount yang dimasukan melebihi kapasitas");
        }

        if (tambahan < 1)
        {
            throw new ArgumentException("Playcount kurang dari 1");
        }

        checked
        {
            this.playCount += tambahan;
        }
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine("Title = " + this.title);
        Console.WriteLine("Play count = " + this.playCount);
        Console.WriteLine("Id = "+ this.id + "\n");
    }
}

class Program
{
    static void Main()
    {
        SayaTubeVideo vid1 = new SayaTubeVideo("Tutorial Design By Contract – Albert Febrian");
        vid1.PrintVideoDetails();

        //test kalo judul null
        try
        {
            SayaTubeVideo vid2 = new SayaTubeVideo(null);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        //test kalo judul mempunyai karakter lebih dari 100
        try
        {
            SayaTubeVideo vid3 = new SayaTubeVideo(new string('A', 101));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        //test kalo nambahin lebih dari 10000000
        try
        {
            vid1.IncreasePlayCount(100000000);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        //test kalo nambahin kurang dari 1
        try
        {
            vid1.IncreasePlayCount(-1);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        //test kalo terjadi overflow
        try
        {
            for (int i = 1; i < 10000000; i++)
            {
                vid1.IncreasePlayCount(100000);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}