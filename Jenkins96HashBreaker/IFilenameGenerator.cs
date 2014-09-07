using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jenkins96HashBreaker
{
    interface IFilenameGenerator
    {
        string NextFilename();
        ulong FilenameCount();
    }
}
