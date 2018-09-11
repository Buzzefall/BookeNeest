using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BookeNeest.Domain.Constants
{
    public static class BookeNeestUserRoles
    {
        public const string Admin = "Admin";
        public const string Critic = "Critic";
        public const string Reader = "Reader";

        //private static List<string> GetAllRoles()
        //{
        //    return new List<string>
        //    {
        //        Admin,
        //        Critic,
        //        Reader
        //    };
        //}

        public static SelectList ToSelectList()
        {
            //return new SelectList(GetAllRoles().Select(x => new SelectListItem
            //{
            //    Text = x,
            //    Value = x,
            //    Selected = false
            //}), "Value", "Text");

            return new SelectList(typeof(BookeNeestUserRoles).GetFields().Select(f => new SelectListItem
            {
                Value = (string)f.GetRawConstantValue(),
                Text = (string)f.GetRawConstantValue()
            }), "Value", "Text");
        }

        
    }
}