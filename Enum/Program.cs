using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enum
{
    public enum Direction
    {
        up,
        down, 
        left, 
        right
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Direction up = Direction.up;
            Console.WriteLine(up);
            
        }
    }
}
