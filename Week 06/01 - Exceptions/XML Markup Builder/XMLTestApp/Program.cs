using System;
using XML;

namespace XMLTestApp
{
    class Program
    {
        static void Main()
        {

            XMLMarkupBuilder xml = new XMLMarkupBuilder();
            xml.OpenTag("note");
            xml.OpenTag("to").AddText("Bob").CloseTag();
            xml.OpenTag("from").AddText("Rob").CloseTag();
            xml.OpenTag("heading").AddText("Reminder").CloseTag();
            xml.OpenTag("body").AddText("Don't forget me this weekend!").CloseTag();
            xml.Finish();

            string result = xml.GetResult();
            Console.WriteLine(result);
        }
    }
}