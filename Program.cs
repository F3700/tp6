// See https://aka.ms/new-console-template for more information
using System.CodeDom.Compiler;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;
    public SayaTubeVideo(string title)
    {
        Random random = new Random();
        this.id = random.Next(10000, 99999); //diisi bilangan random sepanjang 5 digit
        this.title = title;
        this.playCount = 0;
    }
    public void IncreasePlayCount(int tambahan)
    {
        this.playCount += tambahan;
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

        vid1.IncreasePlayCount(1);
        vid1.IncreasePlayCount(1);
        vid1.IncreasePlayCount(2);

        vid1.PrintVideoDetails();
    }
}