using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Routing.Template;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace SudokuFunctions
{
    public static class Function1
    {


      static  string[][] Board1 = new string[][]
        {
            new string[] { "8", "4", "2", "9", "1", "6", "", "7", "3" },
            new string[] { "5", "9", "3", "7", "4", "2", "1", "", "8" },
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
        public static async Task<string[][]> Run(
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

        [FunctionName("CheckAllowNumber")]
        public static async Task<bool> CheckAllowNumber(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            
            int SelectColumn = int.Parse(req.Query["column"]);
            int SelectRow = int.Parse(req.Query["row"]);
            string PressedNumber = req.Query["pressed"];
            string[][] board = new string[9][];
            int difficulty = int.Parse(req.Query["difficulty"]);
            bool vertical = false;
            bool horisontal = true;
            bool blockBool = true;

            switch (difficulty)
            {
                case 1:
                    board = Board1;
                    break;
                case 2:
                    board = Board2;
                    break;

                case 3:
                    board = Board3;
                    break;
            }

            //kolla vertikalt
            foreach (var Row in board)
            {
                if (Row[SelectColumn] == PressedNumber)
                {
                    vertical = true;
                }
            }
            //kolla horisontellt
          
                horisontal = Array.Exists(board[SelectRow], element => element == PressedNumber);
            
           
            //kolla blocket
            int row = 0;
            int block = 0;
           string[][] blocklist = new string[9][];
            for (int x = 0; x < 7; x +=3)
            {

                for(int i = 0; i < 3; i++)
                {
                   string[] block1 = board[row].Skip(0 + x).Take(3 + x).ToArray();
                    string[] block2 = board[row + 1].Skip(0 + x).Take(3 + x).ToArray();
                    string[] block3 = board[row + 2].Skip(0 + x).Take(3 + x).ToArray();
                    block1 = block1.Concat(block2).Concat(block3).ToArray();
                    blocklist[block] = block1;
                    block++;
                    row = row + 3;
                    
                }
                row = 0;

            }

            if(SelectColumn > -1 && SelectColumn < 3)
            {
                if(SelectRow > -1 && SelectRow < 3)
                {
                    var test = Array.Exists(blocklist[0], element => element == PressedNumber);

                    blockBool = test;

                }else if(SelectRow > 2 && SelectRow < 6)
                {
                    blockBool = Array.Exists(blocklist[1], element => element == PressedNumber);
                }
                else if(SelectRow < 5 && SelectRow < 9)
                {
                    blockBool = Array.Exists(blocklist[2], element => element == PressedNumber);
                }
            }else if(SelectColumn > 2 && SelectColumn < 6) 
            {
                if (SelectRow > -1 && SelectRow < 3)
                {
                    blockBool = Array.Exists(blocklist[3], element => element == PressedNumber);
                }
                else if (SelectRow > 2 && SelectRow < 6)
                {
                    blockBool = Array.Exists(blocklist[4], element => element == PressedNumber);
                }
                else if (SelectRow < 5 && SelectRow < 9)
                {
                    blockBool = Array.Exists(blocklist[5], element => element == PressedNumber);
                }
            }
            else if(SelectColumn > 5 && SelectColumn < 9)
            {
                if (SelectRow > -1 && SelectRow < 3)
                {
                    blockBool = Array.Exists(blocklist[6], element => element == PressedNumber);
                }
                else if (SelectRow > 2 && SelectRow < 6)
                {
                    blockBool = Array.Exists(blocklist[7], element => element == PressedNumber);
                }
                else if (SelectRow < 5 && SelectRow < 9)
                {
                    blockBool = Array.Exists(blocklist[8], element => element == PressedNumber);
                }
            }


            if(!blockBool && !vertical && !horisontal)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


       
    }
}

