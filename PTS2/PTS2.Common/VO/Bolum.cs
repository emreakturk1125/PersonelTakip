using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personeltakip.VO
{
	public partial class Bolum:BaseEntity
	{
        [Key]
		public int bolumID { get; set; }

		[StringLength(50)]
		public string bolumAdi { get; set; }

		public bool? isAdmin { get; set; }

		public Bolum()
		{
		}
	}
}
