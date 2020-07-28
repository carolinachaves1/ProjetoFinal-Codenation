using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CentralDeErros.Api.AuthConfig
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpiryIn { get; set; }
        public string Emitter { get; set; }
        public string ValidateIn { get; set; }
    }
}
