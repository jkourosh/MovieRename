// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

Console.WriteLine("********************************************");
Console.WriteLine("    This help to Category Movies on Year");
Console.WriteLine("          Last Version 2022");
Console.WriteLine("********************************************");
Console.WriteLine("        Press a key to Continue ...");
Console.ReadKey();

string pattern = @"(19|20)\d{2}";
string moviePattern = @"/^(?!\d\d?[ex]\d\d?)(?:\[(?:[-\w\s]+)*\])?(.*?)[-_.]?(?:[\{\(\[]?(?:dvdrip|[-._\b]ita|[-._\b]eng|xvid|cd\d|dvdscr|\w{1,5}rip|divx|\d+p|\d{4}).*?)?\.([\w]{2,3})$/img";

DirectoryInfo d = new(Directory.GetCurrentDirectory());
FileInfo[] infos = d.GetFiles("*.*");

foreach (FileInfo f in infos)
{
    var mov = Regex.Match(f.Name, moviePattern);
    if (mov.Success)
    {
        var m = Regex.Match(f.Name, pattern);
        if (m.Success)
        {  
            var r = Regex.Replace(f.Name, pattern, "");
            string newName = Path.Combine(f.DirectoryName.ToString(), m.ToString() + "." + r.ToString());
            newName = newName.Replace("()", "");
            newName = newName.Replace("[]", "");
            newName = newName.Replace("-.", ".");
            newName = newName.Replace(".-", ".");
            newName = newName.Replace("..", ".");
            File.Move(f.FullName, newName);
            Console.WriteLine(newName);
        }

    }
}
// Console.WriteLine("There isn't any Movie in this Dir!");

Console.ReadKey();

