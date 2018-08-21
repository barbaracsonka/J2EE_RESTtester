using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J2EE_RESTtester
{
    class TranslationClass
    {
        public long Id { get; set; }
        public long DictionaryId { get; set; }
        public string Original { get; set; }
        public string Translation { get; set; }
    }
}
