using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coir_ERP.Web.Models.Common.Modals
{
    public class CommonIndexViewModal<OutPutDto>
    {
        public OutPutDto viewModal { get; set; }
        public bool IsTenantView { get; set; }
        public string IndexModalData { get; set; }
    }
}