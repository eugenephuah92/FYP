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
        private string s21_containment_action;
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

        public string Root_cause_option
        {
            get
            {
                return root_cause_option;
            }
            set
            {
                root_cause_option = value;
            }
        }
        public string Overall_summary
        {
            get
            {
                return overall_summary;
            }
            set
            {
                overall_summary = value;
            }
        }

        public string Problem_verification
        {
            get
            {
                return problem_verification;
            }
            set
            {
                problem_verification = value;
            }
        }
        public string Problem_verification_status
        {
            get
            {
                return problem_verification_status;
            }
            set
            {
                problem_verification_status = value;
            }
        }

        public string S21_containment_action
        {
            get
            {
                return s21_containment_action;
            }
            set
            {
                s21_containment_action = value;
            }
        }

        public string S22_implementation_date
        {
            get
            {
                return s22_implementation_date;
            }
            set
            {
                s22_implementation_date = value;
            }
        }

        public string S23_responsible_person
        {
            get
            {
                return s23_responsible_person;
            }
            set
            {
                 s23_responsible_person = value;
            }
        }

        public string S24_containment_result
        {
            get
            {
                return s24_containment_result;
            }
            set
            {
                s24_containment_result = value;
            }
        }

        public string Screening_area
        {
            get
            {
                return screening_area;
            }
            set
            {
                screening_area = value;
            }
        }

        public bool S2_track_action_item
        {
            get
            {
                return s2_track_action_item;
            }
            set
            {
                s2_track_action_item = value;
            }
        }

        public string S31_failure_analysis
        {
            get
            {
                return s31_failure_analysis;
            }
            set
            {
                s31_failure_analysis = value;
            }
        }

        public string S32_failure_analysis_results
        {
            get
            {
                return s32_failure_analysis_results;
            }
            set
            {
                s32_failure_analysis_results = value;
            }
        }

        public string Man
        {
            get
            {
                return man;
            }
            set
            {
                man = value;
            }
        }

        public string Method
        {
            get
            {
                return method;
            }
            set
            {
                method = value;
            }
        }

        public string Material
        {
            get
            {
                return material;
            }
            set
            {
                material = value;
            }
        }

        public string Machine
        {
            get
            {
                return machine;
            }
            set
            {
                machine = value;
            }
        }

        public string S51_corrective_action
        {
            get
            {
                return s51_corrective_action;
            }
            set
            {
                s51_corrective_action = value;
            }
        }

        public string S52_implementation_date
        {
            get
            {
                return s52_implementation_date;
            }
            set
            {
                s52_implementation_date = value;
            }
        }
        public string S53_responsible_person
        {
            get
            {
                return s53_responsible_person;
            }
            set
            {
                s53_responsible_person = value;
            }
        }

        public bool S5_track_action_item
        {
            get
            {
                return s5_track_action_item;
            }
            set
            {
                s5_track_action_item = value;
            }
        }

        public string S61_permanent_corrective_action
        {
            get
            {
                return s61_permanent_corrective_action;
            }
            set
            {
                s61_permanent_corrective_action = value;
            }
        }

        public string S62_implementation_date
        {
            get
            {
                return s62_implementation_date;
            }
            set
            {
                s62_implementation_date = value;
            }
        }

        public string S63_responsible_person
        {
            get
            {
                return s63_responsible_person;
            }
            set
            {
                s63_responsible_person = value;
            }
        }

        public string S6_track_action_item
        {
            get
            {
                return s6_track_action_item;
            }
            set
            {
                s6_track_action_item = value;
            }
        }

        public string S71_verify_effectiveness_of_corrective_actions
        {
            get
            {
                return s71_verify_effectiveness_of_corrective_actions;
            }
            set
            {
                s71_verify_effectiveness_of_corrective_actions = value;
            }
        }

        public string S72_implementation_date
        {
            get
            {
                return s72_implementation_date;
            }
            set
            {
                s72_implementation_date = value;
            }
        }

        public string S73_responsible_person
        {
            get
            {
                return s73_responsible_person;
            }
            set
            {
                s73_responsible_person = value;
            }
        }

        public string S74_verifier
        {
            get
            {
                return s74_verifier;
            }
            set
            {
                s74_verifier = value;
            }
        }

        public string  S75_verifier_email
        {
            get
            {
                return s75_verifier_email;
            }
            set
            {
                s75_verifier_email = value;
            }
        }

        public string S76_verifiy_effectiveness_of_corrective_actions_results
        {
            get
            {
                return s76_verifiy_effectiveness_of_corrective_actions_results;
            }
            set
            {
                s76_verifiy_effectiveness_of_corrective_actions_results= value;
            }
        }

        public string Defect_mode
        {
            get
            {
                return defect_mode;
            }
            set
            {
                defect_mode = value;
            }
        }

        public bool Require_8D_approval
        {
            get
            {
                return require_8D_approval;
            }
            set
            {
                require_8D_approval = value;
            }
        }

        public bool MOR_Calculated
        {
            get
            {
                return MOR_calculated;
            }
            set
            {
                MOR_calculated = value;
            }
        }
    }
}