using System;
using System.Collections.Generic;
using System.Text;

namespace Cuanto_Apotamo.Services
{
    public static class Constants
    {
        public static class Navigation
        {
            public const string MainPage = "Main";
            public const string NavigationPage = "Navigation";
            public const string Root = "Root";
            public const string SignUp = "SignUp";
            public const string LogIn = "LogIn";
            public const string Temp = "Temp";
            public const string Tab = "Tabbed";
            public const string Balance = "Balance";
            public const string Search = "Search";
        }

        public static class Url
        {
            public const string Api = "http://192.168.0.105:45457/api/";
        }

        public static class LogIn
        {
            public const string SuccessTitle = "Success!";
            public const string SuccessMessage = "Your user has been successfully authenticated!";
            public const string SuccessButton = "Ok";
            public const string FailTitle = "Fail";
            public const string FailMessage = "Username or password incorrect...";
            public const string FailButton = "Ok";
            public const string ErrorTitle = "Error";
            public const string InternetError = "Sorry, we're having issues with Internet right now";
            public const string ErrorButton = "Ok";
        }

        public static class SignUp
        {
            public const string SuccessTitle = "Success!";
            public const string SuccessMessage = "has been successfully created!";
            public const string SuccessButton = "Ok";
            public const string FailTitle = "Fail";
            public const string FailMessage = "Fail";
            public const string FailButton = "Ok";
            public const string ErrorTitle = "Error";
            public const string InternetError = "Sorry, we're having issues with Internet right now";
            public const string ErrorButton = "Ok";
        }
    }
}
