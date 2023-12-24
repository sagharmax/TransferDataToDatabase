using System.Collections.Generic;
using System.ComponentModel;

namespace TransferDataToDatabase.Common.Special
{
    public static class SpecialHelper
    {
        // ••••••••••••
        // DEFINATIONS ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ••••••••••••

        #region Enum

        #region UserType
        public enum UserType
        {
            [Description("انتخاب کنید...")]
            None = 0,
            [Description("مدیریت سیستم")]
            Administrator = 1,
            [Description("مدیریت استانی")]
            ProvinceAdmin = 2,
            [Description("مدیریت شهری")]
            CityAdmin = 3,
            [Description("مدیریت سازمانی")]
            OrganizationAdmin = 4,
            [Description("کاربری")]
            User = 5
        }

        #endregion

        #region UsereRoles
        public enum UserRoles
        {
            [Description("بازنشانی کلمه‌ی عبور")]
            ResetPassword = 1,
            [Description("پیکربندی")]
            Configurations = 2,
            [Description("اطلاعات منابع تراکنش")]
            TransactionSources = 3,
            [Description("اطلاعات کد‌های تراکنش")]
            TransactionCodes = 4,
            [Description("اطلاعات توصیفات تراکنش")]
            TransactionDescribes = 5,
            [Description("اطلاعات کلی حساب‌ها")]
            AccountsInfo = 6,
            [Description("اطلاعات استان‌ها")]
            Provinces = 7,
            [Description("اطلاعات شهرها")]
            Cities = 8,
            [Description("اطلاعات سازمان‌ها")]
            Organizations = 9,
            [Description("اطلاعات حساب‌ها")]
            Accounts = 10,
            [Description("اطلاعات پایانه‌های فروش")]
            Poses = 11,
            [Description("اطلاعات مسئولین حساب‌ها")]
            OwnersAccounts = 12,
            [Description("کاربران")]
            Users = 13,
            [Description("پشتیبان‌گیری پایگاه‌داده")]
            BackupDatabase = 14,
            [Description("بازیابی پایگاه‌داده")]
            RestoreDatabase = 15,
            [Description("تراکنش‌ها")]
            Transactions = 16,
            [Description("تراکنش‌های پایانه‌های فروش")]
            PosesTransactions = 17,
            [Description("مانده‌ی حساب‌ها")]
            Balances = 18,
            [Description("محاسبه سود")]
            Profits = 19,
            [Description("گزارش پیامک‌ها")]
            SmsReport = 20,
            [Description("مدیریت پیام‌های اضطراری")]
            UrgentMessageManagement = 21,
            [Description("افزودن توضیحات کاربری برای هر تراکنش")]
            AddDescriptionToTransaction = 22
        }

        #endregion

        #endregion

        #region Objects

        public static readonly List<UserRoles> AdministratorsRoles = new List<UserRoles>();
        public static readonly List<UserRoles> ProvinceAdminsRoles = new List<UserRoles>();
        public static readonly List<UserRoles> CityAdminsRoles = new List<UserRoles>();
        public static readonly List<UserRoles> OrganizationAdminsRoles = new List<UserRoles>();
        public static readonly List<UserRoles> UsersRoles = new List<UserRoles>();

        #endregion

        #region Properties

        public static bool ConnectionState { get; set; }
        public static string ServerDate { get; set; }
        public static int UserId { get; set; }
        public static int ProvinceId { get; set; }
        public static int CityId { get; set; }
        public static int OrganizationId { get; set; }
        public static UserType UserTypeId { get; set; }
        public static List<UserRoles> Roles { get; set; }
        public static bool IsActive { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string ToDoList { get; set; }
        public static string UrgentMessage { get; set; }

        #endregion

        // ••••••••••••
        // METHODS     ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ••••••••••••

        #region static SpecialHelper()
        static SpecialHelper()
        {
            // Administrator
            AdministratorsRoles.Add(UserRoles.ResetPassword);
            AdministratorsRoles.Add(UserRoles.Configurations);
            AdministratorsRoles.Add(UserRoles.AccountsInfo);
            AdministratorsRoles.Add(UserRoles.Provinces);
            AdministratorsRoles.Add(UserRoles.Cities);
            AdministratorsRoles.Add(UserRoles.Organizations);
            AdministratorsRoles.Add(UserRoles.Accounts);
            AdministratorsRoles.Add(UserRoles.Poses);
            AdministratorsRoles.Add(UserRoles.OwnersAccounts);
            AdministratorsRoles.Add(UserRoles.BackupDatabase);
            AdministratorsRoles.Add(UserRoles.RestoreDatabase);
            AdministratorsRoles.Add(UserRoles.Transactions);
            AdministratorsRoles.Add(UserRoles.PosesTransactions);
            AdministratorsRoles.Add(UserRoles.Balances);
            AdministratorsRoles.Add(UserRoles.Profits);
            AdministratorsRoles.Add(UserRoles.SmsReport);
            AdministratorsRoles.Add(UserRoles.UrgentMessageManagement);
            AdministratorsRoles.Add(UserRoles.AddDescriptionToTransaction);

            // Province Admin
            ProvinceAdminsRoles.Add(UserRoles.ResetPassword);
            ProvinceAdminsRoles.Add(UserRoles.Configurations);
            ProvinceAdminsRoles.Add(UserRoles.AccountsInfo);
            ProvinceAdminsRoles.Add(UserRoles.Provinces);
            ProvinceAdminsRoles.Add(UserRoles.Cities);
            ProvinceAdminsRoles.Add(UserRoles.Organizations);
            ProvinceAdminsRoles.Add(UserRoles.Accounts);
            ProvinceAdminsRoles.Add(UserRoles.Poses);
            ProvinceAdminsRoles.Add(UserRoles.OwnersAccounts);
            ProvinceAdminsRoles.Add(UserRoles.BackupDatabase);
            ProvinceAdminsRoles.Add(UserRoles.RestoreDatabase);
            ProvinceAdminsRoles.Add(UserRoles.Transactions);
            ProvinceAdminsRoles.Add(UserRoles.PosesTransactions);
            ProvinceAdminsRoles.Add(UserRoles.Balances);
            ProvinceAdminsRoles.Add(UserRoles.Profits);
            ProvinceAdminsRoles.Add(UserRoles.SmsReport);
            ProvinceAdminsRoles.Add(UserRoles.UrgentMessageManagement);
            ProvinceAdminsRoles.Add(UserRoles.AddDescriptionToTransaction);

            // City Admin
            CityAdminsRoles.Add(UserRoles.ResetPassword);
            CityAdminsRoles.Add(UserRoles.Configurations);
            CityAdminsRoles.Add(UserRoles.AccountsInfo);
            CityAdminsRoles.Add(UserRoles.Provinces);
            CityAdminsRoles.Add(UserRoles.Cities);
            CityAdminsRoles.Add(UserRoles.Organizations);
            CityAdminsRoles.Add(UserRoles.Accounts);
            CityAdminsRoles.Add(UserRoles.Poses);
            CityAdminsRoles.Add(UserRoles.OwnersAccounts);
            CityAdminsRoles.Add(UserRoles.BackupDatabase);
            CityAdminsRoles.Add(UserRoles.RestoreDatabase);
            CityAdminsRoles.Add(UserRoles.Transactions);
            CityAdminsRoles.Add(UserRoles.PosesTransactions);
            CityAdminsRoles.Add(UserRoles.Balances);
            CityAdminsRoles.Add(UserRoles.Profits);
            CityAdminsRoles.Add(UserRoles.SmsReport);
            CityAdminsRoles.Add(UserRoles.UrgentMessageManagement);
            CityAdminsRoles.Add(UserRoles.AddDescriptionToTransaction);

            // Organization Admin
            OrganizationAdminsRoles.Add(UserRoles.ResetPassword);
            OrganizationAdminsRoles.Add(UserRoles.Configurations);
            OrganizationAdminsRoles.Add(UserRoles.AccountsInfo);
            OrganizationAdminsRoles.Add(UserRoles.Provinces);
            OrganizationAdminsRoles.Add(UserRoles.Cities);
            OrganizationAdminsRoles.Add(UserRoles.Organizations);
            OrganizationAdminsRoles.Add(UserRoles.Accounts);
            OrganizationAdminsRoles.Add(UserRoles.Poses);
            OrganizationAdminsRoles.Add(UserRoles.OwnersAccounts);
            OrganizationAdminsRoles.Add(UserRoles.BackupDatabase);
            OrganizationAdminsRoles.Add(UserRoles.RestoreDatabase);
            OrganizationAdminsRoles.Add(UserRoles.Transactions);
            OrganizationAdminsRoles.Add(UserRoles.PosesTransactions);
            OrganizationAdminsRoles.Add(UserRoles.Balances);
            OrganizationAdminsRoles.Add(UserRoles.Profits);
            OrganizationAdminsRoles.Add(UserRoles.SmsReport);
            OrganizationAdminsRoles.Add(UserRoles.UrgentMessageManagement);
            OrganizationAdminsRoles.Add(UserRoles.AddDescriptionToTransaction);

            // User
            UsersRoles.Add(UserRoles.BackupDatabase);
            UsersRoles.Add(UserRoles.Transactions);
            UsersRoles.Add(UserRoles.PosesTransactions);
            UsersRoles.Add(UserRoles.Balances);
            UsersRoles.Add(UserRoles.Profits);
            UsersRoles.Add(UserRoles.UrgentMessageManagement);
            UsersRoles.Add(UserRoles.AddDescriptionToTransaction);
        }

        #endregion
    }
}
