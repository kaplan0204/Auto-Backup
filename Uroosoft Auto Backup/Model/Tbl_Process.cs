using System;
using System.ComponentModel.DataAnnotations;

namespace Uroosoft_Auto_Backup.Model
{
    internal class Tbl_Process
    {
        [Key]
        public int ProcessID { get; set; }
        public short ProcessType { get; set; }
        public string ProcessSourcePath { get; set; }
        public string ProcessDestationPath { get; set; }
        public short ProcessStatus { get; set; }
        [Required]
        public DateTime ProcessRunnigStartDate { get; set; }
        [Required]
        public DateTime ProcessRunnigLastDate { get; set; }
    }
}
