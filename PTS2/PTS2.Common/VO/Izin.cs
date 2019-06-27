using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personeltakip.VO
{
	public partial class Izin:BaseEntity
	{
        [Key]
		public int izinID { get; set; }

		public int? personelID { get; set; }

		public int? bolumID { get; set; }

		public DateTime? baslamaTarihi { get; set; }

		public DateTime? bitisTarihi { get; set; }

		public short durum { get; set; }

		public DateTime? islemTarihi { get; set; }

		public int? onaylayan { get; set; }

		public DateTime? onayTarihi { get; set; }

		public Izin()
		{
		}
	}
}
