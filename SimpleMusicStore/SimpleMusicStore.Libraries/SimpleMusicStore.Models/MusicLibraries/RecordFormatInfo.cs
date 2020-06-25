using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMusicStore.Models.MusicLibraries
{
    public class RecordFormatInfo
    {
        [Required]
        public string Name { get; set; }
    }
}
