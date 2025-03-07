using Exercises.Enums;
using Exercises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Exercises
{
    public static class Exercise3
    {

        public static void Run(DataSource dataSource)
        {
            string dataSourceString = dataSource.ToString();
            if (dataSourceString.Equals("json", StringComparison.OrdinalIgnoreCase))
            {
                ProcessJsonData();
            }
            else
            {
                ProcessXmlData();
            }
        }

        private static void ProcessJsonData() 
        {
            var jsonPath = Path.Combine(Environment.CurrentDirectory, "Data", "json", "dados.json");
            if (File.Exists(jsonPath))
            {
                try
                {
                    var jsonString = File.ReadAllText(jsonPath);
                    var jsonDataRDJson = JsonSerializer.Deserialize<List<RevenueDataJson>>(jsonString);

                    var jsonDataRD = jsonDataRDJson.Select(x => new RevenueData
                    {
                        Day = x.dia,
                        Value = x.valor
                    }).ToList();

                    ProcessData(jsonDataRD);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao processar o arquivo JSON: " + ex.Message);
                }
            }
        }

        private static void ProcessXmlData()
        {
            var xmlPath = Path.Combine(Environment.CurrentDirectory, "Data", "xml", "dados.xml");
            if (File.Exists(xmlPath))
            {
                try
                {
                    var xmlString = File.ReadAllText(xmlPath);

                    var xmlSerializer = new XmlSerializer(typeof(RevenueDataXmlList));

                    using (var reader = new StringReader(xmlString))
                    {
                        var xmlDataList = (RevenueDataXmlList)xmlSerializer.Deserialize(reader);

                        List<RevenueData> listRevenueDataXML = new List<RevenueData>();
                        foreach (var data in xmlDataList.Rows)
                        {
                            listRevenueDataXML.Add(new RevenueData
                            {
                                Day = data.Day,
                                Value = data.Value
                            });
                        }
                        ProcessData(listRevenueDataXML);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao processar o arquivo JSON: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine($"O arquivo não foi encontrado no caminho: {xmlPath}");
            }
        }

        public static void ProcessData(List<RevenueData> data)
        {
            List<RevenueData> validData = data.Where(x => x.Value > 0).ToList();

            if (validData.Count > 0)
            {
                var minRevenue = validData.Min(x => x.Value);
                var maxRevenue = validData.Max(x => x.Value);
                var averageRevenue = validData.Average(x => x.Value);
                var aboveAverageDays = validData.Count(x => x.Value > averageRevenue);

                Console.WriteLine($"Menor valor de faturamento: R${minRevenue:N2}");
                Console.WriteLine($"Maior valor de faturamento: R${maxRevenue:N2}");
                Console.WriteLine($"Número de dias com faturamento superior à média: {aboveAverageDays}");
            }
            else
            {
                Console.WriteLine("Não há dados válidos de faturamento.");
            }
        }

    }
}
