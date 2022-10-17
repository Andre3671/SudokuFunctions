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
            new int[] { 8, 4, 2, 9, 1, 6, 5, 7, 3 },
            new int[] { 5, 9, 3, 7, 4, 2, 1, 6, 8 },
            new int[] { 7, 6, 1, 3, 5, 8, 4, 2, 9 },
            new int[] { 4, 8, 9, 6, 7, 5, 3, 1, 2},
            new int[] { 3, 1, 7, 2, 9, 4, 8, 5, 6},
            new int[] {2, 5, 6, 8, 3, 1, 9, 4, 7 },
            new int[] {1, 7, 8, 4, 6, 3, 2, 9, 5},
            new int[] {6, 2, 4, 5, 8, 9, 7, 3, 1},
            new int[] { 9, 3, 5, 1, 2, 7, 6, 8, 4 }
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