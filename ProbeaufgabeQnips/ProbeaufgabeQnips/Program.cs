using ProbeaufgabeQnips;
using System.Text;

DataWorker data = new DataWorker();
Console.OutputEncoding = Encoding.UTF8;
await data.GetData();