using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Dto
{
    public class ShipDTO
    {
        public List<string> Containers { get; set; }
        public int Capacity { get; set; }
    }
}
