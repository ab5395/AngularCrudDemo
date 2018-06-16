using System.IO;

namespace Myapp.Services.Models
{
    public class AppCommon
    {
        private const string userFilesFolderName = "UserFiles";
        private const string userFilesRequestName = "/Userfiles";
        private static string currDirectory = Directory.GetCurrentDirectory();
        private static readonly string modelAgentPortfolioImagesFolder = Path.Combine("ModelAgent", "PortfolioImages");
        private static readonly string modelAgentProfilePicImagesFolder = Path.Combine("ModelAgent", "ProfilePics");

        public string UserFilesFolderName { get { return userFilesFolderName; } }
        public string UserFilesRequestName { get { return userFilesRequestName; } }
        public string ModelAgentPortfolioImagesFolder_PhysicalPath { get { return Path.Combine(currDirectory, userFilesFolderName, modelAgentPortfolioImagesFolder); } }
        public string ModelAgentProfilePicImagesFolder_PhysicalPath { get { return Path.Combine(currDirectory, userFilesFolderName, modelAgentProfilePicImagesFolder); } }

        public string ModelAgentPortfolioImagesFolder_RequestPath { get { return Path.Combine(userFilesRequestName, modelAgentPortfolioImagesFolder); } }
        public string ModelAgentProfilePicImagesFolder_RequestPath { get { return Path.Combine(userFilesRequestName, modelAgentProfilePicImagesFolder); } }

        public void VerifyFolders()
        {
            Directory.CreateDirectory(ModelAgentPortfolioImagesFolder_PhysicalPath);
            Directory.CreateDirectory(ModelAgentProfilePicImagesFolder_PhysicalPath);
        }
    }
}
