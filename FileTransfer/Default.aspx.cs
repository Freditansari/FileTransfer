using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace FileTransfer
{
    public partial class Default : System.Web.UI.Page
    {
        string uri = HttpContext.Current.Request.Url.Host;

        int ExpiryDays = 7;
        long totalBytes;

        double maxTotalUploadSize = 2000000000;
        //double maxTotalUploadSize = 1000000;

        

        protected void Page_Load(object sender, EventArgs e)
        {
            MaxFileSizeLabel.Text = maxTotalUploadSize.ToString();
        }

        private List<CustomUploadedFileInfo> uploadedFiles = new List<CustomUploadedFileInfo>();

        public List<CustomUploadedFileInfo> UploadedFiles
        {
            get
            {
                return uploadedFiles;
            }
            set
            {
                uploadedFiles = value;
            }
        }

        public class CustomUploadedFileInfo
        {
            public string FileName { get; set; }

            public string FileExtension { get; set; }

            public Int64 ContentLength { get; set; }

            public string LinkName { get; set; }

            public string batchUploadNumber { get; set; }

            public DateTime DateUploaded { get; set; }

            public DateTime dateExpired { get; set; }

        }

        //private void PopulateUploadedFilesList()
        //{
        //    string batchUpload = Guid.NewGuid().ToString();
        //    DateTime today = DateTime.Now;
            

        //    foreach (UploadedFile file in FileUploader.UploadedFiles)
        //    {
        //        CustomUploadedFileInfo uploadedFileInfo = new CustomUploadedFileInfo();

        //        uploadedFileInfo.FileName = file.GetName();
        //        uploadedFileInfo.FileExtension = file.GetExtension().Replace(".", string.Empty);
        //        uploadedFileInfo.ContentLength = file.ContentLength / 1024;
        //        uploadedFileInfo.LinkName = uri + "/Uploaded/" + uploadedFileInfo.FileName;
        //        uploadedFileInfo.batchUploadNumber = batchUpload;
        //        uploadedFileInfo.DateUploaded = today;
        //        uploadedFileInfo.dateExpired = today.AddDays(ExpiryDays);

        //        UploadedFiles.Add(uploadedFileInfo);
        //    }
        //}
        protected void FileUploader_FileUploaded(object sender, Telerik.Web.UI.FileUploadedEventArgs e)
        {
            //todo check max limit?

            //double totalFilesSize = uploadedFiles.Sum(item => item.ContentLength);

            //if (totalFilesSize >= maxTotalUploadSize)
            //{
            //    SendButton.Enabled = false;
            //}

            //const int MaxTotalBytes = 52428800; // 50 MB
            string batchUpload = Guid.NewGuid().ToString();
            DateTime today = DateTime.Now;

            var liItem = new HtmlGenericControl("li");
            liItem.InnerText = e.File.FileName;
            //totalBytes = e.File.ContentLength;
            totalBytes += e.File.ContentLength;

            if (totalBytes < maxTotalUploadSize)
            {
                // Total bytes limit has not been reached, accept the file
                e.IsValid = true;
                totalBytes += e.File.ContentLength;
               
            }
            else
            {
                // Limit reached, discard the file
                e.IsValid = false;
            }

            if (e.IsValid)
            {

                ValidFiles.Visible = true;
                ValidFilesList.Controls.AddAt(0, liItem);
                //PopulateUploadedFilesList();

                 //foreach (UploadedFile file in FileUploader.UploadedFiles)
        //    {
                CustomUploadedFileInfo uploadedFileInfo = new CustomUploadedFileInfo();

                uploadedFileInfo.FileName = e.File.FileName;
                //uploadedFileInfo.FileExtension = file.GetExtension().Replace(".", string.Empty);
                uploadedFileInfo.FileExtension = e.File.GetExtension().Replace(".", string.Empty);
                uploadedFileInfo.ContentLength = e.File.ContentLength / 1024;
                uploadedFileInfo.LinkName = uri + "/Uploaded/" + uploadedFileInfo.FileName;
                uploadedFileInfo.batchUploadNumber = batchUpload;
                uploadedFileInfo.DateUploaded = today;
                uploadedFileInfo.dateExpired = today.AddDays(ExpiryDays);

                UploadedFiles.Add(uploadedFileInfo);
        //    }

            }
            else
            {

                InvalidFiles.Visible = true;
                InValidFilesList.Controls.AddAt(0, liItem);
            }
            



        }

        protected void SendButton_Click(object sender, EventArgs e)
        {
           

            //PopulateUploadedFilesList();
            Page.Validate();
            
            if (UploadedFiles != null && Page.IsValid)
            {
                //todo email action with files and link maker
                //todo there is something to do but I forgot.
                GridView1.DataSource = uploadedFiles;
                GridView1.DataBind();
            }
        }
    }
}