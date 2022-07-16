using System;
using System.Collections.Generic;
using System.Text;

namespace HBPApi.Library.Models
{
    public class PhotoModel
    {
        public int Id { get; set; }
        public string ProductId { get; set; }
        public string BlobName { get; set; }
        public string BlobContainerUri { get; set; }
        public string BlobType { get; set; }
    }
}
