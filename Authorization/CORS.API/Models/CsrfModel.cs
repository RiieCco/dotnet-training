using System;
using System.ComponentModel.DataAnnotations;

namespace Authorization.API.ViewModels
{
    public class CsrfModel
    {
        [Key]
        public int PrivateDataId { get; set; }
        public string PrivateData { get; set; }
        public DateTime PrivateDateTime { get; set; }
    }
}
