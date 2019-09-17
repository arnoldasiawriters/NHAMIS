using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NHAMIS;
using NHAMIS.APP.Models;
using SchoolManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vereyon.Web;

namespace SchoolManagementSystem.Assets
{
    public static class Utils
    {
        public static string FormatDateAlone(DateTime date)
        {
            string dateNew = date.ToString("MM/dd/yyyy");
            return dateNew;
        }

        public static string FormatDateTime(DateTime date)
        {
            string dateNew = date.ToString("MM/dd/yyyy hh:mm:ss");
            return dateNew;
        }

        public static void ShowUserMessage(string messageType, string messageDetails)
        {
            switch (messageType.ToLower())
            {
                case "info":
                    FlashMessage.Info(messageDetails);
                    break;
                case "confirmation":
                    FlashMessage.Confirmation(messageDetails);
                    break;
                case "warning":
                    FlashMessage.Warning(messageDetails);
                    break;
                case "danger":
                    FlashMessage.Danger(messageDetails);
                    break;
                default:
                    FlashMessage.Info(messageDetails);
                    break;
            }
        }

        public static UserDetails GetCurrentUserDetails()
        {
            NHAMISContext db = new NHAMISContext();
            var userId = HttpContext.Current.User.Identity.GetUserId();
            var userRole = db.UserRoles.Where(i => i.UserId == userId).FirstOrDefault();
            UserDetails userDetails = db.UserDetails.Where(n => n.UserId == userId).FirstOrDefault();
            UserDetailsViewModel userDetailsView = new UserDetailsViewModel();
            userDetailsView.UserDetails = userDetails;
            userDetailsView.RoleId = userRole.RoleId;
            return userDetails;
        }

        public static IdentityRole GetCurrentUserRole()
        {
            NHAMISContext db = new NHAMISContext();
            var userId = HttpContext.Current.User.Identity.GetUserId();
            var userRole = db.UserRoles.Where(i => i.UserId == userId).FirstOrDefault();
            var RoleId = userRole.RoleId;
            return db.Roles.Where(r => r.Id == RoleId).FirstOrDefault();
        }
    }
}