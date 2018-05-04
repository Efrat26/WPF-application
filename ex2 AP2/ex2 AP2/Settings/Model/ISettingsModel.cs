using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex2_AP2
{
    interface ISettingsModel
    {
        String OutputDirectory { get; set; }
        String SourceName { get; set; }
        String LogName { get; set; }
        int ThumbnailSize { get; set; }
    }
}
