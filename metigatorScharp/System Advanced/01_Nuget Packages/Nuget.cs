using Humanizer;
using System;
using System.Collections.Generic;


namespace System_Advanced._01_Nuget_Packages
{
    class FBComment
    {
        public string Owner { get; set; }
        public string Comment { get; set; }

        public DateTime CreatedAt { get; set; }



        public override string ToString() => $"{Owner} says: \n" +
                   $"\"{Comment}\"" +
                   $"\n\t\t\t\t {CreatedAt.Humanize()}";



        // bash tban leek dik 12 days ago .. 

        //public override string ToString() => $"{Owner} says: \n" +
        //           $"\"{Comment}\"" +
        //           $"\n\t\t\t\t  {CreatedAt.ToString("yyyy-MM-dd hh:mm")}";



    }


    public class Nuget
    {

        public static void Test()
        {

            var list = new List<FBComment>
            {
                new FBComment {Owner = "Sander Bos", Comment = "Hey ! I Like to work in my grug language", CreatedAt =  new DateTime(2025, 09, 14)},

                new FBComment {Owner = "Aboubakr jel", Comment = "Hej ! I like C++ and C#", CreatedAt = new DateTime(2025, 08, 24)}


            };


            foreach (var comment in list)
            {
                Console.WriteLine(comment);
            }


        }


    }
}
