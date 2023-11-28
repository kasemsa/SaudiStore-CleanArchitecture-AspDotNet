using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaudiStore.Application.Models.Mail
{
    public class Email
    {
        public string To { get; set; }=string.Empty;
        public string subject { get; set; } = string.Empty;
        public string body { get; set; } = string.Empty;

    } 
}
