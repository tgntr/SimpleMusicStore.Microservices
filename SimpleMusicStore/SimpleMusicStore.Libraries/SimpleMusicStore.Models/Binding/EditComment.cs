using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleMusicStore.Models.Binding
{
    public class EditComment
    {
        [Required]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required, MinLength(1)]
        public string Text { get; set; }
        public DateTime DateEdited { get; set; }
    }
}
