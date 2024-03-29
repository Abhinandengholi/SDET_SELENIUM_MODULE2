﻿using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicbricks.Utilities
{
    internal class ExcelUtils
    {
        public static List<SearchData> ReadSignUpExcelData(string excelFilePath, string sheetName)
        {
            List<SearchData> excelDataList = new List<SearchData>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });

                    var dataTable = result.Tables[sheetName];

                    if (dataTable != null)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            SearchData excelData = new SearchData
                            {
                                CitySelection = GetValueOrDefault(row, "searchCity"),
                                FullName = GetValueOrDefault(row, "fullName"),
                                Email = GetValueOrDefault(row, "email"),
                                Password= GetValueOrDefault(row, "pwd"),
                                PhoneNumber = GetValueOrDefault(row, "phoneNumber"),
                                 RentAmount= GetValueOrDefault(row, "rentAmount"),
                                LandOwnerName = GetValueOrDefault(row, "landownername"),
                                PropertyAddress = GetValueOrDefault(row, "propaddress"),
                                 QuestionInput = GetValueOrDefault(row, "questionInput")
                            };
                                

                            excelDataList.Add(excelData);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");
                    }
                }
            }

            return excelDataList;
        }

        static string GetValueOrDefault(DataRow row, string columnName)
        {
            Console.WriteLine(row + "  " + columnName);
            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() : null;
        }
    }
}
