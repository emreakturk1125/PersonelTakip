using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personeltakip.VO
{
	public partial class Personel:BaseEntity
	{
         [Key]
		public int personelID { get; set; }

		public int? bolumID { get; set; }

		[StringLength(50)]
		public string ad { get; set; }

		[StringLength(50)]
		public string soyad { get; set; }

		[StringLength(50)]
		public string email { get; set; }

		[StringLength(50)]
		public string sifre { get; set; }

		[StringLength(50)]
		public string tel { get; set; }

		public DateTime? dogumTarihi { get; set; }

		public int? Engel { get; set; }

		public Personel()
		{
		}
	}
}
