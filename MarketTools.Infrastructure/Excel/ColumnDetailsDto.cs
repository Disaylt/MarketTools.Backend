using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Excel
{
    internal class ColumnDetailsDto
    {
        public int Position { get; set; }
        public required string Name {  get; set; }
        public int Width { get; set; } = 100;
    }
}
