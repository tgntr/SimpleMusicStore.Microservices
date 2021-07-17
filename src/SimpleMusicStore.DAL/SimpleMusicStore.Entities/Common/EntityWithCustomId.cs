using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimpleMusicStore.Entities.Common
{
	public abstract class EntityWithCustomId<T>
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public T Id { get; set; }
	}
}
