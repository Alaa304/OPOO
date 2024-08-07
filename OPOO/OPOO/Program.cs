// See https://aka.ms/new-console-template for more information

using System.ComponentModel;

Stack<command> undo = new Stack<command>();
Stack<command> redo = new Stack<command>();

string lin;
while (true)
{
    Console.WriteLine("Url exit to quit");
    lin = Console.ReadLine().ToLower();
    if(lin == "exit")
    {
        break;
    }else if(lin == "back")
    { if (undo.Count > 0)
        {
            var item = undo.Pop();
            redo.Push(item);
        }
        else
        {
            continue;
        }

    }else if(lin == "forwerd")
    {
        if (redo.Count > 0)
        {
            var item = redo.Pop();
            undo.Push(item);
        }
        else
        {
            continue;
        }

    }
    else
    {
        undo.Push(new command(lin));
    }
    
    Console.Clear();
    Print("back",undo);
    Print("forwerd",redo);
}

void Print(string name, Stack<command> commands)
{
    Console.WriteLine($" {name} hestory");
    Console.BackgroundColor = name.ToLower() =="back"?ConsoleColor.DarkBlue:ConsoleColor.Magenta;
    foreach (var command in commands)
    {
        Console.WriteLine($"\t\t {command}");
    }
    Console.BackgroundColor=ConsoleColor.Black;
}


class command
{
    private readonly DateTime _createdAt;
    private readonly string _url;
    public command(string url)
    {
        _createdAt = DateTime.Now;
        _url = url;
    }

    public override string ToString()
    {
        return $"[{this._createdAt.ToString("yy-MM-dd hh:mm")}]{this._url}";
    }


}