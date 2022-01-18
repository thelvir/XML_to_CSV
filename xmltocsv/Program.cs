using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace xmltocsv
{
    class Program
    {
        static void Main(string[] args)
        {
            String InputFileName = "C:/Users/Hafiz/source/repos/xmltocsv/T_K21F05-A04768_20211116203138926.xml";
            String OutputFileName = "C:/Users/Hafiz/source/repos/xmltocsv/lines.csv";
            bool created = ConvertXMLtoCsv(InputFileName, OutputFileName);
            if (created)
            {
                Console.WriteLine("File created!\nFile name {0}", OutputFileName);
            }

            bool  ConvertXMLtoCsv(String InputFileName,String OutputFileName)
            {
                XmlDocument document = new XmlDocument();
                document.Load(InputFileName);
                XmlNode sortResult = document.SelectSingleNode("/SortResult");

                if(sortResult!=null)
                {
                    ProcessResult result = new ProcessResult();
                    result.MachineID = sortResult.Attributes["MachineID"].Value;
                    result.MachineNumber = sortResult.Attributes["machineNumber"].Value;
                    result.PackageNumber = sortResult.Attributes["packageNumber"].Value;
                    result.RejectionExists = Convert.ToBoolean(sortResult.Attributes["rejectionExists"].Value);
                    result.StartedAt = sortResult.Attributes["startDateTime"].Value;
                    result.EndedAt = sortResult.Attributes["endDateTime"].Value;
                    result.SendedAt = sortResult.Attributes["sendDateTime"].Value;
                    result.Lines = new List<BundleLine>();
                    XmlNodeList lines = document.SelectNodes("/SortResult/line");

                    foreach (XmlNode line in lines)
                    {
                        BundleLine bl = new BundleLine();
                        bl.CurrencyCode = line["currencyCode"].InnerText;
                        bl.Amount = Convert.ToInt32(line["amount"].InnerText);
                        bl.Nominal = Convert.ToInt32(line["nominal"].InnerText);
                        bl.Quantity = Convert.ToInt32(line["qty"].InnerText);
                        bl.Rejected = Convert.ToBoolean(line["rejected"].InnerText);
                        result.Lines.Add(bl);
                    }


                    using (var stream = File.CreateText(OutputFileName))
                    {
                        foreach (BundleLine line in result.Lines)
                        {
                            string csvRow = string.Format("{0},{1}", result.AsCsvRow(), line.asCsvRow());
                            stream.WriteLine(csvRow);
                        }
                        return true;
                    }
                }
                return false;

            }


        }
            

    }
}

