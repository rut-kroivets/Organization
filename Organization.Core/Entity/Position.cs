using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organization.Core.Entity
{
    public enum PositionType
    {
        Manager = 1,
        Waiter,
        Chef,
        Host
    }
    public class Position
    {
        public int Id { get; set; }
        public PositionType Name { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime EnterDate { get; set; }
        public Employee Employee { get; set; }
    }
}
