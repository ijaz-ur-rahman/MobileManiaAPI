using System.ComponentModel;

namespace MobileManiaAPI.Helpers
{
    public enum Status
    {
        Application_Received_OR_In_Process = 1,
        Application_Needs_Attention = 2,
        Application_Approved = 3,
        Application_Waiting_For_Signatures = 4,
        Application_File_Being_Finalized = 5,
        Application_Complete = 6,
        Application_Cancelled = 7,
        Application_Declined = 8,
    }
    public enum Role
    {
        Admin = 1,
        SuperAdmin = 2,
        VendorAdmin = 3,
        VendorNonAdmin = 4
    }

    public sealed class RightType
    {
        private RightType()
        {
        }
        public const string all = "all";
        public const string assigned = "assigned";
        public const string none = "none";

    }
    public enum AddressType
    {
        commercial_location = 1,
        home_address = 2,
        po_box = 3
    }
    public enum Settings
    {
        NewApplications = 1,
        ApplicationStatus = 2,
        Comments = 3,
        AllApplications = 4,
        AllApplicationStatuses = 5,
        AllComments = 6,
    }
    public sealed class UserType
    {
        private UserType() { }
        public const string superadmin = "superadmin";
        public const string faastrak = "faastrak";
        public const string vendor = "vendor";
        public const string annonymous = "annonymous";
    }
    public sealed class AppPath
    {
        private AppPath() { }
        public const string CommentDocumentPath = "uploads/comment-document";
        public const string NotificationDocumentPath = "uploads/notification-document";
        // public const string ReportPDFPath = "uploads\\report-pdf";
        public const string ApplicationDocumentPath = "uploads/application-document";
        public const string LenderLogoPath = "uploads/lender-logo";
        public const string LenderDocumentPath = "uploads/lender-document";
        public const string VendorLogoPath = "uploads/vendor-logo";
        public const string VendorDocumentPath = "uploads/vendor-document";
        public const string ProfileImagePath = "uploads/profile-image";
        public const string AssetsPath = "uploads/assets";

    }
    public sealed class FilePath
    {
        private FilePath() { }
        public const string ProfileImage = "/api/getprofileimage/";
        public const string LenderLogo = "/api/getlenderlogo/";
        public const string VendorLogo = "/api/getvendorlogo/";
        public const string AppDoc = "/api/getappdoc/";
        public const string VendorDoc = "/api/getvendordoc/";
        public const string LenderDoc = "/api/getlenderdoc/";
        public const string CommentDoc = "/api/getcommentdoc/";
        public const string NotificationDoc = "/api/getnotificationdoc/";
        public const string Assets = "/api/getassets/";

    }

    public class EnumDescription
    {
        public static string Get(Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
        }
    }
    //public static class ApplicationUrl
    //{
    //    // parameterless constructor required for static class
    //    static ApplicationUrl() { } // default value

    //    // public get, and private set for strict access control
    //    public static string baseUrl { get; private set; }

    //    // GlobalInt can be changed only via this method
    //    public static void SetNewValue(string newVal)
    //    {
    //        baseUrl = newVal;
    //    }
    //}
    //public static class ApplicationUrl
    //{
    //    public static string baseUrl { get; set; }

    //}

    public sealed class GeneralMessage
    {
        private GeneralMessage() { }
        public const string StatusFail = "Fail";
        public const string StatusSuccess = "Success";
        public const string StatusWarning = "Warning";
        public const string StatusInfo = "Info";
        //public const string StatusException = "Exception";

        public const string ChangesSaved = "Changes have been saved successfully";
        public const string ClonedApplication = "Application Cloned successfully";
        public const string RecordAdded = "Record has been added successfully";
        public const string RecordUpdated = "Record has been updated successfully";
        public const string RecordDeleted = "Record has been deleted successfully";
        public const string DocumentUploaded = "Document has been uploaded successfully";
        public const string DocumentDeleted = "Document has been deleted successfully";
        public const string PaymentDone = "Your payment has been charged successfully";
        public const string MarkedCompleted = "Record has been marked as compeleted";
        public const string SMSSent = "SMS has been sent successfully";

        public const string RecordNotFound = "Record not found";
        public const string VendorNotExist = "Vendor does not exists";
        public const string FileNotFound = "File not found";
        public const string RecordNotMatched = "This record does not match. please try another one";

        public const string ServerError = "Server error occured";
        public const string PermissionError = "You are not authorized. Please contact administrator";
        public const string NotSuperAdminError = "Only SuperAdmin is authorized to perform this action";
        public const string DeleteSuperAdminError = "SuperAdmin can't be deleted";
        public const string FileNotUploadedError = "Please upload a file";
        public const string EmailSendError = "Email has not been sent";
        public const string DocumentDeleteError = "This document can't be deleted because it's uploaded by faastrak team.";

    }
    public class ServiceResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        //public string errorMessage { get; set; }
        public object data { get; set; }
    }
    public static class FileTypes
    {
        public static Dictionary<string, string> pairs = new Dictionary<string, string>()
            {
                {".txt", "text/plain"},
                {".xml", "application/xml"},
                {".pdf", "application/pdf"},
                {".doc", "application/ms-word"},
                {".docx", "application/ms-word"},
                {".xls", "application/ms-excel"},
                {".xlsx", "application/ms-excel"},
                {".ppt", "application/ms-powerpoint"},
                {".pptx", "application/ms-powerpoint"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };

    }
}
