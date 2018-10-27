using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login {
        public static class Globals {
        public static int interview_page = 1;
        public static bool addUserExists = false;
        public static bool shortResponse = true;
        public static string userID = "";
        public static string usersName = "";
        public static string adminID = "";
        public static bool previousClicked = false;
        public static bool toggleReadOutLoad = false;
        public static int interviewRow = 0;
        public static bool previousInterview = false;
        public static int previousInterviewType = 1;
    }
    }
