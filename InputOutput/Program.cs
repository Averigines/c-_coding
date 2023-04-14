using System.Globalization;

Console.WriteLine("Console Output Encoding: ", Console.OutputEncoding);
Console.OutputEncoding = System.Text.Encoding.UTF8;

CultureInfo globalization = CultureInfo.CurrentCulture;
CultureInfo localization = CultureInfo.CurrentUICulture;

Console.WriteLine("The current globalization culture is {0}: {1}", globalization.Name, globalization.DisplayName);
Console.WriteLine("The current localization culture is {0}: {1}", localization.Name, localization.DisplayName);
Console.WriteLine();

Console.WriteLine("en-US: English (US)");
Console.WriteLine("en-US: Danish (Denmark)");
Console.WriteLine("Enter an ISO culture code: ");
string? newCulture = Console.ReadLine();

if (!string.IsNullOrEmpty(newCulture)) {
    CultureInfo ci = new CultureInfo(newCulture);
    CultureInfo.CurrentCulture = ci;
    CultureInfo.CurrentUICulture = ci;
}

Console.WriteLine();
Console.Write("Enter your name: ");
string? name = Console.ReadLine();

Console.WriteLine("Enter your date of birth: ");
string? dob = Console.ReadLine();

Console.WriteLine("Enter your salary: ");
string? salary = Console.ReadLine();

if (name != null && dob != null && salary != null) {
    DateTime date = DateTime.Parse(dob);
    int minutes = (int)DateTime.Today.Subtract(date).TotalMinutes;
    decimal earns = decimal.Parse(salary);

    Console.WriteLine("{0} was born on a {1:dddd}, is {2:N0} minutes old, and earns {3:C}", name, date, minutes, earns);
}