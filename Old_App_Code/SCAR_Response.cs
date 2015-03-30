using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP_WebApp.Old_App_Code
{
    public class SCAR_Response
    {
        /* Declaration of SCAR Response details */

        private string root_cause_option;
        // S0 - Overall Summary
        private string overall_summary;

        // S1 - Problem Verification
        private string problem_verification;
        private string problem_verification_status;

        // S2 - Containment Aciton
        private string s21_containtment_action;
        private string s22_implementation_date;
        private string s23_responsible_person;
        private string s24_containment_result;
        private string screening_area;
        private bool s2_track_action_item;

        // S3 - Failure Analysis
        private string s31_failure_analysis;
        private string s32_failure_analysis_results;

        // S4 - Root Cause
        private string man;
        private string method;
        private string material;
        private string machine;

        // S5 - Corrective Action
        private string s51_corrective_action;
        private string s52_implementation_date;
        private string s53_responsible_person;
        private bool s5_track_action_item;

        // S6 - Permanent Corrective Action
        private string s61_permanent_corrective_action;
        private string s62_implementation_date;
        private string s63_responsible_person;
        private string s6_track_action_item;

        // S7 - Verify Effectiveness of Corrective Action Results
        private string s71_verify_effectiveness_of_corrective_actions;
        private string s72_implementation_date;
        private string s73_responsible_person;
        private string s74_verifier;
        private string s75_verifier_email;
        private string s76_verifiy_effectiveness_of_corrective_actions_results;

        // Others
        private string defect_mode;
        private bool require_8D_approval;
        private bool MOR_calculated;
    }
}