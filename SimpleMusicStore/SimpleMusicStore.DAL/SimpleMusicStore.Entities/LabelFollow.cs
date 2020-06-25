using SimpleMusicStore.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimpleMusicStore.Entities
{
    public class LabelFollow : UserActivity
    {
        public LabelFollow()
			:base()
        {
        }

        public LabelFollow(int labelId, int userId)
            :base()
        {
            LabelId = labelId;
            UserId = userId;
        }

        [Required]
        public int LabelId { get; set; }
        public virtual Label Label { get; set; }
    }
}
