using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorAutoProjectail.Appdata
{
    public class Reports
    {
        public void GenerateCars() 
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application()
            {
                Visible = true,
                SheetsInNewWorkbook = 1
            };
            Microsoft.Office.Interop.Excel.Workbook work = app.Workbooks.Add(Type.Missing);
            app.DisplayAlerts = false;
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
            sheet.Name = "pomogite";

            // Заголовки столбцов
            sheet.Cells[1, 1] = "ID";
            sheet.Cells[1, 2] = "Марка";
            sheet.Cells[1, 3] = "Модель";
            sheet.Cells[1, 4] = "Год";
            sheet.Cells[1, 5] = "Стоимость";

            // Заполнение данных
            var currentRow = 2;
            var a = 0;
            foreach (var cars in Connection.context.cars)
            {
                sheet.Cells[currentRow, 1] = cars.id;
                sheet.Cells[currentRow, 2] = cars.mark;
                sheet.Cells[currentRow, 3] = cars.model;
                sheet.Cells[currentRow, 4] = cars.year;
                sheet.Cells[currentRow++, 4] = cars.cost;
            }

            Microsoft.Office.Interop.Excel.Range rang = sheet.get_Range("A1", "E" + (currentRow).ToString());
            rang.Cells.Font.Name = "Times New Roman";
            rang.Font.Size = 14;
            rang.Font.Bold = true;
        }
        public void GenerateClients() 
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application()
            {
                Visible = true,
                SheetsInNewWorkbook = 1
            };
            Microsoft.Office.Interop.Excel.Workbook work = app.Workbooks.Add(Type.Missing);
            app.DisplayAlerts = false;
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
            sheet.Name = "pomogite";

            // Заголовки столбцов
            sheet.Cells[1, 1] = "ID";
            sheet.Cells[1, 2] = "Имя";
            sheet.Cells[1, 3] = "Номер телефона";
            sheet.Cells[1, 4] = "Куплено всего";
            sheet.Cells[1, 5] = "На сумму";

            // Заполнение данных
            var currentRow = 2;
            decimal a = 0;
            foreach (var client in Connection.context.clients)
            {
                var sellInfo = Connection.context.sells.Where(x => x.id_client == client.id);
                foreach (var item in sellInfo)
                {
                    var itemGD = Connection.context.cars.FirstOrDefault(x => x.id == item.id_car);
                    a += itemGD.cost;
                }
                sheet.Cells[currentRow, 1] = client.id;
                sheet.Cells[currentRow, 2] = client.name;
                sheet.Cells[currentRow, 3] = client.phone_number;
                sheet.Cells[currentRow, 4] = sellInfo.Count();
                sheet.Cells[currentRow++, 5] = a;
               
            }

            Microsoft.Office.Interop.Excel.Range rang = sheet.get_Range("A1", "E" + (currentRow).ToString());
            rang.Cells.Font.Name = "Times New Roman";
            rang.Font.Size = 14;
            rang.Font.Bold = true;
        }
        public void GenerateDillers()
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application()
            {
                Visible = true,
                SheetsInNewWorkbook = 1
            };
            Microsoft.Office.Interop.Excel.Workbook work = app.Workbooks.Add(Type.Missing);
            app.DisplayAlerts = false;
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
            sheet.Name = "pomogite";

            // Заголовки столбцов
            sheet.Cells[1, 1] = "ID";
            sheet.Cells[1, 2] = "Имя";
            sheet.Cells[1, 3] = "Номер телефона";
            sheet.Cells[1, 4] = "Зар. плата";
            sheet.Cells[1, 5] = "Продано всего";
            sheet.Cells[1, 6] = "На сумму";
            
            // Заполнение данных
            var currentRow = 2;
            decimal a = 0;
            foreach (var diller in Connection.context.dillers)
            {
                var sellInfo = Connection.context.sells.Where(x => x.id_diller == diller.id);
                foreach (var item in sellInfo)
                {
                    var itemGD = Connection.context.cars.FirstOrDefault(x => x.id == item.id_car);
                    a += itemGD.cost;
                }
                sheet.Cells[currentRow, 1] = diller.id;
                sheet.Cells[currentRow, 2] = diller.name;
                sheet.Cells[currentRow, 3] = diller.phone_number;
                sheet.Cells[currentRow, 4] = diller.phone_number;
                sheet.Cells[currentRow, 5] = sellInfo.Count();
                sheet.Cells[currentRow++, 6] = a;
            }

            Microsoft.Office.Interop.Excel.Range rang = sheet.get_Range("A1", "E" + (currentRow).ToString());
            rang.Cells.Font.Name = "Times New Roman";
            rang.Font.Size = 14;
            rang.Font.Bold = true;
        }
        public void GenerateSells() 
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application()
            {
                Visible = true,
                SheetsInNewWorkbook = 1
            };
            Microsoft.Office.Interop.Excel.Workbook work = app.Workbooks.Add(Type.Missing);
            app.DisplayAlerts = false;
            Microsoft.Office.Interop.Excel.Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)app.Worksheets.get_Item(1);
            sheet.Name = "pomogite";

            // Заголовки столбцов
            sheet.Cells[1, 1] = "ID";
            sheet.Cells[1, 2] = "Клиент";
            sheet.Cells[1, 3] = "Номер клиета";
            sheet.Cells[1, 4] = "Диллер";
            sheet.Cells[1, 5] = "Номер диллера";
            sheet.Cells[1, 6] = "Марка";
            sheet.Cells[1, 7] = "Модель";
            sheet.Cells[1, 8] = "Год";
            sheet.Cells[1, 9] = "Стоимость";
            sheet.Cells[1, 10] = "Дата продажи";

            // Заполнение данных
            var currentRow = 2;
            decimal a = 0;
            foreach (var sell in Connection.context.sells)
            {
                var car = Connection.context.cars.FirstOrDefault(x => x.id == sell.id_car);
                var diller = Connection.context.dillers.FirstOrDefault(x => x.id == sell.id_diller);
                var client = Connection.context.clients.FirstOrDefault(x => x.id == sell.id_client);

                sheet.Cells[currentRow, 1] = sell.id;
                sheet.Cells[currentRow, 2] = client.name;
                sheet.Cells[currentRow, 3] = client.phone_number;
                sheet.Cells[currentRow, 4] = diller.name;
                sheet.Cells[currentRow, 5] = diller.phone_number;
                sheet.Cells[currentRow, 6] = car.mark;
                sheet.Cells[currentRow, 7] = car.model;
                sheet.Cells[currentRow, 8] = car.year;
                sheet.Cells[currentRow, 9] = car.cost;
                sheet.Cells[currentRow++, 10] = sell.date_sell;
            }

            Microsoft.Office.Interop.Excel.Range rang = sheet.get_Range("A1", "Z" + (currentRow).ToString());
            rang.Cells.Font.Name = "Times New Roman";
            rang.Font.Size = 14;
            rang.Font.Bold = true;
        }
        public void GenerateUsers() { }
    }
}
