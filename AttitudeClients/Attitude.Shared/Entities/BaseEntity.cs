using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AttitudeClient.DBContext.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreateDate=DateTime.Now;
            ModifyDate=DateTime.Now;

        }
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        [Display(Name = "وضعیت")]
        public bool Visible { get; set; }
    }
}