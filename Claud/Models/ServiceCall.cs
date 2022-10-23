using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Claud.Models
{
    public class ServiceCall
    {
        public int Id { get; set; }


        [Required]
        [MaxLength(50)]
        public string LocationName { get; set; }


        [Required]
        [MaxLength(225)]
        public string LocationAddress { get; set; }


        public DateTime DateScheduled { get; set; }


        public DateTime DateService { get; set; }


        [Required]
        [MaxLength(225)]
        public string Notes { get; set; }


        public int UserProfileId { get; set; }


    }
}
