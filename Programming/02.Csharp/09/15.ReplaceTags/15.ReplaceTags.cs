using System;
using System.Linq;

class ReplaceTags
{
    // Write a program that replaces in a HTML document 
    // given as string all the tags <a href="…">…</a>
    // with corresponding tags [URL=…]…/URL]

    static void Main()
    {
        //variables
        string HTMLdocument = "<p>Please visit <a href=\"http://academy.telerik. com\">our site</a> to choose a training course. Also visit <a href=\"www.devbg.org\">our forum</a> to discuss the courses.</p>";

        HTMLdocument = HTMLdocument.Replace("<a href=\"", "[URL=");
        HTMLdocument = HTMLdocument.Replace("</a>", "[/URL]");
        HTMLdocument = HTMLdocument.Replace("\">", @"]");

        Console.WriteLine(HTMLdocument);
    }
}