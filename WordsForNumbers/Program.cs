using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsForNumbers
{
    class Program
    {
        static int convertString_Reversed(string number)
        {
            string[] container = number.Split(' ');
            Dictionary<string, string> simple = new Dictionary<string, string>
            {
                ["zero"] = "0",
                ["one"] = "1",
                ["two"] = "2",
                ["three"] = "3",
                ["four"] = "4",
                ["five"] = "5",
                ["six"] = "6",
                ["seven"] = "7",
                ["eight"] = "8",
                ["nine"] = "9",
                ["ten"] = "10",
                ["eleven"] = "11",
                ["twelve"] = "12"
            };
            Dictionary<string, string> other = new Dictionary<string, string>
            {
                ["thirteen"] = "13",
                ["fourteen"] = "14",
                ["fifteen"] = "15",
                ["sixteen"] = "16",
                ["seventeen"] = "17",
                ["eighteen"] = "18",
                ["twenty"] = "20",
                ["thirty"] = "30",
                ["forty"] = "40",
                ["fifty"] = "50",
                ["sixty"] = "60",
                ["seventy"] = "70",
                ["eighty"] = "80",
                ["ninety"] ="90",
                ["hundred"] = "100",
                ["thousand"] ="1000",
                ["million"] = "1000000"
            };

            int value = 0;
            for(int i = container.Length-1; i  >= 0; i--)
            {
                if (container[i].Contains("hundred") || container[i].Contains("thousand") || container[i].Contains("million"))
                {
                    int j = i;

                    if (container[j - 1].Contains('-') && container[j] == "hundred")
                    {
                        string[] subContainer = container[j - 1].Split('-');
                        value += int.Parse(other[subContainer[0]][0] + simple[subContainer[1]] + "0");
                    }

                    else if (container[j] == "hundred" && simple.ContainsKey(container[j - 1]))
                        value += int.Parse((simple[container[j - 1]] + "00").ToString());

                    else if (container[j] == "thousand" && simple.ContainsKey(container[j - 1]))
                        value += int.Parse(simple[container[j - 1]] + "000");

                    else if (container[j] == "thousand" && container[j - 1].Contains('-'))
                    {
                        string[] subContainer = container[j - 1].Split('-');
                        value += int.Parse(other[subContainer[0]][0] + simple[subContainer[1]] + "000");
                    }

                    else if (container[j] == "million" && simple.ContainsKey(container[j - 1]))
                        value += int.Parse(simple[container[j - 1]] + "000000");

                    else if(container[j] == "million" && container[j - 1].Contains('-'))
                    {
                        string[] subContainer = container[j - 1].Split('-');
                        value += int.Parse(other[subContainer[0]][0] + simple[subContainer[1]] + "000000");
                    }

                    i --;
                }
                //just for test
                else
                {
                    if (container[i].Contains('-')  )
                    {
                        string[] subContainer = container[i].Split('-');
                        value += int.Parse(other[subContainer[0]][0] + simple[subContainer[1]]);
                    }

                    else if (other.ContainsKey(container[i]))
                        value += int.Parse(other[container[i]]);

                    else if (simple.ContainsKey(container[i]))
                        value += int.Parse(simple[container[i]]);
                     
                }

            }
            
            return value;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("The program have been started...");

            Console.WriteLine("Write down your number:");
            string wordNumber = Console.ReadLine();
            int ans = convertString_Reversed(wordNumber);

            Console.WriteLine($"Your number is: {ans}");

            using (QueryContext db = new QueryContext())
            {
                Query answear = new Query() { 
                                                                     Question = wordNumber,
                                                                     CompiledResult = ans };

                db.Queries.Add(answear);
                db.SaveChanges();

                Console.WriteLine("Your information have been successfully saved into database...");
            }

            using(QueryContext db = new QueryContext())
            {
                var container = db.Queries.Distinct();
                //if you wonna see first five elements -> add for(); I used to use foreach without params
                Console.WriteLine("Your information are next...");
                foreach(Query s in container)
                {
                    Console.WriteLine($"\n---\nQuery ID: {s.Id}\n" +
                                                    $"Query Question: {s.Question}\n" +
                                                    $"Query Answear: {s.CompiledResult}\n---");
                }
            }

            

            Console.ReadKey();
        }
    }
}
