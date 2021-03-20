using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Var2Practice
{
    class Class1
    {
        int[,] nums3 = new int[6, 7] { { 6, 1, 1, 1, 1, 1, 5},
            { 5, 1, 1, 1, 1, 1, 3},
            {4, 1, 2, 2, 1, 1, 4 },
            {4, 1, 2, 2, 1, 1, 4 },
            {4, 1, 4, 4, 2, 2, 4 },
            {4, 1, 4, 4, 2, 2, 4 } };

        char symbol;
        int index;
        switch (symbol) {
            case ' ' : index = 0;
            case '(' : index = 1;
            case '+' : index = 2;
            case '-' : index = 3;
            case '*' : index = 4;
            case '/' : index = 5;
            case ')' : index = 6;
            }
    }
}
