// See https://aka.ms/new-console-template for more information
using AdoNetExample;

Console.WriteLine("Hello, World!");

String insertSql = "insert into Student([name], cgpa, dateofbirth, studentid, isactive) values('riyadeb', 4.00, '2004-02-02', '5D41FF10-A1E5-4B86-823D-88AEB923B029', 1)";

String updateSql = "update Student set name = 'moni', Cgpa = 3.2 where id=1004 ";
String readSql = "select * from Student";

AdoNetExample.DataHelper dataHelper = new DataHelper();
dataHelper.WriteOperation(insertSql);
//dataHelper.UpdateData();
//dataHelper.ReadOperation(readSql);


string sqlRead = "select * from Student";
List<Dictionary<string, object>> data = dataHelper.ReadOperation(sqlRead);

foreach(Dictionary<string, object> item in data)
{
    foreach(var key in item.Keys)
    {
        Console.Write($"{key}:{item[key]}, " );
    }
    Console.WriteLine();
}


