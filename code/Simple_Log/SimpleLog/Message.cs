using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLog
{
    public class Message
    {
        [Key]
        public long ID { get; set; }
        [Required]
        [MaxLength(10)]
        [Index]
        public string MessageType { get; set; }      
        [Required]
        [MaxLength(400)]
        [Index]
        public string Owner { get; set; }
        [Required]
        [MaxLength(50)]
        [Index]
        public string IdentifierName { get; set; }
        [Required]
        [MaxLength(50)]
        [Index]
        public string IdentifierValue { get; set; }
        [Required]
        [MaxLength(50)]
        [Index]
        public string Group { get; set; }
        [Required]
        [MaxLength(50)]
        [Index]
        public string Operation { get; set; }
        [Required]
        public string Data { get; set; }
        [Required]
        [Index]
        public DateTime CreatedOn { get; set; }
    }
}
