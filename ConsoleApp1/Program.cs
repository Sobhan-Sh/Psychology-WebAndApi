int h1 = 0, h2 = 1, num = 0;
DateTime startDt, EndDt;
for (int i = 0; i < 24; i++)
{
    startDt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, h1, 0, 0);
    EndDt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, h2, 0, 0);
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write("start:");
    Console.ResetColor();
    Console.Write(startDt);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Write(" End: ");
    Console.ResetColor();
    Console.Write(EndDt + "\n");
    h1++;
    if (h2 < 23) h2++;
    else h2 = 0;
   
}
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine(num);
Console.ResetColor();
Console.ReadKey();