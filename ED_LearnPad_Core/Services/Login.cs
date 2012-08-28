using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using ED_LearnPad_Core.DTOs;
using Ed_LearnPad_LoginWS.ER_Login;

namespace ED_LearnPad_Core.Services
{
    public class Login
    {
        public UserDto UserLogin(string username, string password)
        {
            LogMeSecure wsLogin = new LogMeSecure();
            UserDto userDto = null;
            string Token = "D2AED9027CAC4E90BF0A0603995D0ABE";
            DataSet dsLogin = new DataSet();
            dsLogin = wsLogin.SecUserInfo(username, password, Token);
            foreach (DataTable table in dsLogin.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    var authenticated = row["Authenticated"].ToString();
                    if (authenticated.ToUpper() == "YES")
                    {
                        userDto = new UserDto
                                   {
                                       LoginGuid = row["LoginGUID"].ToString(),
                                       LoginId = Convert.ToInt32(row["LoginID"].ToString()),
                                       UserFirstName = row["FirstName"].ToString(),
                                       UserFullName = row["FullName"].ToString(),
                                       UserLoginName = username,
                                       UserLastName = row["LastName"].ToString(),
                                       UserZipCode = row["ZipCode"].ToString(),
                                       UserValidLogin = true
                                   };

                    }
                    else
                    {
                        userDto = new UserDto {UserValidLogin = false};
                    }
                }
            }
            wsLogin.Dispose();
            return userDto;
        }
    }
}
