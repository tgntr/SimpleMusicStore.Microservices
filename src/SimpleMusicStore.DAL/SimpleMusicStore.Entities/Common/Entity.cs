using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimpleMusicStore.Entities.Common
{
	//todo chec if data entities can inherit from abstract classes
	public abstract class Entity<T>
	{
        public T Id { get; set; }
	}
}
