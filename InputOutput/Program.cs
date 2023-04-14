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