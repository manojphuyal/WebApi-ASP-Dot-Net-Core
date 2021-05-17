using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Library
{
    public class DbResponse
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public string Id { get; set; }

        public string Extra { get; set; }
    }
}
