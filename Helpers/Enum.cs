using System.ComponentModel;

namespace MobileManiaAPI.Helpers
{

    public sealed class RightType
    {
        private RightType()
        {
        }
        public const string all = "all";
        public const string assigned = "assigned";
        public const string none = "none";

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

    public sealed class FilePaths
    {
        private FilePaths() { }
        public const string MobileImagesPath = "UploadedImages";
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
   
    public sealed class GeneralMessage
    {
        private GeneralMessage() { }
        public const string StatusFail = "Fail";
        public const string StatusSuccess = "Success";
        public const string StatusWarning = "Warning";
        public const string StatusInfo = "Info";

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
    public class ServiceResponse<T>
    {
        public bool success { get; set; }
        public string message { get; set; }
        public T data { get; set; }
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
