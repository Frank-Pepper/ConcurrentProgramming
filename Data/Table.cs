using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class Table : ITable
    {
        private readonly int _width;
        private readonly int _height;
        public Table(int width, int height)
        {
            _width = width;
            _height = height;
        }
        public override int GetRectangleWidth()
        {
            return _width;
        }
        public override int GetRectangleHeight()
        {
            return _height;
        }

    }
}
