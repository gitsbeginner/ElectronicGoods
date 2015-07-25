using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RequestMaster.Models
{
    public class Request
    {
        public int ID { get; set; }
        [Display(Name = "Категория")]
        public string Category { get; set; }
        [Display(Name = "Краткое описание проблемы")]
        public string ShortDescription { get; set; }
        [Display(Name = "Детальное описание проблемы")]
        public string DetailsDescription { get; set; }
        [Display(Name = "Гарантия")]
        public bool IsWarranty { get; set; }
        [Display(Name = "Фирма-производитель")]
        public string ManufacturingFirm { get; set; }
        [Display(Name = "Контактные данные")]
        public string ContactData { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime DeadlineRequest { get; set; }
        public string State { get; set; }
        public int MasterID { get; set; }
        public string ClientID { get; set; }

    }
}