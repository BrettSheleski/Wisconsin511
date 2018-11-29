using System.Collections.Generic;

namespace Wisconsin511
{
    public class Alert
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public string Notes { get; set; }
        public List<string> AreaNames { get; set; }
    }
}