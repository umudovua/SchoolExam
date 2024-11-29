﻿namespace SchoolExam.Domain.Entities.Base
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public DateTime CreateDate { get; set; }
		public DateTime? UpdateDate { get; set; }
		public bool IsDeleted { get; set; }
		public byte Status { get; set; }
	}
}
