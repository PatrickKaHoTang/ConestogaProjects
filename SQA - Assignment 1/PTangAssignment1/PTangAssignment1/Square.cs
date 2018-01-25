using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTangAssignment1
{
    class Square
    {
        private int side;

        public Square()
        {
            side = 1;
        }

        public Square(int side)
        {
            this.side = side;
        }


        public int GetSide()
        {
            return side;
        }

        public int ChangeSide(int side)
        {
            this.side = side;

            return side;
        }

        public int GetPerimeter()
        {
            int perimeter = side * 4;

            return perimeter;
        }

        public int GetArea()
        {
            int area = side * side;

            return area;
        }
    }
}
