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

    }
}