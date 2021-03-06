using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coir_ERP.Web.Models.Common.Modals
{
    public class CommonCreateOrEditViewModal<OutPutDto>
    {
        public OutPutDto ViewModal { get; set; }
        public bool IsEditMode { get; set; }
        public string HeaderName_Create { get; set; }
        public string HeaderName_Edit { get; set; }
        public string ModalData { get; set; }

        public CommonCreateOrEditViewModal(OutPutDto viewModal)
        {
            ViewModal = viewModal;
        }
    }
}