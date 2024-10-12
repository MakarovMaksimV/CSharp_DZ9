using System;
using System.Text.Json;
using System.Xml.Linq;

namespace DZ9
{
	public class ConvertJsonToXML
	{

		public void Convert(string j)
		{
            using (JsonDocument document = JsonDocument.Parse(j))
            {
                JsonElement root = document.RootElement;

                XElement xmlRoot = new XElement("Root");

                JsonElement current = root.GetProperty("Current");
                XElement currentElement = new XElement("Current",
                    new XElement("Time", current.GetProperty("Time").GetString()),
                    new XElement("Temperature", current.GetProperty("Temperature").GetInt32()),
                    new XElement("Weathercode", current.GetProperty("Weathercode").GetInt32()),
                    new XElement("Windspeed", current.GetProperty("Windspeed").GetDouble()),
                    new XElement("Winddirection", current.GetProperty("Winddirection").GetInt32())
                );
                xmlRoot.Add(currentElement);

                JsonElement history = root.GetProperty("History");
                XElement historyElement = new XElement("History");
                foreach (JsonElement entry in history.EnumerateArray())
                {
                    XElement entryElement = new XElement("Entry",
                        new XElement("Time", entry.GetProperty("Time").GetString()),
                        new XElement("Temperature", entry.GetProperty("Temperature").GetInt32()),
                        new XElement("Weathercode", entry.GetProperty("Weathercode").GetInt32()),
                        new XElement("Windspeed", entry.GetProperty("Windspeed").GetDouble()),
                        new XElement("Winddirection", entry.GetProperty("Winddirection").GetInt32())
                    );
                    historyElement.Add(entryElement);
                }
                xmlRoot.Add(historyElement);

                Console.WriteLine(xmlRoot);
                Console.ReadKey();
            }
        }
	
	}
}

