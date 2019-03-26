using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Pages
{

    public class SetPageMenuItem
    {
        public SetPageMenuItem()
        {
            TargetType = typeof(SetPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}