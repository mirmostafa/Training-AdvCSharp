/*
 * Linq:
 *  1- LINQ To Object
 *  2- LINQ To Database (SqlDataReader)
 *  3- LINQ To XML
 *  4- LINQ To DataSet^
 *  0- LINQ To Everything
 *  (Lazy Loading)
 */
//int a = 5;
//var b = 6;

// Foundametal
// List, Array (Memory)
using System.Text;

var vs = new int[2]; // [null], [null]
//x var vs2 = new string[2];
//x vs2[0] = "Ali";
//x vs2[1] = "Reza";
//x vs2[0] = "Maryam";
StringBuilder sb = new StringBuilder();
sb.Append("Ali");
sb.Append("Reza");
sb[0] = "Maryam";
// struct : Stack
// class: Heap

var names = new List<string>();
// My codes

// -----
// Chain List (List<string>)
// x05   [x0    | "Ali"    | x0A600]
// 0A600 [x05   | "Reza"   | x0700]
// 0700  [0A600 | "Maryam" | x0]
// -----


names.Add("Ali");
names.Add("Reza");
names[0] = "Maryam";

var nums = Enumerable.Range(0, int.MaxValue - 1);//.ToList(); //.ToArray()
var paging = nums.Skip(40).Take(20);
var odds = paging.Where(x => (x % 2) == 1);
foreach (var num in odds)
{
    Console.WriteLine(num);
}

//var list = nums.ToList().ForEach(x =>
