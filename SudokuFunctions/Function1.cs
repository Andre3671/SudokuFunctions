using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace SudokuFunctions
{
    public static class Function1
    {


      static  string[][] Board1 = new string[][]
        {
            new string[] { "8", "", "2", "9", "1", "6", "", "7", "3" },
            new string[] { "5", "9", "", "7", "4", "2", "1", "", "8" },
            new string[] { "7", "", "1", "3", "5", "8", "", "2", "9" },
            new string[] { "4", "8", "", "6", "7", "5", "", "1", "2"},
            new string[] { "3", "1", "7", "2", "9", "4", "8", "5", "6"},
            new string[] {"2", "", "6", "", "3", "1", "9", "4", "7" },
            new string[] {"1", "7", "8", "", "6", "3", "", "9", "5"},
            new string[] {"6", "2", "4", "5", "8", "9", "7", "3", "1"},
            new string[] { "", "3", "5", "", "2", "7", "6", "", "4" }
};

        static string[][] Board2 = new string[][]
      {
             new string[] { "", "4", "2", "9", "1", "6", "5", "7", "" },
            new string[] { "5", "", "3", "7", "4", "2", "1", "", "8" },
            new string[] { "7", "6", "", "3", "5", "8", "", "2", "9" },
            new string[] { "4", "8", "9", "", "7", "", "3", "1", "2"},
            new string[] { "3", "1", "7", "", "", "4", "8", "5", "6"},
            new string[] {"2", "5", "", "8", "3", "", "9", "4", "7" },
            new string[] {"1", "", "8", "4", "6", "3", "", "9", "5"},
            new string[] {"", "2", "4", "5", "8", "9", "7", "", "1"},
            new string[] { "", "3", "5", "1", "2", "7", "6", "", "4" }
};

        static string[][] Board3 = new string[][]
      {
            new string[] { "", "4", "", "9", "", "6", "", "", "3" },
            new string[] { "5", "", "3", "", "4", "", "1", "", "8" },
            new string[] { "", "6", "", "3", "", "8", "", "2", "" },
            new string[] { "4", "", "9", "", "7", "", "3", "", "2"},
            new string[] { "3", "1", "7", "2", "9", "4", "8", "5", "6"},
            new string[] {"2", "5", "6", "8", "3", "1", "9", "4", "7" },
            new string[] {"1", "7", "8", "4", "6", "3", "2", "9", "5"},
            new string[] {"6", "2", "4", "5", "8", "9", "7", "3", "1"},
            new string[] { "9", "3", "5", "1", "2", "7", "6", "8", "4" }
};


     

        [FunctionName("GetNewBoard")]
        public static async Task<str[][]> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            
            int difficulty = int.Parse(req.Query["difficulty"]);

            switch (difficulty)
            {
                    case 1:
                    return  Board1;
                    
                    case 2:
                    return Board2;
                   
                    case 3:
                    return Board3;
            }




            return null;
        }
    }
}
//const board = [
//    [1, 2, 3, 4, 5, 6, 7, 8, 9],
//    [1, 2, 3, 4, 5, 6, 7, 8, 9],
//    [1, 2, 3, 4, 4, 6, 7, 8, 9],
//    [1, 2, 3, 4, -5, 6, 7, 8, 9],
//    [1, 2, 3, 4, 5, 6, 7, 8, 9],
//    [1, 2, 3, 4, 5, 6, 7, 8, 9],
//    [1, 2, 3, 4, 5, 6, 7, 8, 9],
//    [1, 2, 3, 4, 5, 6, 7, 8, 9],
//    [-1, 2, 3, 4, -5, 6, 7, 8, -9],
//];

//const board2 = [
//    [1, 2, 3, 4, 5, 6, 7, 8, 9],
//    [1, 2, 3, 4, 5, 6, 7, 8, 9],
//    [1, 2, 3, 4, 4, 6, 7, 8, 9],
//    [1, 2, 3, 4, -5, 6, 7, 8, 9],
//    [1, 2, 3, 4, 5, 6, 7, 8, 9],
//    [1, 2, 3, 4, 5, 6, 7, 8, 9],
//    [1, 2, 3, 4, 5, 6, 7, 8, 9],
//    [1, 2, 3, 4, 5, 6, 7, 8, 9],
//    [1, 2, -3, 4, -5, 6, 7, -8, 9],
//];
//const board3 = [
//    [1, 2, 3, 4, 5, 6, 7, 8, 9],
//    [1, 2, 3, 4, 5, 6, 7, 8, 9],
//    [1, 2, 3, 4, 4, 6, 7, 8, 9],
//    [1, 2, 3, 4, -5, 6, 7, 8, 9],
//    [1, 2, 3, 4, 5, 6, 7, 8, 9],
//    [1, 2, 3, 4, 5, 6, 7, 8, 9],
//    [1, 2, 3, 4, 5, 6, 7, 8, 9],
//    [1, 2, 3, 4, 5, 6, 7, 8, 9],
//    [1, -2, 3, -4, 5, -6, 7, -8, 9],
//];