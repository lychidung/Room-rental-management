using Project_Phòng_Trọ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Project_Phòng_Trọ
{
    internal static class Utility
    {
        static public string ImagePathAvatar = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Picture\Staff\";
        static public string ImagePathService = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Picture\Service\";
        static public Staff Staff = new();
        static public bool IsOpenForm(string formname)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == formname)
                {
                    return true;
                }
            }
            return false;
        }

        static public bool IsVaildMail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
