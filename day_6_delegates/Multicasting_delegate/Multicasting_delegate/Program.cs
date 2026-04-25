// See https://aka.ms/new-console-template for more information
using Multicasting_delegate;

class Program
{
    static void Main()
    {
        NewsAgency agency = new NewsAgency();

        Reader r1 = new Reader("Sagar ");
        Reader r2 = new Reader("Rahul ");

        agency.OnNewsPublished += r1.ReceiveNews;
        agency.OnNewsPublished += r2.ReceiveNews;

        agency.Publish("Sports News: India won the match!");
    }
}


