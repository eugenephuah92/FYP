using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FYP_WebApp.Old_App_Code;

public partial class Engineer_scars_forms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Save_Section_1(object sender, EventArgs e)
    {
        SCAR scar_details = new SCAR();

        scar_details.Car_no = txtCarNo.Text;
        scar_details.Car_revision = txtCarRev.Text;
        scar_details.Car_type = txtCarType.Text;
        scar_details.Pre_alert = rdbPreAlert.Text;
        scar_details.Related_car_no = txtRelatedCarNo.Text;
        scar_details.Related_car_rev = txtRelatedCarRev.Text;
        scar_details.Originator = txtOriginator.Text;
        scar_details.Recurrence = txtRecurrence.Text;
        scar_details.Supplier_contact = txtSupplierContact.Text;
        scar_details.Supplier_email = txtSupplierEmail.Text;
        scar_details.Issued_date = cldIssuedDate.Value;
        scar_details.Originator_department = txtOriginatorDept.Text;
        scar_details.Originator_contact = txtOriginatorContact.Text;
        scar_details.Part_no = txtPartNo.Text;
        scar_details.Part_description = txtPartDesc.Text;
        scar_details.Business_unit = txtBusinessUnit.Text;
        scar_details.Dept_pl = txtDeptPL.Text;
        scar_details.Commodity = txtCommodity.Text;
        if(txtDefectQty.Text != String.Empty)
        {
            scar_details.Defect_quantity = Convert.ToInt16(txtDefectQty.Text);
        }
        scar_details.Defect_type = lstDefectType.SelectedValue;
        scar_details.Non_conformity_reported = txtNonConformity.Text;
        scar_details.Reject_reason = txtRejectReason.Text;
        scar_details.Expected_date_close = cldDateClose.Value;
        Insert_Into_Database(scar_details);
    }

    protected void Insert_Into_Database(SCAR scar_details)
    {
         txtCarNo.Text = scar_details.Car_type;
    }
}