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


      static  int[][] Board1 = new int[][]
        {
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 },
            new int[] { 1, 2, 3, 4, 4, 6, 7, 8, 9 },
            new int[] { 1, 2, 3, 4, 0, 6, 7, 8, 9},
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9},
            new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9 },
            new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9},
            new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9},
            new int[] { -1, 2, 3, 4, -5, 6, 7, 8, -9 }
};

        [FunctionName("GetNewBoard")]
        public static async Task<int[][]> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            
            int difficulty = int.Parse(req.Query["difficulty"]);

            switch (difficulty)
            {
                    case 1:
                    return  Board1;
                    
                    case 2:
                    break;
                    case 3:
                    break;
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