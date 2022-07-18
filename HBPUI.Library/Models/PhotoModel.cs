using System;
using System.Collections.Generic;
using System.Text;

namespace HBPUI.Library.Models
{
    public class PhotoModel
    {
        public int Id { get; set; }
        public string BlobName { get; set; }
        public string BlobContainerUri { get; set; }
        public string BlobType { get; set; }
        public string GetFullUri
        {
            get
            {
                // return $"{BlobContainerUri + BlobName}.{ BlobType }";
                return $"{BlobName}.{BlobType}";
            }
        }
    }
}
