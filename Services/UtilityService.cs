namespace MobileManiaAPI.Services
{
    public interface IUtilityService
    {
        void LogExceptioninDatabase(Exception ex);
        void log(Exception ex);
        string GetApplicationRootPath();
        void memcachedlog(object data);
        string AddAbbrivationToNumber(long num);
        string ConvertUTCToEST(string date);
        string ConvertUTCToESTWithoutSeconds(string date);
        int StartRecordNumber(int PageNo, int PageSize);
      //  void GetIdByToken(string token, ApplicationViewModel creditapp);
    }
    public class UtilityService : IUtilityService
    {
        public string AddAbbrivationToNumber(long num)
        {
            throw new NotImplementedException();
        }

        public string ConvertUTCToEST(string date)
        {
            throw new NotImplementedException();
        }

        public string ConvertUTCToESTWithoutSeconds(string date)
        {
            throw new NotImplementedException();
        }

        public string GetApplicationRootPath()
        {
            throw new NotImplementedException();
        }

        //public void GetIdByToken(string token, ApplicationViewModel creditapp)
        //{
        //    throw new NotImplementedException();
        //}

        public void log(Exception ex)
        {
            throw new NotImplementedException();
        }

        public void LogExceptioninDatabase(Exception ex)
        {
            throw new NotImplementedException();
        }

        public void memcachedlog(object data)
        {
            throw new NotImplementedException();
        }

        public int StartRecordNumber(int PageNo, int PageSize)
        {
            throw new NotImplementedException();
        }
    }
}
